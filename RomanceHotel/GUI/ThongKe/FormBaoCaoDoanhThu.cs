using CrystalDecisions.CrystalReports.Engine;
using RomanceHotel.BUS;
using RomanceHotel.DTO;
using RomanceHotel.GUI.Reports;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RomanceHotel.GUI.ThongKe
{
    public partial class FormBaoCaoDoanhThu : Form
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private System.Collections.Generic.List<BaoCaoDoanhThuPhongDTO> _dsPhongReport;
        private System.Collections.Generic.List<BaoCaoDoanhThuDichVuDTO> _dsDichVuReport;


        public FormBaoCaoDoanhThu()
        {
            InitializeComponent();
            InitFormSize();
            SetupGridStyles();
        }

        public FormBaoCaoDoanhThu(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            InitFormSize();
            SetupGridStyles();

            _fromDate = fromDate.Date;
            _toDate = toDate;

            dtpFrom.Value = _fromDate;
            dtpTo.Value = _toDate;

            LoadBaoCao();
        }

        /// <summary>
        /// Set kích thước form, vị trí, không full màn hình nhưng đủ lớn.
        /// </summary>
        private void InitFormSize()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1200, 700);
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Áp dụng style chung cho 2 DataGridView.
        /// </summary>
        private void SetupGridStyles()
        {
            SetupGrid(dgvBaoCaoPhong);
            SetupGrid(dgvBaoCaoDichVu);
        }

        private void SetupGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 119, 148);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 50;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 252);

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(25, 167, 206);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowTemplate.Height = 28;
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadBaoCao();
        }

        // Nút in report – hiện chưa làm gì, để sau nối với Crystal Report / RDLC / Excel
        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            if (tabControlBaoCao.SelectedTab == tabPagePhong)
            {
                InBaoCaoDoanhThuPhong();
            }
            else if (tabControlBaoCao.SelectedTab == tabPageDichVu)
            {
                InBaoCaoDoanhThuDichVu();
            }
        }

        private void InBaoCaoDoanhThuPhong()
        {
            // Nếu chưa load dữ liệu thì load
            if (_dsPhongReport == null || _dsPhongReport.Count == 0)
            {
                LoadBaoCao(); // sẽ tự fill lại _dsPhongReport
            }

            if (_dsPhongReport == null || _dsPhongReport.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo doanh thu phòng.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rpt = new rptBaoCaoDoanhThuPhong(); // tên file .rpt bạn vừa tạo
            rpt.SetDataSource(_dsPhongReport);

            var frm = new fReport();
            frm.SetReport(rpt);
            frm.ShowDialog(this);
        }

        private void InBaoCaoDoanhThuDichVu()
        {
            if (_dsDichVuReport == null || _dsDichVuReport.Count == 0)
            {
                LoadBaoCao();
            }

            if (_dsDichVuReport == null || _dsDichVuReport.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo doanh thu dịch vụ.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rpt = new rptBaoCaoDoanhThuDichVu();
            rpt.SetDataSource(_dsDichVuReport);

            var frm = new fReport();
            frm.SetReport(rpt);
            frm.ShowDialog(this);
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadBaoCao()
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1); // lấy hết ngày

            lblKhoangThoiGian.Text =
                $"Từ ngày {fromDate:dd/MM/yyyy} đến ngày {toDate:dd/MM/yyyy}";

            LoadBaoCaoDoanhThuPhong(fromDate, toDate);
            LoadBaoCaoDoanhThuDichVu(fromDate, toDate);
        }

        /// <summary>
        /// Báo cáo doanh thu tiền phòng, thêm cột Loại phòng (TenLPH),
        /// format ngày dd/MM/yyyy, tiền #,0.
        /// </summary>
        private void LoadBaoCaoDoanhThuPhong(DateTime fromDate, DateTime toDate)
        {
            using (var db = new HotelDTO())
            {
                var listCTDP = db.CTDPs
                                 .Where(c => (c.DaXoa == null || c.DaXoa == false) &&
                                             c.CheckIn >= fromDate &&
                                             c.CheckIn <= toDate)
                                 .Include(c => c.Phong)
                                 .Include(c => c.Phong.LoaiPhong)
                                 .ToList();

                decimal tongDoanhThuPhong = 0;
                int tongLuotThue = listCTDP.Count;
                int soPhongKhacNhau = listCTDP.Select(c => c.MaPH).Distinct().Count();

                _dsPhongReport = new List<BaoCaoDoanhThuPhongDTO>();
                int stt = 1;

                string tuNgayStr = fromDate.ToString("dd/MM/yyyy");
                string denNgayStr = toDate.ToString("dd/MM/yyyy");
                string ngayInStr = DateTime.Now.ToString("dd/MM/yyyy");

                foreach (var c in listCTDP)
                {
                    decimal thanhTien = CTDP_BUS.Instance.TinhTienPhong(c);
                    tongDoanhThuPhong += thanhTien;

                    var dto = new BaoCaoDoanhThuPhongDTO
                    {
                        STT = stt++,
                        MaCTDP = c.MaCTDP,
                        MaPhong = c.MaPH,
                        LoaiPhong = c.Phong != null && c.Phong.LoaiPhong != null
                                        ? c.Phong.LoaiPhong.TenLPH
                                        : "",
                        CheckIn = c.CheckIn,
                        CheckOut = c.CheckOut,
                        HinhThucThue = c.TheoGio ? "Theo giờ" : "Theo ngày",
                        DonGia = c.DonGia,
                        ThanhTien = thanhTien,

                        TuNgay = tuNgayStr,
                        DenNgay = denNgayStr,
                        NgayIn = ngayInStr,

                        TongDoanhThu = 0,     // tạm, set sau
                        TongLuotThue = 0,     // tạm, set sau
                        SoPhongDuocThue = 0   // tạm, set sau
                    };

                    _dsPhongReport.Add(dto);
                }

                // Ghi tổng vào từng dòng (để report dùng)
                foreach (var item in _dsPhongReport)
                {
                    item.TongDoanhThu = tongDoanhThuPhong;
                    item.TongLuotThue = tongLuotThue;
                    item.SoPhongDuocThue = soPhongKhacNhau;
                }

                // Show lên Grid luôn từ DTO
                dgvBaoCaoPhong.DataSource = _dsPhongReport;

                if (dgvBaoCaoPhong.Columns.Count > 0)
                {
                    dgvBaoCaoPhong.Columns["STT"].HeaderText = "STT";
                    dgvBaoCaoPhong.Columns["MaCTDP"].HeaderText = "Mã chi tiết đặt phòng";
                    dgvBaoCaoPhong.Columns["MaPhong"].HeaderText = "Phòng";
                    dgvBaoCaoPhong.Columns["LoaiPhong"].HeaderText = "Loại phòng";
                    dgvBaoCaoPhong.Columns["CheckIn"].HeaderText = "Ngày nhận";
                    dgvBaoCaoPhong.Columns["CheckOut"].HeaderText = "Ngày trả";
                    dgvBaoCaoPhong.Columns["HinhThucThue"].HeaderText = "Hình thức thuê";
                    dgvBaoCaoPhong.Columns["DonGia"].HeaderText = "Đơn giá (VNĐ)";
                    dgvBaoCaoPhong.Columns["ThanhTien"].HeaderText = "Thành tiền (VNĐ)";

                    // Ẩn các cột chỉ dùng cho header report
                    dgvBaoCaoPhong.Columns["TuNgay"].Visible = false;
                    dgvBaoCaoPhong.Columns["DenNgay"].Visible = false;
                    dgvBaoCaoPhong.Columns["NgayIn"].Visible = false;
                    dgvBaoCaoPhong.Columns["TongDoanhThu"].Visible = false;
                    dgvBaoCaoPhong.Columns["TongLuotThue"].Visible = false;
                    dgvBaoCaoPhong.Columns["SoPhongDuocThue"].Visible = false;

                    // Format ngày: dd/MM/yyyy
                    dgvBaoCaoPhong.Columns["CheckIn"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvBaoCaoPhong.Columns["CheckOut"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // Format tiền
                    dgvBaoCaoPhong.Columns["DonGia"].DefaultCellStyle.Format = "#,0";
                    dgvBaoCaoPhong.Columns["ThanhTien"].DefaultCellStyle.Format = "#,0";

                    // Cột STT nhỏ lại
                    dgvBaoCaoPhong.Columns["STT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvBaoCaoPhong.Columns["STT"].Width = 60;
                }

                lblTongDoanhThuPhong.Text = tongDoanhThuPhong.ToString("#,0") + " VNĐ";
                lblTongLuotThue.Text = tongLuotThue.ToString();
                lblSoPhong.Text = soPhongKhacNhau.ToString();
            }
        }


        /// <summary>
        /// Báo cáo doanh thu dịch vụ, format tiền #,0.
        /// </summary>
        private void LoadBaoCaoDoanhThuDichVu(DateTime fromDate, DateTime toDate)
        {
            using (var db = new HotelDTO())
            {
                // Lấy danh sách MaCTDP trong khoảng thời gian
                var listCTDP = db.CTDPs
                                 .Where(c => (c.DaXoa == null || c.DaXoa == false) &&
                                             c.CheckIn >= fromDate &&
                                             c.CheckIn <= toDate)
                                 .Select(c => c.MaCTDP)
                                 .ToList();

                // Lấy các CTDV tương ứng
                var listCTDV = db.CTDVs
                                 .Where(d => listCTDP.Contains(d.MaCTDP) &&
                                             (d.DaXoa == null || d.DaXoa == false))
                                 .ToList();

                // Lấy danh sách dịch vụ để tra TenDV (join bằng MaDV)
                // Giả sử bạn có DbSet<DichVu> trong HotelDTO tên là "DichVus"
                // và class DichVu có thuộc tính TenDV
                var dicDichVu = db.DichVus
                                  .Where(x => x.DaXoa == null || x.DaXoa == false)
                                  .ToDictionary(x => x.MaDV, x => x);

                decimal tongDoanhThuDV = 0;
                int tongLanSuDung = 0;

                _dsDichVuReport = new List<BaoCaoDoanhThuDichVuDTO>();
                int stt = 1;

                string tuNgayStr = fromDate.ToString("dd/MM/yyyy");
                string denNgayStr = toDate.ToString("dd/MM/yyyy");
                string ngayInStr = DateTime.Now.ToString("dd/MM/yyyy");

                foreach (var dv in listCTDV)
                {
                    decimal thanhTien = dv.ThanhTien > 0
                        ? dv.ThanhTien
                        : dv.DonGia * dv.SL;

                    tongDoanhThuDV += thanhTien;
                    tongLanSuDung += dv.SL;

                    string tenDV = "";
                    if (dicDichVu.TryGetValue(dv.MaDV, out var dvEntity) && dvEntity != null)
                    {
                        tenDV = dvEntity.TenDV;   // <– CHỈ DÙNG TenDV TỪ DICHVU
                    }

                    var dto = new BaoCaoDoanhThuDichVuDTO
                    {
                        STT = stt++,
                        MaCTDP = dv.MaCTDP,
                        MaDV = dv.MaDV,
                        TenDV = tenDV,

                        SoLuong = dv.SL,
                        DonGia = dv.DonGia,
                        ThanhTien = thanhTien,

                        TuNgay = tuNgayStr,
                        DenNgay = denNgayStr,
                        NgayIn = ngayInStr,

                        TongDoanhThu = 0,      // set sau
                        TongLanSuDung = 0      // set sau
                    };

                    _dsDichVuReport.Add(dto);
                }

                // Gán tổng vào DTO để Crystal Report dùng
                foreach (var item in _dsDichVuReport)
                {
                    item.TongDoanhThu = tongDoanhThuDV;
                    item.TongLanSuDung = tongLanSuDung;
                }

                dgvBaoCaoDichVu.DataSource = _dsDichVuReport;

                if (dgvBaoCaoDichVu.Columns.Count > 0)
                {
                    dgvBaoCaoDichVu.Columns["STT"].HeaderText = "STT";
                    dgvBaoCaoDichVu.Columns["MaCTDP"].HeaderText = "Mã CT đặt phòng";
                    dgvBaoCaoDichVu.Columns["MaDV"].HeaderText = "Mã dịch vụ";
                    dgvBaoCaoDichVu.Columns["TenDV"].HeaderText = "Tên dịch vụ";

                    dgvBaoCaoDichVu.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgvBaoCaoDichVu.Columns["DonGia"].HeaderText = "Đơn giá (VNĐ)";
                    dgvBaoCaoDichVu.Columns["ThanhTien"].HeaderText = "Thành tiền (VNĐ)";

                    // Ẩn các cột chỉ dùng cho header report
                    dgvBaoCaoDichVu.Columns["TuNgay"].Visible = false;
                    dgvBaoCaoDichVu.Columns["DenNgay"].Visible = false;
                    dgvBaoCaoDichVu.Columns["NgayIn"].Visible = false;
                    dgvBaoCaoDichVu.Columns["TongDoanhThu"].Visible = false;
                    dgvBaoCaoDichVu.Columns["TongLanSuDung"].Visible = false;

                    dgvBaoCaoDichVu.Columns["DonGia"].DefaultCellStyle.Format = "#,0";
                    dgvBaoCaoDichVu.Columns["ThanhTien"].DefaultCellStyle.Format = "#,0";

                    dgvBaoCaoDichVu.Columns["STT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvBaoCaoDichVu.Columns["STT"].Width = 60;
                }

                lblTongDoanhThuDichVu.Text = tongDoanhThuDV.ToString("#,0") + " VNĐ";
                lblTongLanSuDungDV.Text = tongLanSuDung.ToString();
            }
        }


    }

}

