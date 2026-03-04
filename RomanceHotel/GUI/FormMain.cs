using RomanceHotel.GUI;
using System.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationSettings;
using RomanceHotel.GUI.ThongKe;
using RomanceHotel.DTO;
using System.IO;
using RomanceHotel.CTControls;

namespace RomanceHotel
{
    public partial class FormMain : Form
    {
        //Fields
        int LoaiTK;
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(127, 186, 192);
        private TaiKhoan taiKhoan;
        private SpeechRecognitionEngine recognizer;
        private bool isVoiceOn = false;

        public FormMain()
        {
            InitializeComponent();
            // KHÔNG gọi InitSpeechControl tự động nữa
            UpdateVoiceButtonUI();  // set trạng thái ban đầu
        }
        //Constructor
        public FormMain(TaiKhoan taiKhoan)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.taiKhoan = taiKhoan;
            this.LoaiTK = taiKhoan.CapDoQuyen;
            InitializeComponent();
            if (this.LoaiTK == 1)
                LoadFormForNhanVien();
            else if (this.LoaiTK == 2)
                LoadFormQuanLy();
            //customDesign();
        }
        private void LoadFormForNhanVien()
        {
            this.ButtonDanhSachTienNghi.Hide();
            this.ButtonDanhSachTaiKhoan.Hide();
            this.ButtonDanhSachNhanVien.Hide();
            this.ButtonThongKe.Hide();
            this.ButtonSaoLuuPhucHoi.Hide();   // Ẩn sao lưu phục hồi
        }
        private void LoadFormQuanLy()
        {
            this.ButtonDanhSachTaiKhoan.Hide();
        }
        //Control Box

