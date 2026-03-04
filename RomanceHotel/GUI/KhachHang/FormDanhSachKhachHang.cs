using RomanceHotel.BUS;
using RomanceHotel.CTControls;
using RomanceHotel.DTO;
using RomanceHotel.GUI.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormDanhSachKhachHang : Form
    {
        private List<KhachHang> khachHangs;
        private Image KH = Properties.Resources.KhachHang;
        private Image edit = Properties.Resources.edit;
        private Image delete = Properties.Resources.delete;
        private FormMain formMain;
        private TaiKhoan taiKhoan;

        // Lưu khoảng ngày đang lọc để in lên report
        private DateTime? tuNgayLoc = null;
        private DateTime? denNgayLoc = null;

        public FormDanhSachKhachHang()
        {
            InitializeComponent();
            LoadAllGrid();
        }

        public FormDanhSachKhachHang(FormMain formMain, TaiKhoan taiKhoan)
        {
            InitializeComponent();
            LoadAllGrid();
            this.formMain = formMain;
            this.taiKhoan = taiKhoan;
        }

        private void FormDanhSachKhachHang_Load(object sender, EventArgs e)
        {
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);

            // Gợi ý khoảng ngày mặc định: từ đầu tháng đến hôm nay
            if (dtpTuNgay != null && dtpDenNgay != null)
            {
                dtpDenNgay.Value = DateTime.Today;
                dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            }

            /*grid.Rows.Add(new object[] { KH, "KH001", "Phan Tuấn Thành", "123456789101", "0956093276", "Việt Nam", "Nam", edit, delete });
            grid.Rows.Add(new object[] { KH, "KH002", "Trần Văn C", "123456789101", "0956093276", "Singapore", "Nữ", edit, delete });
            grid.Rows.Add(new object[] { KH, "KH003", "Nguyễn Thị B", "123456789101", "0956093276", "Thái Lan", "Nữ", edit, delete });
            grid.Rows.Add(new object[] { KH, "KH004", "Nguyễn Văn A", "123456789101", "0956093276", "Mỹ", "Nam", edit, delete });*/
        }

        public void LoadAllGrid()
        {
            try
            {
                // Reset khoảng ngày khi load tất cả
                tuNgayLoc = null;
                denNgayLoc = null;

                this.khachHangs = KhachHangBUS.Instance.GetKhachHangs();
                LoadGrid();
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGrid()
        {
            try
            {
                grid.Rows.Clear();
                if (khachHangs == null) return;

                foreach (KhachHang khachHang in khachHangs)
                {
                    grid.Rows.Add(
                        this.KH,
                        khachHang.MaKH,
                        khachHang.TenKH,
                        khachHang.CCCD_Passport,
                        khachHang.SDT,
                        khachHang.QuocTich,
                        khachHang.GioiTinh,
                        edit,
                        delete
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadGridWithCCCD()
        {
            try
            {
                khachHangs = KhachHangBUS.Instance.FindKhachHangWithName(this.CTTextBoxTimKhachHangTheoTen.Texts);
                LoadGrid();
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CTButtonThemKhachHang_Click(object sender, EventArgs e)
        {
            LoadGrid();
            FormBackground formBackground = new FormBackground(formMain);
            try
            {
                using (FormThemKhachHang formThemKhachHang = new FormThemKhachHang(this))
                {
                    formBackground.Owner = formMain;
                    formBackground.Show();
                    formThemKhachHang.Owner = formBackground;
                    formThemKhachHang.ShowDialog();
                    formBackground.Dispose();
                }
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp =
                        new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);

                    int row = grid.Rows.Count;
                    int col = grid.Columns.Count;

                    // Header
                    for (int i = 1; i < col - 2 + 1; i++)
                    {
                        if (i == 1) continue;
                        XcelApp.Cells[1, i - 1] = grid.Columns[i - 1].HeaderText;
                    }

                    // Data
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 1; j < col - 2; j++)
                        {
                            XcelApp.Cells[i + 2, j] = grid.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    XcelApp.Columns.AutoFit();
                    XcelApp.Visible = true;
                }
                else
                {
                    string mess = "Chưa có dữ liệu trong bảng!";
                    CTMessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0)
            {
                // Sửa
                if (x == 7)
                {
                    FormBackground formBackground = new FormBackground(formMain);
                    try
                    {
                        using (FormSuaKhachHang formSuaKhachHang =
                            new FormSuaKhachHang(
                                KhachHangBUS.Instance.FindKhachHang(grid.Rows[y].Cells[1].Value.ToString()),
                                this))
                        {
                            formBackground.Owner = formMain;
                            formBackground.Show();
                            formSuaKhachHang.Owner = formBackground;
                            formSuaKhachHang.ShowDialog();
                            formBackground.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        formBackground.Dispose();
                    }
                }

                // Xóa
                if (x == 8)
                {
                    if (taiKhoan != null && taiKhoan.CapDoQuyen == 1)
                    {
                        CTMessageBox.Show("Bạn không có quyền thực hiện thao tác này.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult dialogresult = CTMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogresult == DialogResult.Yes)
                    {
                        try
                        {
                            KhachHangBUS.Instance.RemoveKH(
                                KhachHangBUS.Instance.FindKhachHang(grid.Rows[y].Cells[1].Value.ToString()));
                            LoadAllGrid();
                            CTMessageBox.Show("Xóa thông tin thành công.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void CTTextBoxTimKhachHangTheoTen_Load(object sender, EventArgs e)
        {
        }

        private void CTTextBoxTimKhachHangTheoTen__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxFindName = sender as TextBox;
            if (textBoxFindName.Focused == false)
            {
                LoadAllGrid();
                return;
            }

            // Tìm theo tên/CCCD -> reset khoảng ngày
            tuNgayLoc = null;
            denNgayLoc = null;

            this.khachHangs = KhachHangBUS.Instance.FindKhachHangWithName(textBoxFindName.Text);
            LoadGrid();
        }

        private void grid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            int[] arrX = { 1, 5, 6 };
            bool isExists = false;

            if (Array.IndexOf(arrX, x) != -1)
                isExists = true;

            if (y >= 0 && x == 7 || y >= 0 && x == 8 || y == -1 && isExists)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        private void grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            grid.Cursor = Cursors.Default;
        }

        /// <summary>
        /// In danh sách khách hàng dựa trên list khachHangs hiện tại
        /// (toàn bộ / theo tìm kiếm / theo khoảng ngày thuê).
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (khachHangs == null || khachHangs.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<KhachHangReportDTO> dataReport = new List<KhachHangReportDTO>();
                int stt = 1;

                foreach (var kh in khachHangs)
                {
                    dataReport.Add(new KhachHangReportDTO
                    {
                        STT = stt++,
                        MaKH = kh.MaKH,
                        TenKH = kh.TenKH,
                        CCCD_Passport = kh.CCCD_Passport,
                        SDT = kh.SDT,
                        QuocTich = kh.QuocTich,
                        GioiTinh = kh.GioiTinh
                    });
                }

                // Tiêu đề hiển thị trên report
                string tieuDe;
                if (tuNgayLoc.HasValue && denNgayLoc.HasValue)
                {
                    tieuDe = string.Format("DANH SÁCH KHÁCH HÀNG TỪ {0:dd/MM/yyyy} ĐẾN {1:dd/MM/yyyy}",
                                           tuNgayLoc.Value, denNgayLoc.Value);
                }
                else
                {
                    tieuDe = "DANH SÁCH KHÁCH HÀNG";
                }

                rptDanhSachKhachHang rpt = new rptDanhSachKhachHang();
                rpt.SetDataSource(dataReport);

                // Parameter pKhoangThoiGian trong Crystal Report
                rpt.SetParameterValue("pKhoangThoiGian", tieuDe);

                fReport frm = new fReport();
                frm.crvReport.ReportSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message);
            }
        }

        /// <summary>
        /// Lọc khách hàng theo khoảng ngày thuê (PhieuThue.NgPT).
        /// </summary>
        private void btnLocTheoNgay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                if (denNgay < tuNgay)
                {
                    CTMessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tuNgayLoc = tuNgay;
                denNgayLoc = denNgay;

                khachHangs = KhachHangBUS.Instance.GetKhachHangsTheoKhoangNgayThue(tuNgay, denNgay);
                LoadGrid();

                if (khachHangs == null || khachHangs.Count == 0)
                {
                    CTMessageBox.Show("Không có khách hàng nào trong khoảng thời gian này.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.\n" + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // Bỏ lọc -> load lại toàn bộ khách hàng
                LoadAllGrid();

                // Reset biến lưu ngày lọc (để in report không theo khoảng ngày)
                tuNgayLoc = null;
                denNgayLoc = null;

                // Reset lại UI DateTimePicker về mặc định
                dtpDenNgay.Value = DateTime.Today;
                dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                
            }
            catch (Exception ex)
            {
                CTMessageBox.Show("Đã xảy ra lỗi khi bỏ lọc.\n" + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
