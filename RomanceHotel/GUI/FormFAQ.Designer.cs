using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    partial class FormFAQ
    {
        private IContainer components = null;

        private Panel panelLeft;
        private Panel panelRight;
        private Label labelTitle;
        private Label labelSubTitle;
        private Label labelHint;
        private FlowLayoutPanel flowLayoutPanelFAQ;

        // NEW
        private Button btnHuongDan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnHuongDan = new System.Windows.Forms.Button();
            this.labelHint = new System.Windows.Forms.Label();
            this.labelSubTitle = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.flowLayoutPanelFAQ = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(237)))));
            this.panelLeft.Controls.Add(this.btnHuongDan);
            this.panelLeft.Controls.Add(this.labelHint);
            this.panelLeft.Controls.Add(this.labelSubTitle);
            this.panelLeft.Controls.Add(this.labelTitle);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(24, 30, 10, 20);
            this.panelLeft.Size = new System.Drawing.Size(352, 620);
            this.panelLeft.TabIndex = 0;
            // 
            // btnHuongDan
            // 
            this.btnHuongDan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnHuongDan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuongDan.FlatAppearance.BorderSize = 0;
            this.btnHuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuongDan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnHuongDan.ForeColor = System.Drawing.Color.White;
            this.btnHuongDan.Location = new System.Drawing.Point(27, 230);
            this.btnHuongDan.Name = "btnHuongDan";
            this.btnHuongDan.Size = new System.Drawing.Size(285, 42);
            this.btnHuongDan.TabIndex = 3;
            this.btnHuongDan.Text = "HƯỚNG DẪN SỬ DỤNG";
            this.btnHuongDan.UseVisualStyleBackColor = false;
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.labelHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.labelHint.Location = new System.Drawing.Point(23, 158);
            this.labelHint.MaximumSize = new System.Drawing.Size(260, 0);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(257, 42);
            this.labelHint.TabIndex = 2;
            this.labelHint.Text = "Tip: Nếu vẫn chưa tìm được câu trả lời, hãy liên hệ quản trị hệ thống.";
            // 
            // labelSubTitle
            // 
            this.labelSubTitle.AutoSize = true;
            this.labelSubTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.labelSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.labelSubTitle.Location = new System.Drawing.Point(23, 70);
            this.labelSubTitle.MaximumSize = new System.Drawing.Size(260, 0);
            this.labelSubTitle.Name = "labelSubTitle";
            this.labelSubTitle.Size = new System.Drawing.Size(224, 75);
            this.labelSubTitle.TabIndex = 1;
            this.labelSubTitle.Text = "Câu hỏi thường gặp về hệ thống quản lý khách sạn Romance Hotel.";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 24);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(287, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "TRUNG TÂM HỖ TRỢ";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.panelRight.Controls.Add(this.flowLayoutPanelFAQ);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(352, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(24);
            this.panelRight.Size = new System.Drawing.Size(700, 620);
            this.panelRight.TabIndex = 1;
            // 
            // flowLayoutPanelFAQ
            // 
            this.flowLayoutPanelFAQ.AutoScroll = true;
            this.flowLayoutPanelFAQ.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelFAQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFAQ.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelFAQ.Location = new System.Drawing.Point(24, 24);
            this.flowLayoutPanelFAQ.Name = "flowLayoutPanelFAQ";
            this.flowLayoutPanelFAQ.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.flowLayoutPanelFAQ.Size = new System.Drawing.Size(652, 572);
            this.flowLayoutPanelFAQ.TabIndex = 0;
            this.flowLayoutPanelFAQ.WrapContents = false;
            // 
            // FormFAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1052, 620);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFAQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Câu hỏi thường gặp (FAQ)";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
