namespace RomanceHotel.GUI.ThongKe
{
    partial class FormBaoCaoDoanhThu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblKhoangThoiGian;

        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnApDung;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Button btnDong;

        private System.Windows.Forms.TabControl tabControlBaoCao;
        private System.Windows.Forms.TabPage tabPagePhong;
        private System.Windows.Forms.TabPage tabPageDichVu;

        // Tab phòng
        private System.Windows.Forms.Panel panelSummaryPhong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongDoanhThuPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongLuotThue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.DataGridView dgvBaoCaoPhong;

        // Tab dịch vụ
        private System.Windows.Forms.Panel panelSummaryDichVu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTongDoanhThuDichVu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTongLanSuDungDV;
        private System.Windows.Forms.DataGridView dgvBaoCaoDichVu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblKhoangThoiGian = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnApDung = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlBaoCao = new System.Windows.Forms.TabControl();
            this.tabPagePhong = new System.Windows.Forms.TabPage();
            this.dgvBaoCaoPhong = new System.Windows.Forms.DataGridView();
            this.panelSummaryPhong = new System.Windows.Forms.Panel();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTongLuotThue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongDoanhThuPhong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageDichVu = new System.Windows.Forms.TabPage();
            this.dgvBaoCaoDichVu = new System.Windows.Forms.DataGridView();
            this.panelSummaryDichVu = new System.Windows.Forms.Panel();
            this.lblTongLanSuDungDV = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTongDoanhThuDichVu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.tabControlBaoCao.SuspendLayout();
            this.tabPagePhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoPhong)).BeginInit();
            this.panelSummaryPhong.SuspendLayout();
            this.tabPageDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoDichVu)).BeginInit();
            this.panelSummaryDichVu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(119)))), ((int)(((byte)(148)))));
            this.panelTop.Controls.Add(this.lblKhoangThoiGian);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblKhoangThoiGian
            // 
            this.lblKhoangThoiGian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhoangThoiGian.AutoSize = true;
            this.lblKhoangThoiGian.ForeColor = System.Drawing.Color.White;
            this.lblKhoangThoiGian.Location = new System.Drawing.Point(700, 27);
            this.lblKhoangThoiGian.Name = "lblKhoangThoiGian";
            this.lblKhoangThoiGian.Size = new System.Drawing.Size(189, 17);
            this.lblKhoangThoiGian.TabIndex = 1;
            this.lblKhoangThoiGian.Text = "Từ ngày ... đến ngày ...";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(274, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO DOANH THU";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.btnDong);
            this.panelFilter.Controls.Add(this.btnInBaoCao);
            this.panelFilter.Controls.Add(this.btnApDung);
            this.panelFilter.Controls.Add(this.dtpTo);
            this.panelFilter.Controls.Add(this.dtpFrom);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 70);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1200, 70);
            this.panelFilter.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.LightGray;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Location = new System.Drawing.Point(1080, 20);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 30);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(119)))), ((int)(((byte)(148)))));
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnInBaoCao.Location = new System.Drawing.Point(970, 20);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(100, 30);
            this.btnInBaoCao.TabIndex = 5;
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // btnApDung
            // 
            this.btnApDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(119)))), ((int)(((byte)(148)))));
            this.btnApDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApDung.ForeColor = System.Drawing.Color.White;
            this.btnApDung.Location = new System.Drawing.Point(430, 20);
            this.btnApDung.Name = "btnApDung";
            this.btnApDung.Size = new System.Drawing.Size(90, 30);
            this.btnApDung.TabIndex = 4;
            this.btnApDung.Text = "Áp dụng";
            this.btnApDung.UseVisualStyleBackColor = false;
            this.btnApDung.Click += new System.EventHandler(this.btnApDung_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(270, 25);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 25);
            this.dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(80, 25);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 25);
            this.dtpFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ:";
            // 
            // tabControlBaoCao
            // 
            this.tabControlBaoCao.Controls.Add(this.tabPagePhong);
            this.tabControlBaoCao.Controls.Add(this.tabPageDichVu);
            this.tabControlBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBaoCao.Location = new System.Drawing.Point(0, 140);
            this.tabControlBaoCao.Name = "tabControlBaoCao";
            this.tabControlBaoCao.SelectedIndex = 0;
            this.tabControlBaoCao.Size = new System.Drawing.Size(1200, 560);
            this.tabControlBaoCao.TabIndex = 2;
            // 
            // tabPagePhong
            // 
            this.tabPagePhong.Controls.Add(this.dgvBaoCaoPhong);
            this.tabPagePhong.Controls.Add(this.panelSummaryPhong);
            this.tabPagePhong.Location = new System.Drawing.Point(4, 26);
            this.tabPagePhong.Name = "tabPagePhong";
            this.tabPagePhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhong.Size = new System.Drawing.Size(1192, 530);
            this.tabPagePhong.TabIndex = 0;
            this.tabPagePhong.Text = "Doanh thu phòng";
            this.tabPagePhong.UseVisualStyleBackColor = true;
            // 
            // dgvBaoCaoPhong
            // 
            this.dgvBaoCaoPhong.AllowUserToAddRows = false;
            this.dgvBaoCaoPhong.AllowUserToDeleteRows = false;
            this.dgvBaoCaoPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCaoPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoPhong.Location = new System.Drawing.Point(3, 83);
            this.dgvBaoCaoPhong.Name = "dgvBaoCaoPhong";
            this.dgvBaoCaoPhong.ReadOnly = true;
            this.dgvBaoCaoPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoPhong.Size = new System.Drawing.Size(1186, 444);
            this.dgvBaoCaoPhong.TabIndex = 1;
            // 
            // panelSummaryPhong
            // 
            this.panelSummaryPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelSummaryPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummaryPhong.Controls.Add(this.lblSoPhong);
            this.panelSummaryPhong.Controls.Add(this.label5);
            this.panelSummaryPhong.Controls.Add(this.lblTongLuotThue);
            this.panelSummaryPhong.Controls.Add(this.label4);
            this.panelSummaryPhong.Controls.Add(this.lblTongDoanhThuPhong);
            this.panelSummaryPhong.Controls.Add(this.label3);
            this.panelSummaryPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryPhong.Location = new System.Drawing.Point(3, 3);
            this.panelSummaryPhong.Name = "panelSummaryPhong";
            this.panelSummaryPhong.Size = new System.Drawing.Size(1186, 80);
            this.panelSummaryPhong.TabIndex = 0;
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.BackColor = System.Drawing.Color.White;
            this.lblSoPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(119)))), ((int)(((byte)(148)))));
            this.lblSoPhong.Location = new System.Drawing.Point(580, 42);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblSoPhong.Size = new System.Drawing.Size(34, 28);
            this.lblSoPhong.TabIndex = 5;
            this.lblSoPhong.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(580, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số phòng được thuê:";
            // 
            // lblTongLuotThue
            // 
            this.lblTongLuotThue.AutoSize = true;
            this.lblTongLuotThue.BackColor = System.Drawing.Color.White;
            this.lblTongLuotThue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTongLuotThue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongLuotThue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(119)))), ((int)(((byte)(148)))));
            this.lblTongLuotThue.Location = new System.Drawing.Point(300, 42);
            this.lblTongLuotThue.Name = "lblTongLuotThue";
            this.lblTongLuotThue.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblTongLuotThue.Size = new System.Drawing.Size(34, 28);
            this.lblTongLuotThue.TabIndex = 3;
            this.lblTongLuotThue.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng lượt thuê:";
            // 
            // lblTongDoanhThuPhong
            // 
            this.lblTongDoanhThuPhong.AutoSize = true;
            this.lblTongDoanhThuPhong.BackColor = System.Drawing.Color.White;
            this.lblTongDoanhThuPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTongDoanhThuPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThuPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(119)))), ((int)(((byte)(148)))));
            this.lblTongDoanhThuPhong.Location = new System.Drawing.Point(20, 42);
            this.lblTongDoanhThuPhong.Name = "lblTongDoanhThuPhong";
            this.lblTongDoanhThuPhong.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblTongDoanhThuPhong.Size = new System.Drawing.Size(34, 28);
            this.lblTongDoanhThuPhong.TabIndex = 1;
            this.lblTongDoanhThuPhong.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng doanh thu tiền phòng:";
            // 
            // tabPageDichVu
            // 
            this.tabPageDichVu.Controls.Add(this.dgvBaoCaoDichVu);
            this.tabPageDichVu.Controls.Add(this.panelSummaryDichVu);
            this.tabPageDichVu.Location = new System.Drawing.Point(4, 26);
            this.tabPageDichVu.Name = "tabPageDichVu";
            this.tabPageDichVu.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDichVu.Size = new System.Drawing.Size(1192, 530);
            this.tabPageDichVu.TabIndex = 1;
            this.tabPageDichVu.Text = "Doanh thu dịch vụ";
            this.tabPageDichVu.UseVisualStyleBackColor = true;
            // 
            // dgvBaoCaoDichVu
            // 
            this.dgvBaoCaoDichVu.AllowUserToAddRows = false;
            this.dgvBaoCaoDichVu.AllowUserToDeleteRows = false;
            this.dgvBaoCaoDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCaoDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoDichVu.Location = new System.Drawing.Point(3, 83);
            this.dgvBaoCaoDichVu.Name = "dgvBaoCaoDichVu";
            this.dgvBaoCaoDichVu.ReadOnly = true;
            this.dgvBaoCaoDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoDichVu.Size = new System.Drawing.Size(1186, 444);
            this.dgvBaoCaoDichVu.TabIndex = 1;
            // 
            // panelSummaryDichVu
            // 
            this.panelSummaryDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.panelSummaryDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummaryDichVu.Controls.Add(this.lblTongLanSuDungDV);
            this.panelSummaryDichVu.Controls.Add(this.label7);
            this.panelSummaryDichVu.Controls.Add(this.lblTongDoanhThuDichVu);
            this.panelSummaryDichVu.Controls.Add(this.label6);
            this.panelSummaryDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryDichVu.Location = new System.Drawing.Point(3, 3);
            this.panelSummaryDichVu.Name = "panelSummaryDichVu";
            this.panelSummaryDichVu.Size = new System.Drawing.Size(1186, 80);
            this.panelSummaryDichVu.TabIndex = 0;
            // 
            // lblTongLanSuDungDV
            // 
            this.lblTongLanSuDungDV.AutoSize = true;
            this.lblTongLanSuDungDV.BackColor = System.Drawing.Color.White;
            this.lblTongLanSuDungDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTongLanSuDungDV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongLanSuDungDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(130)))), ((int)(((byte)(80)))));
            this.lblTongLanSuDungDV.Location = new System.Drawing.Point(300, 42);
            this.lblTongLanSuDungDV.Name = "lblTongLanSuDungDV";
            this.lblTongLanSuDungDV.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblTongLanSuDungDV.Size = new System.Drawing.Size(34, 28);
            this.lblTongLanSuDungDV.TabIndex = 3;
            this.lblTongLanSuDungDV.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tổng số lần sử dụng dịch vụ:";
            // 
            // lblTongDoanhThuDichVu
            // 
            this.lblTongDoanhThuDichVu.AutoSize = true;
            this.lblTongDoanhThuDichVu.BackColor = System.Drawing.Color.White;
            this.lblTongDoanhThuDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTongDoanhThuDichVu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThuDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(130)))), ((int)(((byte)(80)))));
            this.lblTongDoanhThuDichVu.Location = new System.Drawing.Point(20, 42);
            this.lblTongDoanhThuDichVu.Name = "lblTongDoanhThuDichVu";
            this.lblTongDoanhThuDichVu.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.lblTongDoanhThuDichVu.Size = new System.Drawing.Size(34, 28);
            this.lblTongDoanhThuDichVu.TabIndex = 1;
            this.lblTongDoanhThuDichVu.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng doanh thu tiền dịch vụ:";
            // 
            // FormBaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControlBaoCao);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FormBaoCaoDoanhThu";
            this.Text = "Báo cáo doanh thu";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.tabControlBaoCao.ResumeLayout(false);
            this.tabPagePhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoPhong)).EndInit();
            this.panelSummaryPhong.ResumeLayout(false);
            this.panelSummaryPhong.PerformLayout();
            this.tabPageDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoDichVu)).EndInit();
            this.panelSummaryDichVu.ResumeLayout(false);
            this.panelSummaryDichVu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
