using System;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    partial class FormThanhToanTienMat
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private Label lblTitleTongTien;
        private Label lblTongTien;
        private Label lblTitleTienKhach;
        private TextBox txtTienKhachDua;
        private Label lblTitleTienThoi;
        private Label lblTienThoi;
        private Button btnXacNhan;
        private Button btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTitleTongTien = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTitleTienKhach = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.lblTitleTienThoi = new System.Windows.Forms.Label();
            this.lblTienThoi = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblHeader.Location = new System.Drawing.Point(75, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(372, 41);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THANH TOÁN TIỀN MẶT";
            // 
            // lblTitleTongTien
            // 
            this.lblTitleTongTien.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTitleTongTien.Location = new System.Drawing.Point(26, 90);
            this.lblTitleTongTien.Name = "lblTitleTongTien";
            this.lblTitleTongTien.Size = new System.Drawing.Size(110, 32);
            this.lblTitleTongTien.TabIndex = 1;
            this.lblTitleTongTien.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTongTien.Location = new System.Drawing.Point(180, 90);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 32);
            this.lblTongTien.TabIndex = 2;
            // 
            // lblTitleTienKhach
            // 
            this.lblTitleTienKhach.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTitleTienKhach.Location = new System.Drawing.Point(26, 150);
            this.lblTitleTienKhach.Name = "lblTitleTienKhach";
            this.lblTitleTienKhach.Size = new System.Drawing.Size(168, 36);
            this.lblTitleTienKhach.TabIndex = 3;
            this.lblTitleTienKhach.Text = "Tiền khách đưa:";
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtTienKhachDua.Location = new System.Drawing.Point(200, 150);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(208, 36);
            this.txtTienKhachDua.TabIndex = 4;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged);
            // 
            // lblTitleTienThoi
            // 
            this.lblTitleTienThoi.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTitleTienThoi.Location = new System.Drawing.Point(26, 210);
            this.lblTitleTienThoi.Name = "lblTitleTienThoi";
            this.lblTitleTienThoi.Size = new System.Drawing.Size(110, 32);
            this.lblTitleTienThoi.TabIndex = 5;
            this.lblTitleTienThoi.Text = "Tiền thối:";
            // 
            // lblTienThoi
            // 
            this.lblTienThoi.AutoSize = true;
            this.lblTienThoi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTienThoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblTienThoi.Location = new System.Drawing.Point(194, 210);
            this.lblTienThoi.Name = "lblTienThoi";
            this.lblTienThoi.Size = new System.Drawing.Size(88, 32);
            this.lblTienThoi.TabIndex = 6;
            this.lblTienThoi.Text = "0 VNĐ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(95, 275);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(260, 45);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "Xác nhận thanh toán";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightGray;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Location = new System.Drawing.Point(175, 330);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 35);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormThanhToanTienMat
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 380);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblTitleTongTien);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblTitleTienKhach);
            this.Controls.Add(this.txtTienKhachDua);
            this.Controls.Add(this.lblTitleTienThoi);
            this.Controls.Add(this.lblTienThoi);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThanhToanTienMat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