        //Form Move

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp;
            }
        }

        //Private Methods
        //Private Methods
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
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);
                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);
                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);
                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);
                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }

        private FormBoundsColors SameColor()
        {
            var fbColor = new FormBoundsColors();
            fbColor.TopLeftColor = Color.FromArgb(127, 186, 192);
            fbColor.TopRightColor = Color.FromArgb(127, 186, 192);
            fbColor.BottomLeftColor = Color.FromArgb(127, 186, 192);
            fbColor.BottomRightColor = Color.FromArgb(127, 186, 192);
            return fbColor;
        }

        //Event Methods
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            //-> SMOOTH OUTER BORDER
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            //var fbColors = SameColor();
            var fbColors = GetFormBoundsColors();
            //Top Left
            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);
            //Top Right
            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);
            //Bottom Left
            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);
            //Bottom Right
            Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Mở form trang chủ khi vào hệ thống
            openChildForm(new FormTrangChu());

            // Hiệu ứng xuất hiện
            WinAPI.AnimateWindow(this.Handle, 300, WinAPI.CENTER);

            // Lấy tên & chức vụ từ DTO NhanVien
            string ten = taiKhoan.NhanVien.TenNV;
            string chucVu = taiKhoan.NhanVien.ChucVu;

            // cấu hình label
            LabelTenNguoiDung.AutoSize = true;
            LabelTenNguoiDung.MaximumSize = new Size(200, 0);
            LabelTenNguoiDung.Font = new Font(LabelTenNguoiDung.Font.FontFamily, 11f, FontStyle.Bold);
            LabelTenNguoiDung.TextAlign = ContentAlignment.MiddleCenter;

            // nội dung 2 dòng
            LabelTenNguoiDung.Text = ten + Environment.NewLine + "(" + chucVu + ")";

            // 🟧 Căn giữa label trong PanelUser
            LabelTenNguoiDung.Location = new Point(
                (PanelUser.Width - LabelTenNguoiDung.Width) / 2,   // center theo chiều ngang
                LabelTenNguoiDung.Location.Y - 10                 // nhích lên gần avatar
            );
        }






        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMainChildForm.Controls.Add(childForm);
            panelMainChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void ctMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void panelControlBox_MouseHover(object sender, EventArgs e)
        {
            ctClose1.turnOn();
            ctMinimize1.turnOn();
        }

        private void panelControlBox_MouseLeave(object sender, EventArgs e)
        {
            ctClose1.turnOff();
            ctMinimize1.turnOff();
        }

        private void panelControlBox_MouseMove(object sender, MouseEventArgs e)
        {
            ctClose1.turnOn();
            ctMinimize1.turnOn();   
        }

        private void panelName_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //Button color change
        private void SetAllButtonNormalColor()
        {
            ButtonTrangChu.BackColor = Color.FromArgb(127, 186, 192);
            ButtonSoDoPhong.BackColor = Color.FromArgb(127, 186, 192);
            ButtonDanhSachDatPhong.BackColor = Color.FromArgb(127, 186, 192);
            ButtonDanhSachHoaDon.BackColor = Color.FromArgb(127, 186, 192);
            ButtonDanhSachKhachHang.BackColor = Color.FromArgb(127, 186, 192);
            ButtonPhong.BackColor = Color.FromArgb(127, 186, 192);
            ButtonLoaiPhong.BackColor = Color.FromArgb(127, 186, 192);
            ButtonDanhSachDichVu.BackColor = Color.FromArgb(127, 186, 192);
            ButtonDanhSachTienNghi.BackColor = Color.FromArgb(127, 186, 192);
            ButtonDanhSachTaiKhoan.BackColor = Color.FromArgb(127, 186, 192);
            ButtonDanhSachNhanVien.BackColor = Color.FromArgb(127, 186, 192);
            ButtonThongKe.BackColor = Color.FromArgb(127, 186, 192);
            ButtonSaoLuuPhucHoi.BackColor = Color.FromArgb(127, 186, 192);

            ButtonTrangChu.ForeColor
                = ButtonSoDoPhong.ForeColor
                = ButtonDanhSachDatPhong.ForeColor
                = ButtonDanhSachHoaDon.ForeColor
                = ButtonDanhSachKhachHang.ForeColor
                = ButtonPhong.ForeColor
                = ButtonLoaiPhong.ForeColor
                = ButtonDanhSachDichVu.ForeColor
                = ButtonDanhSachTienNghi.ForeColor
                = ButtonDanhSachTaiKhoan.ForeColor
                = ButtonDanhSachNhanVien.ForeColor
                = ButtonThongKe.ForeColor
                = ButtonSaoLuuPhucHoi.ForeColor = Color.Black;
        }

        private void ButtonDanhSachDatPhong_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonDanhSachDatPhong.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachDatPhong.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachPhieuThue(this,taiKhoan));
        }

        private void ButtonSoDoPhong_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonSoDoPhong.BackColor = Color.FromArgb(233, 117, 32);
            ButtonSoDoPhong.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormSoDoPhong(this,taiKhoan));
        }


        private void ButtonDanhSachHoaDon_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonDanhSachHoaDon.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachHoaDon.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachHoaDon(this));
        }

        private void ButtonTrangChu_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonTrangChu.BackColor = Color.FromArgb(233, 117, 32);
            ButtonTrangChu.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormTrangChu(this));
        }

        private void ButtonDanhSachKhachHang_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonDanhSachKhachHang.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachKhachHang.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachKhachHang(this,this.taiKhoan));
        }

        private void ButtonSaoLuuPhucHoi_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonSaoLuuPhucHoi.BackColor = Color.FromArgb(233, 117, 32);
            ButtonSaoLuuPhucHoi.ForeColor = Color.White;

            //Open Child Form
            openChildForm(new FormSaoLuuPhucHoi(this));
        }

        private void ButtonPhong_Click(object sender, EventArgs e)
        {   //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonPhong.BackColor = Color.FromArgb(233, 117, 32);
            ButtonPhong.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachPhong(this,this.taiKhoan));
        }

        private void ButtonLoaiPhong_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonLoaiPhong.BackColor = Color.FromArgb(233, 117, 32);
            ButtonLoaiPhong.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachLoaiPhong(this,this.taiKhoan));
        }
        private void ButtonDanhSachDichVu_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonDanhSachDichVu.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachDichVu.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachDichVu(this,this.taiKhoan));
        }

        private void ButtonDanhSachTienNghi_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonDanhSachTienNghi.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachTienNghi.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachTienNghi(this,this.taiKhoan));
            
        }

        private void ButtonDanhSachTaiKhoan_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonDanhSachTaiKhoan.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachTaiKhoan.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachTaiKhoan(this));
        }

        private void ButtonDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonDanhSachNhanVien.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachNhanVien.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachNhanVien(this,this.taiKhoan));
        }

        private void ctClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonThongKe_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonThongKe.BackColor = Color.FromArgb(233, 117, 32);
            
            //Open Child Form
            openChildForm(new FormThongKe(this));
        }
        private void DisplayTextMenu()
        {
            ButtonTrangChu.Text = "    Trang chủ";
            ButtonSoDoPhong.Text = "    Sơ đồ phòng";
            ButtonDanhSachDatPhong.Text = "    Quản lý đặt phòng";
            ButtonDanhSachHoaDon.Text = "    Quản lý hóa đơn";
            ButtonDanhSachKhachHang.Text = "    Quản lý khách hàng";
            ButtonPhong.Text = "    Quản lý Phòng";
            ButtonLoaiPhong.Text = "    Quản lý loại phòng";
            ButtonDanhSachDichVu.Text = "    Quản lý dịch vụ";
            ButtonDanhSachTienNghi.Text = "    Quản lý tiện nghi";
            ButtonDanhSachTaiKhoan.Text = "    Quản lý tài khoản";
            ButtonDanhSachNhanVien.Text = "    Quản lý nhân viên";
            ButtonThongKe.Text = "    Thống kê";
            ButtonSaoLuuPhucHoi.Text = " Sao lưu phục hồi";
            PanelUser.Visible = true;
        }
        private void NotDisplayTextMenu()
        {
            ButtonTrangChu.Text = "";
            ButtonSoDoPhong.Text = "";
            ButtonDanhSachDatPhong.Text = "";
            ButtonDanhSachHoaDon.Text = "";
            ButtonDanhSachKhachHang.Text = "";
            ButtonPhong.Text = "";
            ButtonLoaiPhong.Text = "";
            ButtonDanhSachDichVu.Text = "";
            ButtonDanhSachTienNghi.Text = "";
            ButtonDanhSachTaiKhoan.Text = "";
            ButtonDanhSachNhanVien.Text = "";
            ButtonThongKe.Text = "";
            ButtonSaoLuuPhucHoi.Text = ""; // Thêm dòng này
            PanelUser.Visible = false;
        }
        private bool isDisplayed = true;
        private void PictureBoxMenu_Click(object sender, EventArgs e)
        {
            if (isDisplayed == true)
            {
                isDisplayed = false;
                Size size = new Size(65, Sidebar.Height);
                NotDisplayTextMenu();
                Sidebar.Size = size;
            }
            else
            {
                isDisplayed = true;
                Size size = new Size(262, Sidebar.Height);
                DisplayTextMenu();
                Sidebar.Size = size;
            }
        }

        private void linkLabelDangXuat_Click(object sender, EventArgs e)
        {
            using (FormLogin formLogin = new FormLogin())
            {
                this.Hide();
                formLogin.ShowDialog();
                this.Close();
            }
        }
        
        private void PictureBoxMenu_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBoxMenu.BackColor = Color.FromArgb(58, 130, 137);
        }

        private void PictureBoxMenu_MouseLeave(object sender, EventArgs e)
        {
            PictureBoxMenu.BackColor = Color.Transparent;
        }
        private void buttonFAQ_Click(object sender, EventArgs e)
        {
            using (var f = new RomanceHotel.GUI.FormFAQ())
            {
                f.ShowDialog(this);
            }
        }

        private void buttonChatbotAI_Click(object sender, EventArgs e)
        {
            using (var f = new RomanceHotel.GUI.FormChatbotAI())
            {
                f.ShowDialog(this);
            }
        }

        private void buttonVoice_Click(object sender, EventArgs e)
        {
            if (!isVoiceOn)
                StartVoiceControl();
            else
                StopVoiceControl();
        }

        private void StartVoiceControl()
        {
            try
            {
                if (recognizer != null) return;   // đã bật rồi

                recognizer = new SpeechRecognitionEngine();

                // Các lệnh giọng nói (tiếng Anh cho dễ nhận)
                Choices commands = new Choices();
                commands.Add(new string[]
{
    "room",
    "customer",
    "service",
    "invoice",
    "booking",
    "facility",
    "staff",
    "account",
    "report",
    "backup",
    "home",
    "layout",
    "class",
    "sign out",
    "logout",
    "stop voice"
});


                GrammarBuilder gb = new GrammarBuilder(commands);
                Grammar g = new Grammar(gb);

                recognizer.LoadGrammar(g);
                recognizer.SetInputToDefaultAudioDevice();

                recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
                recognizer.RecognizeCompleted += Recognizer_RecognizeCompleted;

                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                isVoiceOn = true;
                UpdateVoiceButtonUI();

                // Nếu thích có popup:
                // MessageBox.Show("Voice control: ON", "Voice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không khởi động được tính năng điều khiển bằng giọng nói:\n" + ex.Message,
                    "Voice control", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (recognizer != null)
                {
                    recognizer.Dispose();
                    recognizer = null;
                }
                isVoiceOn = false;
                UpdateVoiceButtonUI();
            }
        }

        private void StopVoiceControl()
        {
            try
            {
                if (recognizer != null)
                {
                    recognizer.SpeechRecognized -= Recognizer_SpeechRecognized;
                    recognizer.RecognizeCompleted -= Recognizer_RecognizeCompleted;
                    recognizer.RecognizeAsyncCancel();
                    recognizer.Dispose();
                    recognizer = null;
                }
            }
            catch
            {
                // bỏ qua
            }

            isVoiceOn = false;
            UpdateVoiceButtonUI();

            // MessageBox.Show("Voice control: OFF", "Voice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateVoiceButtonUI()
        {
            if (buttonVoice == null) return;

            if (isVoiceOn)
            {
                buttonVoice.BackColor = Color.FromArgb(233, 117, 32);  // cam nổi bật
                                                                       // nếu bạn có 2 icon khác nhau:
                                                                       // buttonVoice.BackgroundImage = Properties.Resources.voice_on;
                buttonVoice.FlatAppearance.BorderSize = 0;
                buttonVoice.Text = "";  // dùng icon
            }
            else
            {
                buttonVoice.BackColor = Color.Transparent;
                // buttonVoice.BackgroundImage = Properties.Resources.voice_off;
                buttonVoice.FlatAppearance.BorderSize = 0;
                buttonVoice.Text = "";  // hoặc "V"
            }
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string command = e.Result.Text.ToLower().Trim();

            // Độ tin cậy phải đủ cao, tránh nghe nhầm
            if (e.Result.Confidence < 0.60)
                return;

            if (this.IsDisposed) return;

            // Event chạy trên thread khác, nên đưa về UI thread
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => HandleVoiceCommand(command)));
            }
            else
            {
                HandleVoiceCommand(command);
            }
        }

        private void Recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            // Tạm thời không làm gì, để trống cũng không sao
            // Nếu sau này muốn auto start lại khi bị dừng thì xử lý ở đây
        }


        private void HandleVoiceCommand(string command)
        {
            switch (command)
            {
                case "home":
                    ButtonTrangChu.PerformClick();
                    break;

                case "layout":
                    ButtonSoDoPhong.PerformClick();
                    break;

                case "room":
                    ButtonPhong.PerformClick();
                    break;

                
                case "class":
                    ButtonLoaiPhong.PerformClick();
                    break;

                case "customer":
                    ButtonDanhSachKhachHang.PerformClick();
                    break;

                case "service":
                    ButtonDanhSachDichVu.PerformClick();
                    break;

                case "invoice":
                    ButtonDanhSachHoaDon.PerformClick();
                    break;

                case "booking":
                    ButtonDanhSachDatPhong.PerformClick();
                    if (activeForm is RomanceHotel.GUI.FormDanhSachPhieuThue fDatPhong)
                    {
                        fDatPhong.MoFormDatPhong();
                    }
                    break;

                case "facility":
                    ButtonDanhSachTienNghi.PerformClick();
                    break;

                case "staff":
                    ButtonDanhSachNhanVien.PerformClick();
                    break;

                case "account":
                    ButtonDanhSachTaiKhoan.PerformClick();
                    break;

                case "report":
                    ButtonThongKe.PerformClick();
                    break;

                case "backup":
                    ButtonSaoLuuPhucHoi.PerformClick();
                    break;

                // 🔴 ĐĂNG XUẤT
                case "logout":
                case "sign out":
                    linkLabelDangXuat_Click(null, EventArgs.Empty);
                    break;

                case "stop voice":
                    StopVoiceControl();
                    break;

                default:
                    break;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            StopVoiceControl();   // đảm bảo tắt hẳn
            base.OnFormClosed(e);
        }

        private void buttonDMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form đổi mật khẩu, truyền luôn tài khoản đang đăng nhập
            using (var f = new RomanceHotel.GUI.FormDoiMatKhau(this.taiKhoan))
            {
                f.ShowDialog(this);
            }
        }

        private void ButtonOnline_Click(object sender, EventArgs e)
        {
            SetAllButtonNormalColor();
            buttonOnline.BackColor = Color.FromArgb(233, 117, 32);
            buttonOnline.ForeColor = Color.White;

            openChildForm(new RomanceHotel.GUI.FormQuanLyDatPhongOnline(this, this.taiKhoan));
        }
        private void btnQuetQRHoaDon_Click(object sender, EventArgs e)
        {
            using (var frm = new RomanceHotel.GUI.FormQuetQRHoaDon())
            {
                frm.ShowDialog();
            }
        }

    }
}
