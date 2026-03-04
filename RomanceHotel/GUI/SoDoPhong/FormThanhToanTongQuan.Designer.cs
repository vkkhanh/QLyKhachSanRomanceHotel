using System;
using System.Drawing;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    partial class FormThanhToanTongQuan
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private Label lblMaCTDP;
        private TextBox txtMaCTDP;
        private Label lblTenKH;
        private TextBox txtTenKH;
        private Label lblMaPhong;
        private TextBox txtMaPhong;
        private Label lblLoaiPhong;
        private TextBox txtLoaiPhong;
        private Label lblNhanVien;
        private TextBox txtNhanVien;
        private Label lblCheckIn;
        private TextBox txtCheckIn;
        private Label lblCheckOut;
        private TextBox txtCheckOut;
        private Label lblHinhThuc;
        private TextBox txtHinhThuc;
        private Label lblSoNgayGio;
        private TextBox txtSoNgayGio;

        private DataGridView dataGridViewDV;

        private Label lblTienPhongTitle;
        private Label lblTienPhong;
        private Label lblTienDVTitle;
        private Label lblTienDV;
        private Label lblTongTienTitle;
        private Label lblTongTien;

        private Button btnTienMat;
        private Button btnQR;
        private Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new Label();
            this.lblMaCTDP = new Label();
            this.txtMaCTDP = new TextBox();
            this.lblTenKH = new Label();
            this.txtTenKH = new TextBox();
            this.lblMaPhong = new Label();
            this.txtMaPhong = new TextBox();
            this.lblLoaiPhong = new Label();
            this.txtLoaiPhong = new TextBox();
            this.lblNhanVien = new Label();
            this.txtNhanVien = new TextBox();
            this.lblCheckIn = new Label();
            this.txtCheckIn = new TextBox();
            this.lblCheckOut = new Label();
            this.txtCheckOut = new TextBox();
            this.lblHinhThuc = new Label();
            this.txtHinhThuc = new TextBox();
            this.lblSoNgayGio = new Label();
            this.txtSoNgayGio = new TextBox();
            this.dataGridViewDV = new DataGridView();
            this.lblTienPhongTitle = new Label();
            this.lblTienPhong = new Label();
            this.lblTienDVTitle = new Label();
            this.lblTienDV = new Label();
            this.lblTongTienTitle = new Label();
            this.lblTongTien = new Label();
            this.btnTienMat = new Button();
            this.btnQR = new Button();
            this.btnDong = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDV)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.ClientSize = new Size(900, 650);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "Tóm tắt giao dịch";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // HEADER
            lblHeader.Text = "TÓM TẮT GIAO DỊCH (HÓA ĐƠN SƠ BỘ)";
            lblHeader.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(70, 140, 140);
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(220, 10);

            int leftColX = 30;
            int rightColX = 450;
            int rowY = 60;
            int rowStep = 35;
            int textWidth = 230;


            // Mã CTDP
            lblMaCTDP.Text = "Mã CTDP:";
            lblMaCTDP.Location = new Point(leftColX, rowY);
            lblMaCTDP.AutoSize = true;
            txtMaCTDP.Location = new Point(leftColX + 100, rowY - 3);
            txtMaCTDP.Width = textWidth;
            txtMaCTDP.ReadOnly = true;


            // Tên KH
            rowY += rowStep;
            lblTenKH.Text = "Khách hàng:";
            lblTenKH.Location = new Point(leftColX, rowY);
            lblTenKH.AutoSize = true;
            txtTenKH.Location = new Point(leftColX + 100, rowY - 3);
            txtTenKH.Width = textWidth;
            txtTenKH.ReadOnly = true;

            // Mã phòng
            rowY += rowStep;
            lblMaPhong.Text = "Phòng:";
            lblMaPhong.Location = new Point(leftColX, rowY);
            lblMaPhong.AutoSize = true;
            txtMaPhong.Location = new Point(leftColX + 100, rowY - 3);
            txtMaPhong.Width = textWidth;
            txtMaPhong.ReadOnly = true;

            // Loại phòng
            rowY += rowStep;
            lblLoaiPhong.Text = "Loại phòng:";
            lblLoaiPhong.Location = new Point(leftColX, rowY);
            lblLoaiPhong.AutoSize = true;
            txtLoaiPhong.Location = new Point(leftColX + 100, rowY - 3);
            txtLoaiPhong.Width = textWidth;
            txtLoaiPhong.ReadOnly = true;

            // Nhân viên
            rowY += rowStep;
            lblNhanVien.Text = "Nhân viên:";
            lblNhanVien.Location = new Point(leftColX, rowY);
            lblNhanVien.AutoSize = true;
            txtNhanVien.Location = new Point(leftColX + 100, rowY - 3);
            txtNhanVien.Width = textWidth;
            txtNhanVien.ReadOnly = true;

            // Cột phải - CheckIn
            int ry = 60;
            lblCheckIn.Text = "Check-in:";
            lblCheckIn.Location = new Point(rightColX, ry);
            lblCheckIn.AutoSize = true;
            txtCheckIn.Location = new Point(rightColX + 100, ry - 3);
            txtCheckIn.Width = textWidth;
            txtCheckIn.ReadOnly = true;

            // CheckOut
            ry += rowStep;
            lblCheckOut.Text = "Check-out:";
            lblCheckOut.Location = new Point(rightColX, ry);
            lblCheckOut.AutoSize = true;
            txtCheckOut.Location = new Point(rightColX + 100, ry - 3);
            txtCheckOut.Width = textWidth;
            txtCheckOut.ReadOnly = true;

            // Hình thức
            ry += rowStep;
            lblHinhThuc.Text = "Hình thức:";
            lblHinhThuc.Location = new Point(rightColX, ry);
            lblHinhThuc.AutoSize = true;
            txtHinhThuc.Location = new Point(rightColX + 100, ry - 3);
            txtHinhThuc.Width = textWidth;
            txtHinhThuc.ReadOnly = true;

            // Số ngày/giờ
            ry += rowStep;
            lblSoNgayGio.Text = "Thời lượng:";
            lblSoNgayGio.Location = new Point(rightColX, ry);
            lblSoNgayGio.AutoSize = true;
            txtSoNgayGio.Location = new Point(rightColX + 100, ry - 3);
            txtSoNgayGio.Width = textWidth;
            txtSoNgayGio.ReadOnly = true;

            // DATA GRID DỊCH VỤ
            dataGridViewDV.Location = new Point(30, 230);
            dataGridViewDV.Size = new Size(840, 260);
            dataGridViewDV.AllowUserToAddRows = false;
            dataGridViewDV.AllowUserToDeleteRows = false;
            dataGridViewDV.ReadOnly = true;
            dataGridViewDV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewDV.Columns.Add("TenDV", "Dịch vụ / Hạng mục");
            dataGridViewDV.Columns.Add("DonGia", "Đơn giá");
            dataGridViewDV.Columns.Add("SoLuong", "Số lượng");
            dataGridViewDV.Columns.Add("ThanhTien", "Thành tiền");

            // TIỀN PHÒNG, TIỀN DV, TỔNG TIỀN
            int bottomY = 510;

            lblTienPhongTitle.Text = "Tiền phòng:";
            lblTienPhongTitle.Location = new Point(30, bottomY);
            lblTienPhongTitle.AutoSize = true;
            lblTienPhong.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTienPhong.Location = new Point(150, bottomY);
            lblTienPhong.AutoSize = true;
            lblTienPhong.Text = "0 VNĐ";

            lblTienDVTitle.Text = "Tiền dịch vụ:";
            lblTienDVTitle.Location = new Point(30, bottomY + 30);
            lblTienDVTitle.AutoSize = true;
            lblTienDV.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTienDV.Location = new Point(150, bottomY + 30);
            lblTienDV.AutoSize = true;
            lblTienDV.Text = "0 VNĐ";

            lblTongTienTitle.Text = "TỔNG CỘNG:";
            lblTongTienTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTongTienTitle.Location = new Point(550, bottomY + 15);
            lblTongTienTitle.AutoSize = true;

            lblTongTien.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(255, 80, 80);
            lblTongTien.Location = new Point(680, bottomY + 12);
            lblTongTien.AutoSize = true;
            lblTongTien.Text = "0 VNĐ";

            // BUTTONS
            btnTienMat.Text = "Thanh toán tiền mặt";
            btnTienMat.Size = new Size(180, 40);
            btnTienMat.Location = new Point(260, 570);
            btnTienMat.BackColor = Color.FromArgb(88, 188, 188);
            btnTienMat.ForeColor = Color.White;
            btnTienMat.FlatStyle = FlatStyle.Flat;
            btnTienMat.Font = new Font("Segoe UI", 12, FontStyle.Bold);   // ← Tăng chữ
            btnTienMat.Click += new EventHandler(btnTienMat_Click);

            btnQR.Text = "Thanh toán VietQR";
            btnQR.Size = new Size(180, 40);
            btnQR.Location = new Point(460, 570);
            btnQR.BackColor = Color.FromArgb(255, 140, 0);
            btnQR.ForeColor = Color.White;
            btnQR.FlatStyle = FlatStyle.Flat;
            btnQR.Font = new Font("Segoe UI", 12, FontStyle.Bold);        // ← Tăng chữ
            btnQR.Click += new EventHandler(btnQR_Click);

            btnDong.Text = "Đóng";
            btnDong.Size = new Size(100, 35);
            btnDong.Location = new Point(400, 615);
            btnDong.BackColor = Color.LightGray;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 11, FontStyle.Regular);   // ← Chữ lớn hơn
            btnDong.Click += new EventHandler(btnDong_Click);


            // ADD CONTROLS
            this.Controls.Add(lblHeader);
            this.Controls.Add(lblMaCTDP);
            this.Controls.Add(txtMaCTDP);
            this.Controls.Add(lblTenKH);
            this.Controls.Add(txtTenKH);
            this.Controls.Add(lblMaPhong);
            this.Controls.Add(txtMaPhong);
            this.Controls.Add(lblLoaiPhong);
            this.Controls.Add(txtLoaiPhong);
            this.Controls.Add(lblNhanVien);
            this.Controls.Add(txtNhanVien);
            this.Controls.Add(lblCheckIn);
            this.Controls.Add(txtCheckIn);
            this.Controls.Add(lblCheckOut);
            this.Controls.Add(txtCheckOut);
            this.Controls.Add(lblHinhThuc);
            this.Controls.Add(txtHinhThuc);
            this.Controls.Add(lblSoNgayGio);
            this.Controls.Add(txtSoNgayGio);
            this.Controls.Add(dataGridViewDV);
            this.Controls.Add(lblTienPhongTitle);
            this.Controls.Add(lblTienPhong);
            this.Controls.Add(lblTienDVTitle);
            this.Controls.Add(lblTienDV);
            this.Controls.Add(lblTongTienTitle);
            this.Controls.Add(lblTongTien);
            this.Controls.Add(btnTienMat);
            this.Controls.Add(btnQR);
            this.Controls.Add(btnDong);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
