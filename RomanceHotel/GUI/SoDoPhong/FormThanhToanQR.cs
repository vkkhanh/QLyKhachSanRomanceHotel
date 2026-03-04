using RomanceHotel.BUS;
using RomanceHotel.CTControls;
using RomanceHotel.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using RomanceHotel.Utils;
using System.Net.Mime;



namespace RomanceHotel.GUI
{
    public partial class FormThanhToanQR : Form
    {
        private decimal TongTien;
        private CTDP ctdp;
        private TaiKhoan taiKhoan;
        private Phong phong;

        // Callback báo cho form ngoài biết rằng thanh toán đã hoàn tất
        public Action OnPaymentCompleted { get; set; }

        public FormThanhToanQR(decimal tongTien, CTDP ctdp, TaiKhoan tk, Phong phong)
        {
            InitializeComponent();

            this.TongTien = tongTien;
            this.ctdp = ctdp;
            this.taiKhoan = tk;
            this.phong = phong;

            lblTongTien.Text = TongTien.ToString("#,# VNĐ");

            LoadVietQR();
        }

        // ===============================================================
        //  TẠO QR THANH TOÁN THẬT (QUÉT ĐƯỢC NGÂN HÀNG & MOMO)
        // ===============================================================
        private void LoadVietQR()
        {
            // --- CẤU HÌNH TÀI KHOẢN KHÁCH SẠN ---
            string bankCode = "STB";                  // Sacombank → mã chuẩn VietQR
            string accountNumber = "060289144245";    // Tài khoản ngân hàng của khách sạn
            string accountName = "VU KIM KHANH";     // Tên chủ tài khoản

            // --- NỘI DUNG THANH TOÁN ---
            string addInfo = $"ThanhToan_{ctdp.MaCTDP}";

            // --- TẠO URL CHUẨN VIETQR ---
            string url =
                $"https://img.vietqr.io/image/{bankCode}-{accountNumber}-compact.png" +
                $"?amount={TongTien}" +
                $"&addInfo={Uri.EscapeDataString(addInfo)}" +
                $"&accountName={Uri.EscapeDataString(accountName)}";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] img = wc.DownloadData(url);
                    using (MemoryStream ms = new MemoryStream(img))
                    {
                        picQR.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được mã VietQR!\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        //  XÁC NHẬN THANH TOÁN
        // ===============================================================
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Ở thực tế → xác thực gateway, ở đây xác nhận thủ công
            TaoHoaDon(out HoaDon hd);

            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Gửi email hóa đơn
            SendInvoiceEmail(hd);

            using (FormHoaDon frm = new FormHoaDon(hd))
            {
                frm.ShowDialog();
            }

            OnPaymentCompleted?.Invoke();

            this.Close();
        }



