using RomanceHotel.BUS;
using RomanceHotel.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormThanhToanTongQuan : Form
    {
        private CTDP ctdp;
        private TaiKhoan taiKhoan;
        private Phong phong;
        private FormThongTinPhong parentForm;   // 👉 form đặt phòng cha

        private decimal tienPhong;
        private decimal tienDV;
        private decimal tongTien;

        public FormThanhToanTongQuan(CTDP ctdp, TaiKhoan taiKhoan, Phong phong, FormThongTinPhong parentForm)
        {
            InitializeComponent();
            this.ctdp = ctdp;
            this.taiKhoan = taiKhoan;
            this.phong = phong;
            this.parentForm = parentForm;

            LoadThongTin();
        }

        private void LoadThongTin()
        {
            try
            {
                // Lấy CTDP đầy đủ từ DB (include PhieuThue, KhachHang, Phong)
                CTDP c = CTDP_BUS.Instance.GetCTDP(ctdp.MaCTDP);
                if (c == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // --------- GÁN THÔNG TIN CƠ BẢN ----------
                txtMaCTDP.Text = c.MaCTDP;
                txtTenKH.Text = c.PhieuThue.KhachHang.TenKH;
                txtMaPhong.Text = c.MaPH;
                txtLoaiPhong.Text = c.Phong.LoaiPhong.TenLPH;
                txtNhanVien.Text = taiKhoan.NhanVien.TenNV;
                txtCheckIn.Text = c.CheckIn.ToString("dd/MM/yyyy HH:mm");
                txtCheckOut.Text = c.CheckOut.ToString("dd/MM/yyyy HH:mm");
                txtHinhThuc.Text = c.TheoGio ? "Thuê theo giờ" : "Thuê theo ngày";

                int soLuongThoiGian = 1;
                if (!c.TheoGio)
                {
                    soLuongThoiGian = CTDP_BUS.Instance.getKhoangTGTheoNgay(c.MaCTDP);
                    if (soLuongThoiGian <= 0) soLuongThoiGian = 1;
                    txtSoNgayGio.Text = soLuongThoiGian + " ngày";
                }
                else
                {
                    soLuongThoiGian = CTDP_BUS.Instance.getKhoangTGTheoGio(c.MaCTDP);
                    if (soLuongThoiGian <= 0) soLuongThoiGian = 1;
                    txtSoNgayGio.Text = soLuongThoiGian + " giờ";
                }

                // --------- TIỀN PHÒNG ----------
                if (c.ThanhTien > 0)
                    tienPhong = c.ThanhTien;
                else
                    tienPhong = CTDP_BUS.Instance.TinhTienPhong(c);

                lblTienPhong.Text = tienPhong.ToString("#,# VNĐ");

                // --------- DỊCH VỤ ----------
                var listDV = CTDV_BUS.Instance.FindCTDV(c.MaCTDP);
                dataGridViewDV.Rows.Clear();
                tienDV = 0;

                foreach (var dv in listDV)
                {
                    var dvInfo = DichVuBUS.Instance.FindDichVu(dv.MaDV);

                    string tenDV = dvInfo != null ? dvInfo.TenDV : dv.MaDV;
                    decimal donGia = dv.DonGia;
                    int sl = dv.SL;
                    decimal thanhTien = dv.ThanhTien > 0 ? dv.ThanhTien : donGia * sl;

                    tienDV += thanhTien;

                    dataGridViewDV.Rows.Add(
                        tenDV,
                        donGia.ToString("#,#"),
                        sl,
                        thanhTien.ToString("#,#")
                    );
                }

                lblTienDV.Text = tienDV.ToString("#,# VNĐ");

                // --------- TỔNG TIỀN ----------
                tongTien = tienPhong + tienDV;
                lblTongTien.Text = tongTien.ToString("#,# VNĐ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin tóm tắt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            using (FormThanhToanTienMat f = new FormThanhToanTienMat(tongTien, ctdp, taiKhoan, phong))
            {
                f.OnPaymentCompleted = () =>
                {
                    // 👉 Khi đóng hóa đơn: đóng form tóm tắt + form thông tin phòng
                    try
                    {
                        this.Close();
                        parentForm?.Close();
                    }
                    catch { }
                };

                f.ShowDialog();
            }
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            using (FormThanhToanQR f = new FormThanhToanQR(tongTien, ctdp, taiKhoan, phong))
            {
                f.OnPaymentCompleted = () =>
                {
                    // 👉 Khi đóng hóa đơn: đóng form tóm tắt + form thông tin phòng
                    try
                    {
                        this.Close();
                        parentForm?.Close();
                    }
                    catch { }
                };

                f.ShowDialog();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
