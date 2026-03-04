using System;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    partial class FormSaoLuuPhucHoi
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelBackup;
        private Label labelRestore;
        private TextBox txtBackupPath;
        private TextBox txtRestoreFile;
        private Button btnBrowseBackupPath;
        private Button btnBrowseRestoreFile;
        private Button btnBackup;
        private Button btnRestore;
        private ProgressBar progressBar;
        private Label labelStatus;
        private Panel panelBackup;
        private Panel panelRestore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelBackup = new System.Windows.Forms.Label();
            this.labelRestore = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.txtRestoreFile = new System.Windows.Forms.TextBox();
            this.btnBrowseBackupPath = new System.Windows.Forms.Button();
            this.btnBrowseRestoreFile = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelBackup = new System.Windows.Forms.Panel();
            this.panelRestore = new System.Windows.Forms.Panel();
            this.panelBackup.SuspendLayout();
            this.panelRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.labelTitle.Location = new System.Drawing.Point(301, 31);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(589, 60);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Sao lưu và Phục hồi dữ liệu";
            // 
            // labelBackup
            // 
            this.labelBackup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelBackup.Location = new System.Drawing.Point(20, 20);
            this.labelBackup.Name = "labelBackup";
            this.labelBackup.Size = new System.Drawing.Size(100, 23);
            this.labelBackup.TabIndex = 0;
            this.labelBackup.Text = "Thư mục sao lưu:";
            // 
            // labelRestore
            // 
            this.labelRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelRestore.Location = new System.Drawing.Point(20, 20);
            this.labelRestore.Name = "labelRestore";
            this.labelRestore.Size = new System.Drawing.Size(100, 23);
            this.labelRestore.TabIndex = 0;
            this.labelRestore.Text = "File .bak cần phục hồi:";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(20, 60);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(300, 22);
            this.txtBackupPath.TabIndex = 1;
            // 
            // txtRestoreFile
            // 
            this.txtRestoreFile.Location = new System.Drawing.Point(20, 60);
            this.txtRestoreFile.Name = "txtRestoreFile";
            this.txtRestoreFile.Size = new System.Drawing.Size(300, 22);
            this.txtRestoreFile.TabIndex = 1;
            // 
            // btnBrowseBackupPath
            // 
            this.btnBrowseBackupPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.btnBrowseBackupPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseBackupPath.ForeColor = System.Drawing.Color.White;
            this.btnBrowseBackupPath.Location = new System.Drawing.Point(330, 60);
            this.btnBrowseBackupPath.Name = "btnBrowseBackupPath";
            this.btnBrowseBackupPath.Size = new System.Drawing.Size(100, 30);
            this.btnBrowseBackupPath.TabIndex = 2;
            this.btnBrowseBackupPath.Text = "Browse...";
            this.btnBrowseBackupPath.UseVisualStyleBackColor = false;
            this.btnBrowseBackupPath.Click += new System.EventHandler(this.btnBrowseBackupPath_Click);
            // 
            // btnBrowseRestoreFile
            // 
            this.btnBrowseRestoreFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnBrowseRestoreFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseRestoreFile.ForeColor = System.Drawing.Color.White;
            this.btnBrowseRestoreFile.Location = new System.Drawing.Point(330, 60);
            this.btnBrowseRestoreFile.Name = "btnBrowseRestoreFile";
            this.btnBrowseRestoreFile.Size = new System.Drawing.Size(100, 30);
            this.btnBrowseRestoreFile.TabIndex = 2;
            this.btnBrowseRestoreFile.Text = "Browse...";
            this.btnBrowseRestoreFile.UseVisualStyleBackColor = false;
            this.btnBrowseRestoreFile.Click += new System.EventHandler(this.btnBrowseRestoreFile_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(120, 140);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(200, 50);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "SAO LƯU";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(120, 140);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(200, 50);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "PHỤC HỒI";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(280, 400);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(600, 30);
            this.progressBar.TabIndex = 3;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelStatus.Location = new System.Drawing.Point(280, 440);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(172, 25);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Sẵn sàng thực hiện";
            // 
            // panelBackup
            // 
            this.panelBackup.BackColor = System.Drawing.Color.White;
            this.panelBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBackup.Controls.Add(this.labelBackup);
            this.panelBackup.Controls.Add(this.txtBackupPath);
            this.panelBackup.Controls.Add(this.btnBrowseBackupPath);
            this.panelBackup.Controls.Add(this.btnBackup);
            this.panelBackup.Location = new System.Drawing.Point(134, 130);
            this.panelBackup.Name = "panelBackup";
            this.panelBackup.Size = new System.Drawing.Size(450, 230);
            this.panelBackup.TabIndex = 1;
            // 
            // panelRestore
            // 
            this.panelRestore.BackColor = System.Drawing.Color.White;
            this.panelRestore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRestore.Controls.Add(this.labelRestore);
            this.panelRestore.Controls.Add(this.txtRestoreFile);
            this.panelRestore.Controls.Add(this.btnBrowseRestoreFile);
            this.panelRestore.Controls.Add(this.btnRestore);
            this.panelRestore.Location = new System.Drawing.Point(580, 130);
            this.panelRestore.Name = "panelRestore";
            this.panelRestore.Size = new System.Drawing.Size(450, 230);
            this.panelRestore.TabIndex = 2;
            // 
            // FormSaoLuuPhucHoi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1180, 760);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelBackup);
            this.Controls.Add(this.panelRestore);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelStatus);
            this.Name = "FormSaoLuuPhucHoi";
            this.panelBackup.ResumeLayout(false);
            this.panelBackup.PerformLayout();
            this.panelRestore.ResumeLayout(false);
            this.panelRestore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}