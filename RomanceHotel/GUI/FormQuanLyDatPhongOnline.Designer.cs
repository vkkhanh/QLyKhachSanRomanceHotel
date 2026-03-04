namespace RomanceHotel.GUI
{
    partial class FormQuanLyDatPhongOnline
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.ComboBox comboBoxTrangThai;
        private System.Windows.Forms.Button buttonLamMoi;
        private System.Windows.Forms.Button buttonDaGoi;
        private System.Windows.Forms.Button buttonDaLapPhieu;
        private System.Windows.Forms.Button buttonDaHuy;
        private System.Windows.Forms.DataGridView dataGridViewYeuCau;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonDaHuy = new System.Windows.Forms.Button();
            this.buttonDaLapPhieu = new System.Windows.Forms.Button();
            this.buttonDaGoi = new System.Windows.Forms.Button();
            this.buttonLamMoi = new System.Windows.Forms.Button();
            this.comboBoxTrangThai = new System.Windows.Forms.ComboBox();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridViewYeuCau = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYeuCau)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.panelTop.Controls.Add(this.buttonDaHuy);
            this.panelTop.Controls.Add(this.buttonDaLapPhieu);
            this.panelTop.Controls.Add(this.buttonDaGoi);
            this.panelTop.Controls.Add(this.buttonLamMoi);
            this.panelTop.Controls.Add(this.comboBoxTrangThai);
            this.panelTop.Controls.Add(this.labelTrangThai);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.panelTop.Size = new System.Drawing.Size(1029, 78);
            this.panelTop.TabIndex = 0;
            // 
            // buttonDaHuy
            // 
            this.buttonDaHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDaHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.buttonDaHuy.FlatAppearance.BorderSize = 0;
            this.buttonDaHuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.buttonDaHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDaHuy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonDaHuy.ForeColor = System.Drawing.Color.White;
            this.buttonDaHuy.Location = new System.Drawing.Point(910, 22);
            this.buttonDaHuy.Name = "buttonDaHuy";
            this.buttonDaHuy.Size = new System.Drawing.Size(101, 34);
            this.buttonDaHuy.TabIndex = 6;
            this.buttonDaHuy.Text = "Đã hủy";
            this.buttonDaHuy.UseVisualStyleBackColor = false;
            this.buttonDaHuy.Click += new System.EventHandler(this.buttonDaHuy_Click);
            // 
            // buttonDaLapPhieu
            // 
            this.buttonDaLapPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDaLapPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(184)))), ((int)(((byte)(118)))));
            this.buttonDaLapPhieu.FlatAppearance.BorderSize = 0;
            this.buttonDaLapPhieu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(168)))), ((int)(((byte)(106)))));
            this.buttonDaLapPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDaLapPhieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonDaLapPhieu.ForeColor = System.Drawing.Color.White;
            this.buttonDaLapPhieu.Location = new System.Drawing.Point(770, 22);
            this.buttonDaLapPhieu.Name = "buttonDaLapPhieu";
            this.buttonDaLapPhieu.Size = new System.Drawing.Size(134, 34);
            this.buttonDaLapPhieu.TabIndex = 5;
            this.buttonDaLapPhieu.Text = "Đã lập phiếu thuê";
            this.buttonDaLapPhieu.UseVisualStyleBackColor = false;
            this.buttonDaLapPhieu.Click += new System.EventHandler(this.buttonDaLapPhieu_Click);
            // 
            // buttonDaGoi
            // 
            this.buttonDaGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDaGoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(163)))), ((int)(((byte)(201)))));
            this.buttonDaGoi.FlatAppearance.BorderSize = 0;
            this.buttonDaGoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(149)))), ((int)(((byte)(190)))));
            this.buttonDaGoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDaGoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonDaGoi.ForeColor = System.Drawing.Color.White;
            this.buttonDaGoi.Location = new System.Drawing.Point(630, 22);
            this.buttonDaGoi.Name = "buttonDaGoi";
            this.buttonDaGoi.Size = new System.Drawing.Size(134, 34);
            this.buttonDaGoi.TabIndex = 4;
            this.buttonDaGoi.Text = "Đã liên hệ";
            this.buttonDaGoi.UseVisualStyleBackColor = false;
            this.buttonDaGoi.Click += new System.EventHandler(this.buttonDaGoi_Click);
            // 
            // buttonLamMoi
            // 
            this.buttonLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLamMoi.BackColor = System.Drawing.Color.White;
            this.buttonLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(195)))), ((int)(((byte)(215)))));
            this.buttonLamMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.buttonLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(105)))), ((int)(((byte)(130)))));
            this.buttonLamMoi.Location = new System.Drawing.Point(540, 22);
            this.buttonLamMoi.Name = "buttonLamMoi";
            this.buttonLamMoi.Size = new System.Drawing.Size(84, 34);
            this.buttonLamMoi.TabIndex = 3;
            this.buttonLamMoi.Text = "Làm mới";
            this.buttonLamMoi.UseVisualStyleBackColor = false;
            this.buttonLamMoi.Click += new System.EventHandler(this.buttonLamMoi_Click);
            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxTrangThai.FormattingEnabled = true;
            this.comboBoxTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa liên hệ",
            "Đã liên hệ",
            "Đã lập phiếu thuê",
            "Đã hủy"});
            this.comboBoxTrangThai.Location = new System.Drawing.Point(326, 27);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(182, 25);
            this.comboBoxTrangThai.TabIndex = 2;
            this.comboBoxTrangThai.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrangThai_SelectedIndexChanged);
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.labelTrangThai.Location = new System.Drawing.Point(237, 30);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(79, 19);
            this.labelTrangThai.TabIndex = 1;
            this.labelTrangThai.Text = "Trạng thái:";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.labelTitle.Location = new System.Drawing.Point(18, 24);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(214, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Quản lý đặt phòng online";
            // 
            // dataGridViewYeuCau
            // 
            this.dataGridViewYeuCau.AllowUserToAddRows = false;
            this.dataGridViewYeuCau.AllowUserToDeleteRows = false;
            this.dataGridViewYeuCau.AllowUserToResizeRows = false;
            this.dataGridViewYeuCau.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewYeuCau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewYeuCau.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewYeuCau.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(163)))), ((int)(((byte)(201)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(163)))), ((int)(((byte)(201)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewYeuCau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewYeuCau.ColumnHeadersHeight = 38;
            this.dataGridViewYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            // 👉 Cho cột auto fit theo chiều ngang form
            this.dataGridViewYeuCau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(70)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewYeuCau.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewYeuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewYeuCau.EnableHeadersVisualStyles = false;
            this.dataGridViewYeuCau.Location = new System.Drawing.Point(0, 78);
            this.dataGridViewYeuCau.MultiSelect = false;
            this.dataGridViewYeuCau.Name = "dataGridViewYeuCau";
            this.dataGridViewYeuCau.ReadOnly = true;
            this.dataGridViewYeuCau.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewYeuCau.RowHeadersVisible = false;
            this.dataGridViewYeuCau.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(248)))));
            this.dataGridViewYeuCau.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewYeuCau.RowTemplate.Height = 28;
            this.dataGridViewYeuCau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewYeuCau.Size = new System.Drawing.Size(1029, 455);
            this.dataGridViewYeuCau.TabIndex = 1;
            this.dataGridViewYeuCau.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewYeuCau_CellDoubleClick);
            // 
            // FormQuanLyDatPhongOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 533);
            this.Controls.Add(this.dataGridViewYeuCau);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuanLyDatPhongOnline";
            this.Text = "FormQuanLyDatPhongOnline";
            this.Load += new System.EventHandler(this.FormQuanLyDatPhongOnline_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYeuCau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
