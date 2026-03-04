namespace RomanceHotel.GUI
{
    partial class FormDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.PanelBackground = new System.Windows.Forms.Panel();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.CTButtonThoat = new RomanceHotel.CTControls.CTButton();
            this.CTButtonXacNhan = new RomanceHotel.CTControls.CTButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CTTextBoxNhapLaiMatKhauMoi = new RomanceHotel.CTControls.CTTextBox();
            this.CTTextBoxMatKhauMoi = new RomanceHotel.CTControls.CTTextBox();
            this.CTTextBoxMatKhauCu = new RomanceHotel.CTControls.CTTextBox();
            this.PanelBackground.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBackground
            // 
            this.PanelBackground.BackColor = System.Drawing.Color.White;
            this.PanelBackground.Controls.Add(this.LabelTitle);
            this.PanelBackground.Controls.Add(this.CTButtonThoat);
            this.PanelBackground.Controls.Add(this.CTButtonXacNhan);
            this.PanelBackground.Controls.Add(this.panelMain);
            this.PanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBackground.Location = new System.Drawing.Point(0, 0);
            this.PanelBackground.Name = "PanelBackground";
            this.PanelBackground.Size = new System.Drawing.Size(520, 430);
            this.PanelBackground.TabIndex = 0;
            this.PanelBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBackground_Paint);
            this.PanelBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelBackground_MouseDown);
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.BackColor = System.Drawing.Color.Transparent;
            this.LabelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.LabelTitle.ForeColor = System.Drawing.Color.Black;
            this.LabelTitle.Location = new System.Drawing.Point(160, 10);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(196, 41);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "Đổi mật khẩu";
            // 
            // CTButtonThoat
            // 
            this.CTButtonThoat.BackColor = System.Drawing.Color.DarkGray;
            this.CTButtonThoat.BackgroundColor = System.Drawing.Color.DarkGray;
            this.CTButtonThoat.BorderColor = System.Drawing.Color.DarkGray;
            this.CTButtonThoat.BorderRadius = 10;
            this.CTButtonThoat.BorderSize = 0;
            this.CTButtonThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CTButtonThoat.FlatAppearance.BorderSize = 0;
            this.CTButtonThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CTButtonThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.CTButtonThoat.ForeColor = System.Drawing.Color.White;
            this.CTButtonThoat.Location = new System.Drawing.Point(305, 375);
            this.CTButtonThoat.Name = "CTButtonThoat";
            this.CTButtonThoat.Size = new System.Drawing.Size(120, 38);
            this.CTButtonThoat.TabIndex = 4;
            this.CTButtonThoat.Text = "Thoát";
            this.CTButtonThoat.TextColor = System.Drawing.Color.White;
            this.CTButtonThoat.UseVisualStyleBackColor = false;
            this.CTButtonThoat.Click += new System.EventHandler(this.CTButtonThoat_Click);
            // 
            // CTButtonXacNhan
            // 
            this.CTButtonXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(172)))), ((int)(((byte)(62)))));
            this.CTButtonXacNhan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(172)))), ((int)(((byte)(62)))));
            this.CTButtonXacNhan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(172)))), ((int)(((byte)(62)))));
            this.CTButtonXacNhan.BorderRadius = 10;
            this.CTButtonXacNhan.BorderSize = 0;
            this.CTButtonXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CTButtonXacNhan.FlatAppearance.BorderSize = 0;
            this.CTButtonXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CTButtonXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.CTButtonXacNhan.ForeColor = System.Drawing.Color.White;
            this.CTButtonXacNhan.Location = new System.Drawing.Point(160, 375);
            this.CTButtonXacNhan.Name = "CTButtonXacNhan";
            this.CTButtonXacNhan.Size = new System.Drawing.Size(130, 38);
            this.CTButtonXacNhan.TabIndex = 3;
            this.CTButtonXacNhan.Text = "Xác nhận";
            this.CTButtonXacNhan.TextColor = System.Drawing.Color.White;
            this.CTButtonXacNhan.UseVisualStyleBackColor = false;
            this.CTButtonXacNhan.Click += new System.EventHandler(this.CTButtonXacNhan_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.panelMain.Controls.Add(this.pictureBox3);
            this.panelMain.Controls.Add(this.pictureBox2);
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Controls.Add(this.CTTextBoxNhapLaiMatKhauMoi);
            this.panelMain.Controls.Add(this.CTTextBoxMatKhauMoi);
            this.panelMain.Controls.Add(this.CTTextBoxMatKhauCu);
            this.panelMain.Location = new System.Drawing.Point(55, 65);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(410, 290);
            this.panelMain.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RomanceHotel.Properties.Resources.password; // nếu có icon password
            this.pictureBox3.Location = new System.Drawing.Point(45, 200);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RomanceHotel.Properties.Resources.password;
            this.pictureBox2.Location = new System.Drawing.Point(45, 130);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RomanceHotel.Properties.Resources.password;
            this.pictureBox1.Location = new System.Drawing.Point(45, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // CTTextBoxNhapLaiMatKhauMoi
            // 
            this.CTTextBoxNhapLaiMatKhauMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.CTTextBoxNhapLaiMatKhauMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.CTTextBoxNhapLaiMatKhauMoi.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(96)))), ((int)(((byte)(116)))));
            this.CTTextBoxNhapLaiMatKhauMoi.BorderRadius = 0;
            this.CTTextBoxNhapLaiMatKhauMoi.BorderSize = 2;
            this.CTTextBoxNhapLaiMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.CTTextBoxNhapLaiMatKhauMoi.ForeColor = System.Drawing.Color.Black;
            this.CTTextBoxNhapLaiMatKhauMoi.IsFocused = false;
            this.CTTextBoxNhapLaiMatKhauMoi.Location = new System.Drawing.Point(90, 200);
            this.CTTextBoxNhapLaiMatKhauMoi.Margin = new System.Windows.Forms.Padding(4);
            this.CTTextBoxNhapLaiMatKhauMoi.Multiline = false;
            this.CTTextBoxNhapLaiMatKhauMoi.Name = "CTTextBoxNhapLaiMatKhauMoi";
            this.CTTextBoxNhapLaiMatKhauMoi.Padding = new System.Windows.Forms.Padding(7);
            this.CTTextBoxNhapLaiMatKhauMoi.PasswordChar = true;
            this.CTTextBoxNhapLaiMatKhauMoi.PlaceholderColor = System.Drawing.Color.DimGray;
            this.CTTextBoxNhapLaiMatKhauMoi.PlaceholderText = "Nhập lại mật khẩu mới";
            this.CTTextBoxNhapLaiMatKhauMoi.ReadOnly = false;
            this.CTTextBoxNhapLaiMatKhauMoi.Size = new System.Drawing.Size(270, 35);
            this.CTTextBoxNhapLaiMatKhauMoi.TabIndex = 2;
            this.CTTextBoxNhapLaiMatKhauMoi.Texts = "";
            this.CTTextBoxNhapLaiMatKhauMoi.UnderlineedStyle = true;
            this.CTTextBoxNhapLaiMatKhauMoi._TextChanged += new System.EventHandler(this.CTTextBoxNhapLaiMatKhauMoi__TextChanged);
            // 
            // CTTextBoxMatKhauMoi
            // 
            this.CTTextBoxMatKhauMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.CTTextBoxMatKhauMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.CTTextBoxMatKhauMoi.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(96)))), ((int)(((byte)(116)))));
            this.CTTextBoxMatKhauMoi.BorderRadius = 0;
            this.CTTextBoxMatKhauMoi.BorderSize = 2;
            this.CTTextBoxMatKhauMoi.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.CTTextBoxMatKhauMoi.ForeColor = System.Drawing.Color.Black;
            this.CTTextBoxMatKhauMoi.IsFocused = false;
            this.CTTextBoxMatKhauMoi.Location = new System.Drawing.Point(90, 130);
            this.CTTextBoxMatKhauMoi.Margin = new System.Windows.Forms.Padding(4);
            this.CTTextBoxMatKhauMoi.Multiline = false;
            this.CTTextBoxMatKhauMoi.Name = "CTTextBoxMatKhauMoi";
            this.CTTextBoxMatKhauMoi.Padding = new System.Windows.Forms.Padding(7);
            this.CTTextBoxMatKhauMoi.PasswordChar = true;
            this.CTTextBoxMatKhauMoi.PlaceholderColor = System.Drawing.Color.DimGray;
            this.CTTextBoxMatKhauMoi.PlaceholderText = "Mật khẩu mới";
            this.CTTextBoxMatKhauMoi.ReadOnly = false;
            this.CTTextBoxMatKhauMoi.Size = new System.Drawing.Size(270, 35);
            this.CTTextBoxMatKhauMoi.TabIndex = 1;
            this.CTTextBoxMatKhauMoi.Texts = "";
            this.CTTextBoxMatKhauMoi.UnderlineedStyle = true;
            this.CTTextBoxMatKhauMoi._TextChanged += new System.EventHandler(this.CTTextBoxMatKhauMoi__TextChanged);
            // 
            // CTTextBoxMatKhauCu
            // 
            this.CTTextBoxMatKhauCu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.CTTextBoxMatKhauCu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.CTTextBoxMatKhauCu.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(96)))), ((int)(((byte)(116)))));
            this.CTTextBoxMatKhauCu.BorderRadius = 0;
            this.CTTextBoxMatKhauCu.BorderSize = 2;
            this.CTTextBoxMatKhauCu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.CTTextBoxMatKhauCu.ForeColor = System.Drawing.Color.Black;
            this.CTTextBoxMatKhauCu.IsFocused = false;
            this.CTTextBoxMatKhauCu.Location = new System.Drawing.Point(90, 60);
            this.CTTextBoxMatKhauCu.Margin = new System.Windows.Forms.Padding(4);
            this.CTTextBoxMatKhauCu.Multiline = false;
            this.CTTextBoxMatKhauCu.Name = "CTTextBoxMatKhauCu";
            this.CTTextBoxMatKhauCu.Padding = new System.Windows.Forms.Padding(7);
            this.CTTextBoxMatKhauCu.PasswordChar = true;
            this.CTTextBoxMatKhauCu.PlaceholderColor = System.Drawing.Color.DimGray;
            this.CTTextBoxMatKhauCu.PlaceholderText = "Mật khẩu hiện tại";
            this.CTTextBoxMatKhauCu.ReadOnly = false;
            this.CTTextBoxMatKhauCu.Size = new System.Drawing.Size(270, 35);
            this.CTTextBoxMatKhauCu.TabIndex = 0;
            this.CTTextBoxMatKhauCu.Texts = "";
            this.CTTextBoxMatKhauCu.UnderlineedStyle = true;
            this.CTTextBoxMatKhauCu._TextChanged += new System.EventHandler(this.CTTextBoxMatKhauCu__TextChanged);
            // 
            // FormDoiMatKhau
            // 
            this.AcceptButton = this.CTButtonXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 430);
            this.Controls.Add(this.PanelBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDoiMatKhau";
            this.Activated += new System.EventHandler(this.FormDoiMatKhau_Activated);
            this.Load += new System.EventHandler(this.FormDoiMatKhau_Load);
            this.SizeChanged += new System.EventHandler(this.FormDoiMatKhau_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDoiMatKhau_Paint);
            this.Resize += new System.EventHandler(this.FormDoiMatKhau_Resize);
            this.PanelBackground.ResumeLayout(false);
            this.PanelBackground.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBackground;
        private System.Windows.Forms.Label LabelTitle;
        private CTControls.CTButton CTButtonThoat;
        private CTControls.CTButton CTButtonXacNhan;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CTControls.CTTextBox CTTextBoxNhapLaiMatKhauMoi;
        private CTControls.CTTextBox CTTextBoxMatKhauMoi;
        private CTControls.CTTextBox CTTextBoxMatKhauCu;
    }
}
