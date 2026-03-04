using System;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    partial class FormChonHinhThucThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private Button btnTienMat;
        private Button btnQuetQR;
        private Label lblTongTien;
        private Label lblTitleTongTien;
        private Button btnQuayLai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnTienMat = new System.Windows.Forms.Button();
            this.btnQuetQR = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTitleTongTien = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblHeader.Location = new System.Drawing.Point(35, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(444, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "CHỌN HÌNH THỨC THANH TOÁN";
            // 
            // btnTienMat
            // 
            this.btnTienMat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.btnTienMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTienMat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTienMat.ForeColor = System.Drawing.Color.White;
            this.btnTienMat.Location = new System.Drawing.Point(80, 140);
            this.btnTienMat.Name = "btnTienMat";
            this.btnTienMat.Size = new System.Drawing.Size(300, 50);
            this.btnTienMat.TabIndex = 3;
            this.btnTienMat.Text = "Thanh toán tiền mặt";
            this.btnTienMat.UseVisualStyleBackColor = false;
            this.btnTienMat.Click += new System.EventHandler(this.btnTienMat_Click);
            // 
            // btnQuetQR
            // 
            this.btnQuetQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnQuetQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuetQR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuetQR.ForeColor = System.Drawing.Color.White;
            this.btnQuetQR.Location = new System.Drawing.Point(80, 210);
            this.btnQuetQR.Name = "btnQuetQR";
            this.btnQuetQR.Size = new System.Drawing.Size(300, 50);
            this.btnQuetQR.TabIndex = 4;
            this.btnQuetQR.Text = "Quét mã VietQR";
            this.btnQuetQR.UseVisualStyleBackColor = false;
            this.btnQuetQR.Click += new System.EventHandler(this.btnQuetQR_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTongTien.Location = new System.Drawing.Point(150, 78);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 32);
            this.lblTongTien.TabIndex = 2;
            // 
            // lblTitleTongTien
            // 
            this.lblTitleTongTien.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTitleTongTien.Location = new System.Drawing.Point(40, 80);
            this.lblTitleTongTien.Name = "lblTitleTongTien";
            this.lblTitleTongTien.Size = new System.Drawing.Size(154, 35);
            this.lblTitleTongTien.TabIndex = 1;
            this.lblTitleTongTien.Text = "Tổng tiền:";
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.LightGray;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Location = new System.Drawing.Point(180, 280);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(100, 35);
            this.btnQuayLai.TabIndex = 5;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // FormChonHinhThucThanhToan
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 350);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblTitleTongTien);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnTienMat);
            this.Controls.Add(this.btnQuetQR);
            this.Controls.Add(this.btnQuayLai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChonHinhThucThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