        // ===============================================================
        //  TẠO HÓA ĐƠN VÀ CẬP NHẬT TRẠNG THÁI
        // ===============================================================
        private void TaoHoaDon(out HoaDon hd)
        {
            hd = new HoaDon();
            hd.MaHD = HoaDonBUS.Instance.getMaHDNext();
            hd.MaNV = taiKhoan.MaNV;
            hd.MaCTDP = ctdp.MaCTDP;
            hd.NgHD = DateTime.Now;
            hd.TrangThai = "Đã thanh toán";
            hd.TriGia = TongTien;

            // Lưu hóa đơn
            HoaDonBUS.Instance.ThanhToanHD(hd);

            // Cập nhật CTDP
            ctdp.TrangThai = "Đã xong";
            CTDP_BUS.Instance.UpdateOrAddCTDP(ctdp);

            // Cập nhật phòng
            phong.TTDD = "Chưa dọn dẹp";
            PhongBUS.Instance.UpdateOrAdd(phong);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendInvoiceEmail(HoaDon hd)
        {
            try
            {
                // 1. Lấy thông tin cần thiết
                CTDP ctdp = CTDP_BUS.Instance.GetCTDPs()
                                .Single(p => p.MaCTDP == hd.MaCTDP);

                var khachHang = ctdp.PhieuThue.KhachHang;
                var phong = ctdp.Phong;
                var loaiPhong = LoaiPhongBUS.Instance.getLoaiPhong(phong.MaLPH);
                List<CTDV> ctdvs = CTDV_BUS.Instance.FindCTDV(hd.MaCTDP);

                // Nếu không có email thì không gửi
                string toEmail = khachHang.Email;
                if (string.IsNullOrWhiteSpace(toEmail))
                    return;

                string ngayHD = hd.NgHD?.ToString("dd/MM/yyyy HH:mm");
                string checkIn = ctdp.CheckIn.ToString("dd/MM/yyyy HH:mm");
                string checkOut = ctdp.CheckOut.ToString("dd/MM/yyyy HH:mm");

                // 2. Tính thời gian lưu trú
                string soTG;
                if (!ctdp.TheoGio)
                {
                    TimeSpan ts = ctdp.CheckOut - ctdp.CheckIn;
                    int ngay = (int)Math.Ceiling(ts.TotalDays);
                    if (ngay <= 0) ngay = 1;
                    soTG = ngay + " ngày";
                }
                else
                {
                    TimeSpan ts = ctdp.CheckOut - ctdp.CheckIn;
                    int gio = (int)Math.Ceiling(ts.TotalHours);
                    soTG = gio + " giờ";
                }

                // 3. Build HTML cho bảng dịch vụ
                StringBuilder sbRows = new StringBuilder();
                decimal tongDV = 0;

                foreach (var ctdv in ctdvs)
                {
                    var dv = DichVuBUS.Instance.FindDichVu(ctdv.MaDV);
                    sbRows.AppendLine($@"
                <tr>
                    <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb;'>{dv.TenDV}</td>
                    <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb; text-align:right;'>{ctdv.DonGia:#,#}</td>
                    <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb; text-align:center;'>{ctdv.SL}</td>
                    <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb; text-align:right;'>{ctdv.ThanhTien:#,#} VNĐ</td>
                </tr>");
                    tongDV += ctdv.ThanhTien;
                }

                // Thêm dòng tiền phòng
                sbRows.AppendLine($@"
            <tr>
                <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb; font-weight:bold;'>
                    {loaiPhong.TenLPH} (Phòng {phong.MaPH})
                </td>
                <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb; text-align:right;'>{ctdp.DonGia:#,#}</td>
                <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb; text-align:center;'>{soTG}</td>
                <td style='padding:8px 12px; border-bottom:1px solid #e5e7eb; text-align:right;'>{ctdp.ThanhTien:#,#} VNĐ</td>
            </tr>");

                string rowsHtml = sbRows.ToString();
                string tongTien = hd.TriGia.ToString("#,# VNĐ");
                string tenNV = NhanVienBUS.Instance.GetNhanVien(hd.MaNV).TenNV;

                // 4. SEND EMAIL
                string fromEmail = "khanhvk22.btt.knt@gmail.com";
                string fromPassword = "dtie uxsp zvlv jeap"; // app password

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, "Romance Hotel");
                mail.To.Add(toEmail);
                mail.Subject = $"Hóa đơn thanh toán – Romance Hotel ({hd.MaHD})";

                // ********** HTML EMAIL BODY FIXED **********
                mail.Body = $@"
<!DOCTYPE html>
<html lang='vi'>
<head>
<meta charset='utf-8'>
</head>
<body style='margin:0; padding:0; background:#f3f4f6; font-family:Arial, sans-serif;'>
    <table width='100%' cellpadding='0' cellspacing='0' style='background:#f3f4f6; padding:20px 0;'>
        <tr>
            <td align='center'>
                <table width='700' cellpadding='0' cellspacing='0' 
                       style='background:#ffffff; border:1px solid #e5e7eb; padding:24px;'>
                    
                    <!-- HEADER -->
                    <tr>
                        <td style='font-size:12px; color:#6b7280; text-transform:uppercase; letter-spacing:2px;'>
                            Romance Hotel
                        </td>
                    </tr>
                    <tr>
                        <td style='font-size:24px; font-weight:bold; color:#2563eb; padding-top:4px;'>
                            Hóa đơn thanh toán
                        </td>
                    </tr>
                    <tr>
                        <td style='border-bottom:2px solid #dbeafe; padding-top:6px;'></td>
                    </tr>

                    <!-- MÃ HÓA ĐƠN -->
                    <tr>
                        <td align='right' style='padding-top:10px;'>
                            <span style='display:inline-block; background:#eff6ff; color:#1d4ed8;
                                         font-size:11px; padding:5px 12px; border-radius:12px;'>
                                Mã HĐ: {hd.MaHD}
                            </span><br/>
                            <span style='font-size:11px; color:#6b7280;'>Ngày lập: {ngayHD}</span>
                        </td>
                    </tr>

                    <!-- THÔNG TIN KHÁCH HÀNG -->
                    <tr><td style='padding-top:18px; font-weight:bold; color:#4b5563; font-size:14px;'>Thông tin khách hàng</td></tr>
                    <tr>
                        <td>
                            <table width='100%' cellpadding='6' cellspacing='0' style='font-size:13px;'>
                                <tr><td width='140'>Họ tên</td><td><b>{khachHang.TenKH}</b></td></tr>
                                <tr><td>SĐT</td><td>{khachHang.SDT}</td></tr>
                                <tr><td>Quốc tịch</td><td>{khachHang.QuocTich}</td></tr>
                                <tr><td>Email</td><td>{khachHang.Email}</td></tr>
                            </table>
                        </td>
                    </tr>

                    <!-- THÔNG TIN PHÒNG -->
                    <tr><td style='padding-top:20px; font-weight:bold; color:#4b5563; font-size:14px;'>Phòng & lưu trú</td></tr>
                    <tr>
                        <td>
                            <table width='100%' cellpadding='6' cellspacing='0' style='font-size:13px;'>
                                <tr><td width='140'>Loại phòng</td><td><b>{loaiPhong.TenLPH}</b></td></tr>
                                <tr><td>Số phòng</td><td>{phong.MaPH}</td></tr>
                                <tr><td>Check-in</td><td>{checkIn}</td></tr>
                                <tr><td>Check-out</td><td>{checkOut}</td></tr>
                                <tr><td>Thời gian</td><td>{soTG}</td></tr>
                            </table>
                        </td>
                    </tr>

                    <!-- NHÂN VIÊN -->
                    <tr>
                        <td style='padding-top:10px; font-size:12px; color:#374151;'>
                            Nhân viên hỗ trợ: <b>{tenNV}</b>
                        </td>
                    </tr>

                    <!-- BẢNG CHI TIẾT -->
                    <tr>
                        <td style='padding-top:20px;'>
                            <table width='100%' cellpadding='0' cellspacing='0' 
                                   style='border:1px solid #e5e7eb;'>
                                <tr>
                                    <td colspan='4' 
                                        style='background:#2563eb; color:white; padding:10px 14px;
                                               font-weight:bold; font-size:14px;'>
                                        Chi tiết dịch vụ & tiền phòng
                                    </td>
                                </tr>

                                <tr style='background:#eff6ff; font-weight:bold; font-size:12px;'>
                                    <td style='padding:8px 12px;'>Hạng mục</td>
                                    <td style='padding:8px 12px; text-align:right;'>Đơn giá</td>
                                    <td style='padding:8px 12px; text-align:center;'>SL</td>
                                    <td style='padding:8px 12px; text-align:right;'>Thành tiền</td>
                                </tr>

                                {rowsHtml}
                            </table>
                        </td>
                    </tr>

                    <!-- TỔNG TIỀN -->
                    <tr>
                        <td style='padding-top:20px; background:#1d4ed8; color:white;
                                   padding:14px; font-size:16px; font-weight:bold; text-align:right;'>
                            Tổng thanh toán: {tongTien}
                        </td>
                    </tr>

                    <!-- FOOTER -->
                    <tr>
                        <td style='padding-top:20px; font-size:12px; color:#6b7280; line-height:1.6;
                                   border-top:1px dashed #d1d5db; padding-top:12px;'>
                            Cảm ơn <b style='color:#1d4ed8;'>{khachHang.TenKH}</b> đã sử dụng dịch vụ của 
                            <b style='color:#1d4ed8;'>Romance Hotel</b>.<br>
                            Mọi thắc mắc xin liên hệ hotline: <b style='color:#1d4ed8;'>1900 6655</b>.
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</body>
</html>";

                mail.IsBodyHtml = true;
                // Đính kèm QR hóa đơn
                byte[] qrBytes = QrHelper.GenerateInvoiceQrPngBytes(hd.MaHD);

                mail.Attachments.Add(
                    new Attachment(
                        new MemoryStream(qrBytes),
                        $"QR_{hd.MaHD}.png",
                        "image/png"
                    )
                );


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(
                    "Thanh toán thành công nhưng gửi Email hóa đơn thất bại:\n" + ex.Message,
                    "Lỗi gửi Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

    }
}
