using RomanceHotel.BUS;
using RomanceHotel.CTControls;
using RomanceHotel.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace RomanceHotel.GUI
{
    public partial class FormThemTaiKhoan : Form
    {
        // Fields
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;

        // Constructor
        public FormThemTaiKhoan()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
            LoadForm();
        }

        #region Draw Form + Move

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // Minimize borderless form từ taskbar
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

        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }

        private struct FormBoundsColors
        {
            public Color TopLeftColor;
            public Color TopRightColor;
            public Color BottomLeftColor;
            public Color BottomRightColor;
        }

        private FormBoundsColors GetSameDark()
        {
            FormBoundsColors colors = new FormBoundsColors();
            colors.TopLeftColor = Color.FromArgb(67, 73, 73);
            colors.TopRightColor = Color.FromArgb(67, 73, 73);
            colors.BottomLeftColor = Color.FromArgb(67, 73, 73);
            colors.BottomRightColor = Color.FromArgb(67, 73, 73);
            return colors;
        }

        private void FormThemTaiKhoan_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetSameDark();

            // Top Left
            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);
            // Top Right
            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);
            // Bottom Left
            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);
            // Bottom Right
            Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);

            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void FormThemTaiKhoan_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemTaiKhoan_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemTaiKhoan_Activated(object sender, EventArgs e)
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

        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemTaiKhoan_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LabelThemTaiKhoan;
        }

        /// <summary>
        /// Load combobox Mã NV (chỉ NV chưa có tài khoản)
        /// </summary>
        private void LoadForm()
        {
            try
            {
                this.comboBoxMaNV.Items.Clear();
                List<TaiKhoan> taiKhoans = TaiKhoanBUS.Instance.GetTaiKhoans();
                List<NhanVien> nhanViens = NhanVienBUS.Instance.GetNhanViens();

                foreach (NhanVien nhanVien in nhanViens)
                {
                    if (taiKhoans.Any(p => p.MaNV == nhanVien.MaNV))
                        continue;

                    comboBoxMaNV.Items.Add("  " + nhanVien.MaNV);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Tạo mật khẩu ngẫu nhiên
        /// </summary>
        private string GenerateRandomPassword(int length = 10)
        {
            const string valid = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@#$%";
            StringBuilder res = new StringBuilder();
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (res.Length < length)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return res.ToString();
        }

        /// <summary>
        /// Gửi email thông tin tài khoản cho nhân viên
        /// </summary>
        private void SendAccountInfoByEmail(string toEmail, string username, string plainPassword)
        {
            try
            {
                string fromEmail = "khanhvk22.btt.knt@gmail.com";
                string fromPassword = "dtie uxsp zvlv jeap"; // Gmail App Password

                string hotelName = "Romance Hotel";
                string mainColor = "#2A5D92"; // Pastel xanh dương
                string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                string htmlBody = $@"
        <div style='font-family:Segoe UI, sans-serif; padding:24px; background:#f6faff; color:#222;'>
            <div style='text-align:center; margin-bottom:25px;'>
                <h2 style='color:{mainColor}; margin:0; font-size:26px; font-weight:bold;'>{hotelName}</h2>
                <p style='margin:5px 0 0 0; color:#555;'>Thông tin tài khoản đăng nhập hệ thống</p>
            </div>

            <div style='background:white; padding:22px 28px; border-radius:12px;
                        border:1px solid #dce7f5; box-shadow:0 2px 10px rgba(0,0,0,0.05);'>

                <p>Xin chào bạn,</p>
                <p>Bộ phận quản trị đã tạo cho bạn một tài khoản truy cập hệ thống quản lý khách sạn.</p>

                <table style='margin:18px 0; width:100%; font-size:15px;'>
                    <tr>
                        <td style='font-weight:600; width:140px;'>Tên đăng nhập:</td>
                        <td>{username}</td>
                    </tr>
                    <tr>
                        <td style='font-weight:600;'>Mật khẩu:</td>
                        <td>{plainPassword}</td>
                    </tr>
                </table>

                <p style='margin-top:18px;'>
                    ⚠ <b>Vui lòng đổi mật khẩu ngay trong lần đăng nhập đầu tiên</b>
                    để đảm bảo an toàn và bảo mật tài khoản của bạn.
                </p>

                <p style='margin-top:24px;'>Trân trọng,<br>
                <span style='font-weight:bold; color:{mainColor};'>{hotelName}</span><br>
                <span style='font-size:12px; color:#777;'>{currentDate}</span></p>
            </div>

            <p style='text-align:center; margin-top:25px; font-size:12px; color:#777;'>
                Email được gửi tự động. Vui lòng không phản hồi trực tiếp.
            </p>
        </div>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, hotelName);
                mail.To.Add(toEmail);
                mail.Subject = "Thông tin tài khoản đăng nhập hệ thống";
                mail.Body = htmlBody;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(
                    "Tài khoản tạo thành công nhưng gửi Email thất bại:\n" + ex.Message,
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void CTButtonCapNhat_Click(object sender, EventArgs e)
        {
            string MaNV;
            string TenTK = CTTextBoxNhapTenTaiKhoan.Texts;
            string CapDoQuyen = comboBoxCapDoQuyen.Texts;

            // Lấy Mã NV
            if (comboBoxMaNV.SelectedItem != null)
            {
                MaNV = comboBoxMaNV.SelectedItem.ToString().Trim();
            }
            else
            {
                CTMessageBox.Show("Vui lòng chọn mã nhân viên.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra nhập đủ thông tin
            if (string.IsNullOrWhiteSpace(TenTK) || CapDoQuyen == "  Cấp độ quyền")
            {
                CTMessageBox.Show("Vui lòng nhập tên tài khoản và chọn cấp độ quyền.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng tên tài khoản
            if (TaiKhoanBUS.Instance.GetTKDangNhap(TenTK) != null)
            {
                CTMessageBox.Show("Tên đăng nhập này đã tồn tại.", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Lấy thông tin nhân viên
                NhanVien nhanVien = NhanVienBUS.Instance.GetNhanVien(MaNV);
                if (nhanVien == null)
                {
                    CTMessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra chức vụ khớp cấp độ quyền
                if (!nhanVien.ChucVu.Trim().ToLower().Equals(CapDoQuyen.Trim().ToLower()))
                {
                    CTMessageBox.Show("Nhân viên được chọn có chức vụ không phù hợp với cấp độ quyền.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Lấy email nhân viên
                string emailNhanVien = nhanVien.Email;
                if (string.IsNullOrWhiteSpace(emailNhanVien))
                {
                    CTMessageBox.Show("Nhân viên chưa có Email. Vui lòng cập nhật Email trước khi tạo tài khoản.",
                        "Thiếu Email",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Tạo mật khẩu ngẫu nhiên
                string matKhauTuDong = GenerateRandomPassword();

                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TenTK = TenTK;
                taiKhoan.Password = matKhauTuDong; // hiện tại dùng plain-text như hệ thống cũ
                taiKhoan.MaNV = MaNV;

                if (CapDoQuyen == "  Admin")
                    taiKhoan.CapDoQuyen = 3;
                else if (CapDoQuyen == "  Quản lý")
                    taiKhoan.CapDoQuyen = 2;
                else
                    taiKhoan.CapDoQuyen = 1;

                // Lưu tài khoản
                TaiKhoanBUS.Instance.AddOrUpdateTK(taiKhoan);

                // Gửi mail
                SendAccountInfoByEmail(emailNhanVien, TenTK, matKhauTuDong);

                // Thông báo
                CTMessageBox.Show(
                    $"Thêm tài khoản thành công.\nMật khẩu đã được gửi tới email: {emailNhanVien}",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(
                    "Đã xảy ra lỗi! Vui lòng thử lại.\n" + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CTTextBoxNhapTenTaiKhoan__TextChanged(object sender, EventArgs e)
        {
            // Nếu muốn kiểm tra realtime (vd: cấm khoảng trắng, ký tự đặc biệt) thì xử lý ở đây
        }
    }
}
