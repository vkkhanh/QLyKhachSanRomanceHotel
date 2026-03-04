using System;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    partial class FormThanhToanQR
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private PictureBox picQR;
        private Button btnXacNhan;
        private Button btnHuy;
        private Label lblTitleTongTien;
        private Label lblTongTien;
        private Label lblGuide;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblTitleTongTien = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblGuide = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblHeader.Location = new System.Drawing.Point(56, 19);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(407, 41);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THANH TOÁN QUA VIETQR";
            // 
            // picQR
            // 
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(100, 130);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(280, 280);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 1;
            this.picQR.TabStop = false;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(110, 460);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(260, 45);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận đã thanh toán";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightGray;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Location = new System.Drawing.Point(190, 510);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 35);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblTitleTongTien
            // 
            this.lblTitleTongTien.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTitleTongTien.Location = new System.Drawing.Point(40, 80);
            this.lblTitleTongTien.Name = "lblTitleTongTien";
            this.lblTitleTongTien.Size = new System.Drawing.Size(110, 32);
            this.lblTitleTongTien.TabIndex = 3;
            this.lblTitleTongTien.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTongTien.Location = new System.Drawing.Point(150, 80);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 32);
            this.lblTongTien.TabIndex = 4;
            // 
            // lblGuide
            // 
            this.lblGuide.AutoSize = true;
            this.lblGuide.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblGuide.ForeColor = System.Drawing.Color.Gray;
            this.lblGuide.Location = new System.Drawing.Point(80, 420);
            this.lblGuide.Name = "lblGuide";
            this.lblGuide.Size = new System.Drawing.Size(301, 46);
            this.lblGuide.TabIndex = 2;
            this.lblGuide.Text = "Quét mã bằng ứng dụng ngân hàng,\nsau đó nhấn \"Xác nhận đã thanh toán\".";
            // 
            // FormThanhToanQR
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(475, 560);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.lblGuide);
            this.Controls.Add(this.lblTitleTongTien);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThanhToanQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
