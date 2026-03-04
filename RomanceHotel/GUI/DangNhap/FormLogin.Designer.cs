using System.Windows.Forms;

namespace RomanceHotel
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public class DoubleBufferPanel : Panel

        {

            public DoubleBufferPanel()

            {

                // Set the value of the double-buffering style bits to true.

                this.DoubleBuffered = true;

                this.SetStyle(ControlStyles.AllPaintingInWmPaint |

                ControlStyles.UserPaint |

                ControlStyles.OptimizedDoubleBuffer, true);

                UpdateStyles();

            }

        }
        /// <summary>
        /// Clean up any resources being used.
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelBackground = new RomanceHotel.FormLogin.DoubleBufferPanel();
            this.panelLogin = new RomanceHotel.FormLogin.DoubleBufferPanel();
            this.PanelLoginContent = new RomanceHotel.FormLogin.DoubleBufferPanel();
            this.panelControlBox = new RomanceHotel.FormLogin.DoubleBufferPanel();
            this.ctMinimize1 = new RomanceHotel.CTControls.CTMinimize();
            this.ctClose1 = new RomanceHotel.CTControls.CTClose();
            this.labelCorporation = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelBackground.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = System.Drawing.Color.White;
            this.panelBackground.Controls.Add(this.panelLogin);
            this.panelBackground.Controls.Add(this.pictureBoxIcon);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(909, 538);
            this.panelBackground.TabIndex = 0;
            this.panelBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBackground_Paint);
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.Controls.Add(this.PanelLoginContent);
            this.panelLogin.Controls.Add(this.panelControlBox);
            this.panelLogin.Controls.Add(this.labelCorporation);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLogin.Location = new System.Drawing.Point(495, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(414, 538);
            this.panelLogin.TabIndex = 10;
            this.panelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBackground_Paint);
            this.panelLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLogin_MouseDown);
            // 
            // PanelLoginContent
            // 
            this.PanelLoginContent.BackColor = System.Drawing.Color.White;
            this.PanelLoginContent.Location = new System.Drawing.Point(29, 39);
            this.PanelLoginContent.Name = "PanelLoginContent";
            this.PanelLoginContent.Size = new System.Drawing.Size(348, 466);
            this.PanelLoginContent.TabIndex = 10;
            // 
            // panelControlBox
            // 
            this.panelControlBox.BackColor = System.Drawing.Color.White;
            this.panelControlBox.Controls.Add(this.ctMinimize1);
            this.panelControlBox.Controls.Add(this.ctClose1);
            this.panelControlBox.Location = new System.Drawing.Point(291, 1);
            this.panelControlBox.Name = "panelControlBox";
            this.panelControlBox.Size = new System.Drawing.Size(95, 30);
            this.panelControlBox.TabIndex = 5;
            // 
            // ctMinimize1
            // 
            this.ctMinimize1.BackColor = System.Drawing.Color.Transparent;
            this.ctMinimize1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctMinimize1.BackgroundImage")));
            this.ctMinimize1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctMinimize1.Enabled = false;
            this.ctMinimize1.Location = new System.Drawing.Point(40, 6);
            this.ctMinimize1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctMinimize1.Name = "ctMinimize1";
            this.ctMinimize1.Size = new System.Drawing.Size(15, 15);
            this.ctMinimize1.TabIndex = 1;
            this.ctMinimize1.Click += new System.EventHandler(this.ctMinimize1_Click);
            // 
            // ctClose1
            // 
            this.ctClose1.BackColor = System.Drawing.Color.Transparent;
            this.ctClose1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctClose1.BackgroundImage")));
            this.ctClose1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctClose1.Location = new System.Drawing.Point(71, 6);
            this.ctClose1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctClose1.Name = "ctClose1";
            this.ctClose1.Size = new System.Drawing.Size(15, 15);
            this.ctClose1.TabIndex = 0;
            this.ctClose1.Click += new System.EventHandler(this.ctClose1_Click);
            // 
            // labelCorporation
            // 
            this.labelCorporation.AutoSize = true;
            this.labelCorporation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorporation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(152)))), ((int)(((byte)(162)))));
            this.labelCorporation.Location = new System.Drawing.Point(234, 510);
            this.labelCorporation.Name = "labelCorporation";
            this.labelCorporation.Size = new System.Drawing.Size(180, 28);
            this.labelCorporation.TabIndex = 4;
            this.labelCorporation.Text = "ROMANCE HOTEL";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.White;
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(489, 538);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 12;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxIcon_MouseDown);
            // 
            // FormLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 538);
            this.ControlBox = false;
            this.Controls.Add(this.panelBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(909, 538);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách sạn - Đăng nhập";
            this.Activated += new System.EventHandler(this.FormLogin_Activated);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.SizeChanged += new System.EventHandler(this.FormLogin_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormLogin_Paint);
            this.Resize += new System.EventHandler(this.FormLogin_Resize);
            this.panelBackground.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private CTControls.CTMinimize ctMinimize1;
        private CTControls.CTClose ctClose1;
        private System.Windows.Forms.Label labelCorporation;
        private DoubleBufferPanel panelBackground;
        private DoubleBufferPanel panelLogin;
        private DoubleBufferPanel panelControlBox;
        private DoubleBufferPanel PanelLoginContent;

        #endregion
        //private CTControl.CTButton ctButton1;
    }
}

