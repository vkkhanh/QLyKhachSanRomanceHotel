using RomanceHotel.BUS;
using RomanceHotel.CTControls;
using RomanceHotel.DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormDoiMatKhau : Form
    {
        // Fields bo tròn form
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;

        private TaiKhoan taiKhoan;

        public FormDoiMatKhau(TaiKhoan taiKhoan)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);

            InitializeComponent();

            this.taiKhoan = taiKhoan;
        }

        #region Draw Form + Move Form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // Minimize borderless form from taskbar
                return cp;
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void ControlRegionAndBorder(Control control, float radius, Graphics graph, Color borderColor)
        {
            using (GraphicsPath roundPath = GetRoundedPath(control.ClientRectangle, radius))
            using (Pen penBorder = new Pen(borderColor, 1))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                control.Region = new Region(roundPath);
                graph.DrawPath(penBorder, roundPath);
            }
        }

        private void FormDoiMatKhau_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;

            // màu viền tối nhẹ
            Color c = Color.FromArgb(67, 73, 73);
            using (GraphicsPath p = GetRoundedPath(rectForm, borderRadius))
            using (Pen pen = new Pen(c, 3))
            {
                e.Graphics.DrawPath(pen, p);
            }

            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void FormDoiMatKhau_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormDoiMatKhau_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormDoiMatKhau_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void PanelBackground_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LabelTitle;
            CTTextBoxMatKhauCu.PasswordChar = true;
            CTTextBoxMatKhauMoi.PasswordChar = true;
            CTTextBoxNhapLaiMatKhauMoi.PasswordChar = true;
        }

        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CTButtonXacNhan_Click(object sender, EventArgs e)
        {
            string mkCu = CTTextBoxMatKhauCu.Texts.Trim();
            string mkMoi = CTTextBoxMatKhauMoi.Texts.Trim();
            string mkNhapLai = CTTextBoxNhapLaiMatKhauMoi.Texts.Trim();

            if (string.IsNullOrEmpty(mkCu) ||
                string.IsNullOrEmpty(mkMoi) ||
                string.IsNullOrEmpty(mkNhapLai))
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kiểm tra mật khẩu cũ
            if (!mkCu.Equals(taiKhoan.Password))
            {
                CTMessageBox.Show("Mật khẩu hiện tại không đúng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mkMoi.Length < 6)
            {
                CTMessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!mkMoi.Equals(mkNhapLai))
            {
                CTMessageBox.Show("Mật khẩu mới và nhập lại không khớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                taiKhoan.Password = mkMoi; // hiện tại đang lưu plain-text giống FormThemTaiKhoan
                TaiKhoanBUS.Instance.AddOrUpdateTK(taiKhoan);

                CTMessageBox.Show("Đổi mật khẩu thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3 textbox dùng CTTextBox custom, nên để trống event _TextChanged nếu không cần
        private void CTTextBoxMatKhauCu__TextChanged(object sender, EventArgs e) { }
        private void CTTextBoxMatKhauMoi__TextChanged(object sender, EventArgs e) { }
        private void CTTextBoxNhapLaiMatKhauMoi__TextChanged(object sender, EventArgs e) { }
    }
}
