using RomanceHotel.CTControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RomanceHotel.BUS;
using RomanceHotel.DTO;
using ApplicationSettings;
using RomanceHotel.DAO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace RomanceHotel.GUI
{
    public partial class FormSuaDatPhong : Form
    {
        //Fields
        private int borderRadius = 15;
        private int borderSize = 2;
        private Color borderColor = Color.White;
        private CTDP listPhongDaDat = new CTDP();
        private Image Add = Properties.Resources.Add; // Image for Button Thêm
        private Image Del = Properties.Resources.delete1; // Image for Button Hủy
        private KhachHang khachHang = new KhachHang();
        private int caseForm = 0;
        private int flagHoTen = 0;
        private TaiKhoan taiKhoan;
        private PhieuThue phieuThue;
        private string maPH;
        private DateTime CheckIn = DateTime.Now;
        private DateTime CheckOut = DateTime.Now;

        //Constructor
        public FormSuaDatPhong()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
            phieuThue.MaPT = PhieuThueBUS.Instance.GetMaPTNext();
        }
        public FormSuaDatPhong(TaiKhoan taiKhoan,PhieuThue phieuThue = null, string maPH = null)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.taiKhoan = taiKhoan;
            this.phieuThue = phieuThue;
            this.maPH = maPH;
            InitializeComponent();

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
        #region Draw Form
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
        private FormBoundsColors GetSameDark()
        {
            FormBoundsColors colors = new FormBoundsColors();
            colors.TopLeftColor = Color.FromArgb(67, 73, 73);
            colors.TopRightColor = Color.FromArgb(67, 73, 73);
            colors.BottomLeftColor = Color.FromArgb(67, 73, 73);
            colors.BottomRightColor = Color.FromArgb(67, 73, 73);
            return colors;
        }
        //Event Methods
        private void FormDatPhong_Paint(object sender, PaintEventArgs e)
        {
            //-> SMOOTH OUTER BORDER
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetSameDark();
            //fbColors = GetSame();
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
        private void FormDatPhong_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormDatPhong_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormDatPhong_Activated(object sender, EventArgs e)
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

        private void CTButtonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void setLoadComboBox()
        {
            // Lấy thông tin CheckIn và CheckOut từ listPhongDaDat
            DateTime checkIn = listPhongDaDat.CheckIn;
            DateTime checkOut = listPhongDaDat.CheckOut;

            // Xử lý CheckIn
            string strHourIn = checkIn.Hour > 12 ? (checkIn.Hour - 12).ToString("D2") : checkIn.Hour.ToString("D2");
            string strMinuteIn = checkIn.Minute.ToString("D2");
            string letterIn = checkIn.Hour >= 12 ? "   PM" : "   AM";
            if (checkIn.Hour == 0) strHourIn = "12"; // Trường hợp 12 giờ sáng

            cbBoxGioBatDau.Texts = strHourIn + ':' + strMinuteIn;
            cbBoxLetterBatDau.Texts = letterIn;

            // Xử lý CheckOut
            string strHourOut = checkOut.Hour > 12 ? (checkOut.Hour - 12).ToString("D2") : checkOut.Hour.ToString("D2");
            string strMinuteOut = checkOut.Minute.ToString("D2");
            string letterOut = checkOut.Hour >= 12 ? "   PM" : "   AM";
            if (checkOut.Hour == 0) strHourOut = "12"; // Trường hợp 12 giờ sáng

            cbBoxGioKetThuc.Texts = strHourOut + ':' + strMinuteOut;
            cbBoxLetterKetThuc.Texts = letterOut;

            // Set Date
            CTDatePickerNgayBD.Value = checkIn.Date;
            CTDatePickerNgayKT.Value = checkOut.Date;
        }

        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = label1;
                // Custom Dgv when loading Form
                DataGridView grid2 = gridPhongDaChon;
                LoadGridPhongDat();
                setLoadComboBox();
                LoadTenKH();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTenKH()
        {
            try
            {
                if(this.phieuThue!=null)
                {
                    caseForm = 1;
                    CTTextBoxNhapSDT.RemovePlaceholder();
                    CTTextBoxNhapDiaChi.RemovePlaceholder();
                    CTTextBoxNhapHoTen.RemovePlaceholder();
                    CTTextBoxNhapCCCD.RemovePlaceholder();
                    this.khachHang = KhachHangBUS.Instance.FindKhachHang(this.phieuThue.MaKH);
                    this.CTTextBoxNhapCCCD.Texts = khachHang.CCCD_Passport;
                    this.CTTextBoxNhapHoTen.Texts = khachHang.TenKH;
                    this.CTTextBoxNhapSDT.Texts = khachHang.SDT;
                    this.ComboBoxGioiTinh.Texts ="  "+ khachHang.GioiTinh;
                    this.CTTextBoxNhapDiaChi.Texts = khachHang.QuocTich;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        private void LoadGridPhongDat()
        {
            try
            {
                gridPhongDaChon.Rows.Clear();
                this.listPhongDaDat = CTDP_BUS.Instance.FindCTDPByIdPT(this.phieuThue.MaPT, this.maPH);
                if(this.listPhongDaDat!=null)
                {
                    
                    gridPhongDaChon.Rows.Add(listPhongDaDat.MaPH, listPhongDaDat.SoNguoi, listPhongDaDat.CheckIn.ToString("dd/MM/yyyy HH:mm:ss"), listPhongDaDat.CheckOut.ToString("dd/MM/yyyy HH:mm:ss"));
                       
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        #region Remove Room

        private void SetMaCTDP(CTDP cTDP)
        {
            try
            {
                int i = 1;
                int MaMax = CTDP_BUS.Instance.GetCTDPs().Count;
                int tong;
              
                tong = MaMax + i;
                if (tong < 10)
                {
                    cTDP.MaCTDP = "CTDP00" + tong.ToString();
                }
                else if (tong < 100)
                {
                    cTDP.MaCTDP = "CTDP0" + tong.ToString();
                }
                else
                    cTDP.MaCTDP = "CTDP" + tong.ToString();
                i++;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void gridPhongDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0 && x == 4)
            {
                // If click Remove new room
                DialogResult dialogresult = CTMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)
                {
                    try
                    {
                       
                        if (listPhongDaDat.CheckIn.ToString("dd/MM/yyyy HH:mm:ss") == gridPhongDaChon.Rows[y].Cells[2].Value.ToString() && listPhongDaDat.MaPH == gridPhongDaChon.Rows[y].Cells[0].Value.ToString())
                        {
                            CTDP_BUS.Instance.RemoveCTDP(listPhongDaDat);
                            SetMaCTDP(listPhongDaDat);
                            LoadGridPhongDat();
                            return;
                        }
                        
                    }
                    catch (Exception)
                    {
                        CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally{}
                }
            }         
        }
        #endregion

        #region UI Form
           

        private void gridPhongDaChon_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = gridPhongDaChon;
            int x = e.ColumnIndex, y = e.RowIndex;
            int[] arrX = { 0 };
            bool isExists = false;

            if (Array.IndexOf(arrX, x) != -1)
                isExists = true;

            if (y >= 0 && x == 4 || y == -1 && isExists)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        private void gridPhongDaChon_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = gridPhongDaChon;
            grid.Cursor = Cursors.Default;
        }
        #endregion

        #region Date and Time value changed
        private void setDate(DateTime dateTime, int flag)
        {
            if (flag == 1)
                this.CheckIn = dateTime.Date;
            else
                this.CheckOut = dateTime.Date;
        }

        private void setTime(string Time, string Letter, int flag)
        {
            Letter = Letter.Trim(' ');
            string[] time = Time.Split(':');
            int hour = int.Parse(time[0]);
            int minute = int.Parse(time[1]);
            if (Letter == "AM" && hour == 12 || Letter == "PM" && hour != 12)
                hour += 12;

            TimeSpan ts = new TimeSpan(hour, minute, 0);
            if (flag == 1)
                this.CheckIn += ts;
            else
                this.CheckOut += ts;
        }

        private void CTDatePickerNgayBD_ValueChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayBD.Value, 1);
            setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);
        }

        private void cbBoxGioBatDau_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayBD.Value, 1);
            setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);
        }

        private void cbBoxLetterBatDau_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayBD.Value, 1);
            setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);
        }

        private void CTDatePickerNgayKT_ValueChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayKT.Value, 2);
            setTime(cbBoxGioKetThuc.Texts, cbBoxLetterKetThuc.Texts, 2);
        }

        private void cbBoxGioKetThuc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayKT.Value, 2);
            setTime(cbBoxGioKetThuc.Texts, cbBoxLetterKetThuc.Texts, 2);
        }

        private void cbBoxLetterKetThuc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayKT.Value, 2);
            setTime(cbBoxGioKetThuc.Texts, cbBoxLetterKetThuc.Texts, 2);
        }
        #endregion

        private void updateKH()
        {
            try
            {
                khachHang.SDT = CTTextBoxNhapSDT.Texts;
                khachHang.QuocTich = CTTextBoxNhapDiaChi.Texts;
                khachHang.TenKH = CTTextBoxNhapHoTen.Texts;
                khachHang.CCCD_Passport = CTTextBoxNhapCCCD.Texts;
                khachHang.GioiTinh = this.ComboBoxGioiTinh.Texts.Trim(' ');

                KhachHangBUS.Instance.UpdateOrAdd(khachHang);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        void updateCTDP()
        {
            try
            {
                listPhongDaDat.CheckIn = this.CheckIn;
                listPhongDaDat.CheckOut = this.CheckOut;
                listPhongDaDat.MaPT = phieuThue.MaPT;
                listPhongDaDat.DaXoa = false;
                CTDP_BUS.Instance.UpdateOrAddCTDP(listPhongDaDat);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CTTextBoxNhapHoTen__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxNotNumber = sender as TextBox;
            textBoxNotNumber.KeyPress += TextBoxNotNumber_KeyPress;
        }

        private void TextBoxNotNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }
  
        private void CTTextBoxNhapCCCD__TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.MaxLength = 12;
            textBox.KeyPress += TextBoxOnlyNumber_KeyPress;
            if (caseForm == 0)
            {
                if (KhachHangBUS.Instance.FindKHWithCCCD(textBox.Text) != null)
                {
                    CTMessageBox.Show("Đã tồn tại số CCCD/Passport này trong danh sách.\r\nThông tin sẽ được tự động điền.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CTTextBoxNhapSDT.RemovePlaceholder();
                    CTTextBoxNhapDiaChi.RemovePlaceholder();
                    CTTextBoxNhapHoTen.RemovePlaceholder();
                    // CTTextBoxNhapCCCD.RemovePlaceholder();


                    khachHang = KhachHangBUS.Instance.FindKHWithCCCD(textBox.Text);
                    CTTextBoxNhapSDT.Texts = khachHang.SDT;
                    CTTextBoxNhapDiaChi.Texts = khachHang.QuocTich;
                    ComboBoxGioiTinh.Texts = khachHang.GioiTinh;
                    CTTextBoxNhapHoTen.Texts = khachHang.TenKH;
                    ComboBoxGioiTinh.Focus();
                    flagHoTen = 1;
                }
            }
        }

        private void CTTextBoxNhapSDT__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxOnlyNumber = sender as TextBox;
            textBoxOnlyNumber.MaxLength = 10;
            textBoxOnlyNumber.KeyPress += TextBoxOnlyNumber_KeyPress;
        }

        private void TextBoxOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxOnlyNumber(e);
        }

        private void CTTextBoxNhapDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridPhongDaChon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ctPanel2_Load(object sender, EventArgs e)
        {

        }

        private void CTButtonOK_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string pattern = @"^0\d{9}$";
            Regex regex = new Regex(pattern);
            if (listPhongDaDat == null)
            {
                CTMessageBox.Show("Chưa thêm thông tin đặt phòng", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.CTTextBoxNhapCCCD.Texts != "" && this.CTTextBoxNhapDiaChi.Texts != "" && this.CTTextBoxNhapHoTen.Texts != "" && this.ComboBoxGioiTinh.Texts != "  Giới tính")
            {
                if (CTTextBoxNhapCCCD.Texts.Length != 12 && CTTextBoxNhapCCCD.Texts.Length != 7)
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ số CCCD/Passport.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!regex.IsMatch(CTTextBoxNhapSDT.Texts))
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng SĐT.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    updateKH();
                    updateCTDP();
                    flag = 1;
                }
                catch (Exception ex)
                {
                    CTMessageBox.Show(ex.Message, "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (flag == 1)
                        CTMessageBox.Show("Sửa phòng thành công.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
