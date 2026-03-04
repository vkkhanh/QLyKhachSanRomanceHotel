using RomanceHotel.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormQuanLyDatPhongOnline : Form
    {
        private FormMain formMain;
        private TaiKhoan taiKhoan;
        private HotelDTO db;   // DbContext EF

        public FormQuanLyDatPhongOnline(FormMain formMain, TaiKhoan taiKhoan)
        {
            this.formMain = formMain;
            this.taiKhoan = taiKhoan;

            InitializeComponent();
            db = new HotelDTO();
        }

        private void FormQuanLyDatPhongOnline_Load(object sender, EventArgs e)
        {
            comboBoxTrangThai.SelectedIndex = 0; // Tất cả
            LoadDanhSachYeuCau();
        }

        private void LoadDanhSachYeuCau(string trangThai = "Tất cả")
        {
            try
            {
                var query = db.DatPhongOnlines.AsQueryable();

                if (trangThai != "Tất cả")
                {
                    query = query.Where(x => x.TrangThai == trangThai);
                }

                var list = query
                    .OrderByDescending(x => x.NgayTao)
                    .ToList();

                dataGridViewYeuCau.DataSource = list;

                DinhDangDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách yêu cầu đặt phòng:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangDataGridView()
        {
            if (dataGridViewYeuCau.Columns.Count == 0) return;

            // Đổi header text
            dataGridViewYeuCau.Columns["MaYeuCau"].HeaderText = "Mã";
            dataGridViewYeuCau.Columns["HoTen"].HeaderText = "Họ tên";
            dataGridViewYeuCau.Columns["SoDienThoai"].HeaderText = "SĐT";
            dataGridViewYeuCau.Columns["Email"].HeaderText = "Email";
            dataGridViewYeuCau.Columns["SoKhach"].HeaderText = "Số khách";
            dataGridViewYeuCau.Columns["NgayNhan"].HeaderText = "Ngày nhận";
            dataGridViewYeuCau.Columns["NgayTra"].HeaderText = "Ngày trả";
            dataGridViewYeuCau.Columns["GioNhan"].HeaderText = "Giờ nhận";
            dataGridViewYeuCau.Columns["MaLPH"].HeaderText = "Loại phòng";
            dataGridViewYeuCau.Columns["YeuCauThem"].HeaderText = "Yêu cầu thêm";
            dataGridViewYeuCau.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dataGridViewYeuCau.Columns["TrangThai"].HeaderText = "Trạng thái";

            // Ẩn navigation properties nếu có
            if (dataGridViewYeuCau.Columns.Contains("HotelDTO"))
                dataGridViewYeuCau.Columns["HotelDTO"].Visible = false;

            // Định dạng ngày
            if (dataGridViewYeuCau.Columns["NgayNhan"] != null)
                dataGridViewYeuCau.Columns["NgayNhan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dataGridViewYeuCau.Columns["NgayTra"] != null)
                dataGridViewYeuCau.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dataGridViewYeuCau.Columns["NgayTao"] != null)
                dataGridViewYeuCau.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            // 👉 Cho DGV tự co vừa form
            dataGridViewYeuCau.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Dùng FillWeight để chia tỉ lệ chiều rộng cột (không dùng Width nữa)
            void SetFill(string colName, float weight)
            {
                if (dataGridViewYeuCau.Columns[colName] != null)
                    dataGridViewYeuCau.Columns[colName].FillWeight = weight;
            }

            // Tổng khoảng ~1000 (nhưng FillWeight là tỉ lệ, không cần chính xác)
            SetFill("MaYeuCau", 60);   // nhỏ
            SetFill("HoTen", 140);
            SetFill("SoDienThoai", 90);
            SetFill("Email", 140);
            SetFill("SoKhach", 60);
            SetFill("NgayNhan", 90);
            SetFill("NgayTra", 90);
            SetFill("GioNhan", 70);
            SetFill("MaLPH", 80);
            SetFill("TrangThai", 110);
            SetFill("NgayTao", 120);
            SetFill("YeuCauThem", 200);  // text dài nên cho rộng hơn

            // Font to hơn
            dataGridViewYeuCau.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dataGridViewYeuCau.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);

            dataGridViewYeuCau.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewYeuCau.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void comboBoxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trangThai = comboBoxTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            LoadDanhSachYeuCau(trangThai);
        }

        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            comboBoxTrangThai.SelectedIndex = 0;
            LoadDanhSachYeuCau();
        }

        private int? GetMaYeuCauDangChon()
        {
            if (dataGridViewYeuCau.CurrentRow == null)
                return null;

            try
            {
                return Convert.ToInt32(dataGridViewYeuCau.CurrentRow.Cells["MaYeuCau"].Value);
            }
            catch
            {
                return null;
            }
        }

        private DatPhongOnline GetYeuCauDangChon()
        {
            var maYeuCau = GetMaYeuCauDangChon();
            if (!maYeuCau.HasValue) return null;

            return db.DatPhongOnlines.Find(maYeuCau.Value);
        }

        private void buttonDaGoi_Click(object sender, EventArgs e)
        {
            var yc = GetYeuCauDangChon();
            if (yc == null)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để cập nhật.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (yc.TrangThai == "Đã liên hệ")
            {
                var res = MessageBox.Show("Yêu cầu này đã được đánh dấu 'Đã liên hệ'. Bạn muốn cập nhật lại không?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;
            }

            if (yc.TrangThai == "Đã hủy")
            {
                var res = MessageBox.Show("Yêu cầu đã được đánh dấu 'Đã hủy'. Bạn có chắc muốn chuyển sang 'Đã liên hệ'?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;
            }

            try
            {
                yc.TrangThai = "Đã liên hệ";
                db.SaveChanges();

                MessageBox.Show("Đã cập nhật trạng thái 'Đã liên hệ'.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachYeuCau(comboBoxTrangThai.SelectedItem?.ToString() ?? "Tất cả");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDaHuy_Click(object sender, EventArgs e)
        {
            var yc = GetYeuCauDangChon();
            if (yc == null)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để cập nhật.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (yc.TrangThai == "Đã lập phiếu thuê")
            {
                var res = MessageBox.Show("Yêu cầu này đã được đánh dấu 'Đã lập phiếu thuê'. Bạn có chắc muốn chuyển sang 'Đã hủy'?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn đánh dấu yêu cầu này là 'Đã hủy'?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            try
            {
                yc.TrangThai = "Đã hủy";
                db.SaveChanges();

                MessageBox.Show("Đã cập nhật trạng thái 'Đã hủy'.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachYeuCau(comboBoxTrangThai.SelectedItem?.ToString() ?? "Tất cả");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDaLapPhieu_Click(object sender, EventArgs e)
        {
            var yc = GetYeuCauDangChon();
            if (yc == null)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để cập nhật.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (yc.TrangThai == "Đã lập phiếu thuê")
            {
                var res = MessageBox.Show("Yêu cầu này đã được đánh dấu 'Đã lập phiếu thuê'. Bạn muốn cập nhật lại không?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;
            }

            if (yc.TrangThai == "Đã hủy")
            {
                var res = MessageBox.Show("Yêu cầu đang ở trạng thái 'Đã hủy'. Bạn có chắc muốn chuyển sang 'Đã lập phiếu thuê'?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No) return;
            }

            try
            {
                yc.TrangThai = "Đã lập phiếu thuê";
                db.SaveChanges();

                MessageBox.Show("Đã cập nhật trạng thái 'Đã lập phiếu thuê'.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachYeuCau(comboBoxTrangThai.SelectedItem?.ToString() ?? "Tất cả");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái:\n" + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Double-click vào 1 dòng để xem thông tin chi tiết
        private void dataGridViewYeuCau_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridViewYeuCau.CurrentRow == null) return;

            var row = dataGridViewYeuCau.CurrentRow;
            var sb = new StringBuilder();

            string GetValue(string colName)
            {
                return dataGridViewYeuCau.Columns.Contains(colName) &&
                       row.Cells[colName].Value != null
                    ? row.Cells[colName].Value.ToString()
                    : "";
            }

            sb.AppendLine($"Mã yêu cầu: {GetValue("MaYeuCau")}");
            sb.AppendLine($"Họ tên: {GetValue("HoTen")}");
            sb.AppendLine($"Số điện thoại: {GetValue("SoDienThoai")}");
            sb.AppendLine($"Email: {GetValue("Email")}");
            sb.AppendLine($"Số khách: {GetValue("SoKhach")}");
            sb.AppendLine($"Ngày nhận: {GetValue("NgayNhan")}");
            sb.AppendLine($"Ngày trả: {GetValue("NgayTra")}");
            sb.AppendLine($"Giờ nhận: {GetValue("GioNhan")}");
            sb.AppendLine($"Loại phòng: {GetValue("MaLPH")}");
            sb.AppendLine($"Trạng thái: {GetValue("TrangThai")}");
            sb.AppendLine();
            sb.AppendLine("Yêu cầu thêm:");
            sb.AppendLine(GetValue("YeuCauThem"));

            MessageBox.Show(sb.ToString(), "Thông tin yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.OnFormClosed(e);
        }
    }
}
