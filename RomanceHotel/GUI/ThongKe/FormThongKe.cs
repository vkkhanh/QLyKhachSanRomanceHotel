using RomanceHotel.DAO;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RomanceHotel.BUS;
using RomanceHotel.CTControls;
using RomanceHotel.DTO.ThongKe;

namespace RomanceHotel.GUI.ThongKe
{
    public partial class FormThongKe : Form
    {
        private FormMain formMain;
        private ThongKeBUS tkBUS;
        public FormThongKe()
        {
            InitializeComponent();
        }
        public FormThongKe(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            dtpNgayBD.Value = DateTime.Today.AddDays(-7);
            dtpNgayKT.Value = DateTime.Now;
            Button7Ngay.Select();
            Button7Ngay.BackColor = Color.FromArgb(30, 119, 148);
            Button7Ngay.ForeColor = Color.White;
            tkBUS = new ThongKeBUS();
            LoadData();
        }

        private void setButtonNormal()
        {
            ButtonTuyChon.BackColor
                = ButtonHomNay.BackColor
                = Button7Ngay.BackColor
                = Button30Ngay.BackColor 
                = Button6Thang.BackColor = Color.FromArgb(207, 236, 236);
            ButtonTuyChon.ForeColor
                = ButtonHomNay.ForeColor
                = Button7Ngay.ForeColor
                = Button30Ngay.ForeColor
                = Button6Thang.ForeColor = Color.Black;
        }
        private void ButtonTuyChon_Click(object sender, EventArgs e)
        {
            if (dtpNgayKT.Value.Date < dtpNgayBD.Value.Date)
            {
                CTMessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            setButtonNormal();
            ButtonOK.Enabled = true;
            ButtonTuyChon.BackColor = Color.FromArgb(30, 119, 148);
            ButtonTuyChon.ForeColor = Color.White;
            LoadData();
        }

        private void ButtonHomNay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            ButtonHomNay.BackColor = Color.FromArgb(30, 119, 148);
            ButtonHomNay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.Date;
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }

        private void Button7Ngay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button7Ngay.BackColor = Color.FromArgb(30, 119, 148);
            Button7Ngay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-7);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }

        private void Button30Ngay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button30Ngay.BackColor = Color.FromArgb(30, 119, 148);
            Button30Ngay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-30);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }

        private void Button6Thang_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button6Thang.BackColor = Color.FromArgb(30, 119, 148);
            Button6Thang.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-180);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (dtpNgayKT.Value.Date < dtpNgayBD.Value.Date)
            {
                CTMessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            setButtonNormal();
            ButtonTuyChon.BackColor = Color.FromArgb(30, 119, 148);
            ButtonTuyChon.ForeColor = Color.White;
            LoadData();
        }
        
        private void LoadData()
        {
            bool dateRangeChanged = tkBUS.IsDateRangeChanged(dtpNgayBD.Value, dtpNgayKT.Value);
            if (!dateRangeChanged)
                return;

            try
            {
                DoanhThu doanhThuThuongDon = tkBUS.GetDoanhThuThuongDon(dtpNgayBD.Value, dtpNgayKT.Value);
                DoanhThu doanhThuThuongDoi = tkBUS.GetDoanhThuThuongDoi(dtpNgayBD.Value, dtpNgayKT.Value);
                DoanhThu doanhThuVipDon = tkBUS.GetDoanhThuVipDon(dtpNgayBD.Value, dtpNgayKT.Value);
                DoanhThu doanhThuVipDoi = tkBUS.GetDoanhThuVipDoi(dtpNgayBD.Value, dtpNgayKT.Value);
                decimal doanhThuDichVu = tkBUS.GetDoanhThuDichVu(dtpNgayBD.Value, dtpNgayKT.Value);
                SoPhongDat soPhongDat = tkBUS.GetSoPhongDat(dtpNgayBD.Value, dtpNgayKT.Value);
                List<KeyValuePair<string, int>> dichVu = tkBUS.GetDichVuBieuDo(dtpNgayBD.Value, dtpNgayKT.Value);
                Top1DoanhThu loaiPhongDoanhThuCaoNhat = tkBUS.GetLoaiPhongDoanhThuCaoNhat(dtpNgayBD.Value, dtpNgayKT.Value);
                Top1DoanhThu dichVuDoanhThuCaoNhat = tkBUS.GetDichVuDoanhThuCaoNhat(dtpNgayBD.Value, dtpNgayKT.Value);
                Top1LoaiPhong loaiPhongDatNhieuNhat = tkBUS.GetLoaiPhongDatNhieuNhat(dtpNgayBD.Value, dtpNgayKT.Value);

                chartDoanhThuThue.Series[0].Points.Clear();
                chartDoanhThuThue.Series[1].Points.Clear();
                chartDoanhThuThue.Series[2].Points.Clear();
                chartDoanhThuThue.Series[3].Points.Clear();

                foreach (DoanhThuTheoNgay item in doanhThuThuongDon.List)
                {
                    chartDoanhThuThue.Series[0].Points.AddXY(item.Date, item.TotalAmount);
                }
                foreach (DoanhThuTheoNgay item in doanhThuThuongDoi.List)
                {
                    chartDoanhThuThue.Series[1].Points.AddXY(item.Date, item.TotalAmount);
                }
                foreach (DoanhThuTheoNgay item in doanhThuVipDon.List)
                {
                    chartDoanhThuThue.Series[2].Points.AddXY(item.Date, item.TotalAmount);
                }
                foreach (DoanhThuTheoNgay item in doanhThuVipDoi.List)
                {
                    chartDoanhThuThue.Series[3].Points.AddXY(item.Date, item.TotalAmount);
                }

                chartSoPhongDat.DataSource = soPhongDat.List;
                chartSoPhongDat.Series[0].XValueMember = "Date";
                chartSoPhongDat.Series[0].YValueMembers = "TotalAmount";
                chartSoPhongDat.DataBind();

                chartDichVu.DataSource = dichVu;
                chartDichVu.Series[0].XValueMember = "Key";
                chartDichVu.Series[0].YValueMembers = "Value";
                chartDichVu.DataBind();

                decimal tongDoanhThuThue =
                    doanhThuThuongDon.Total +
                    doanhThuThuongDoi.Total +
                    doanhThuVipDon.Total +
                    doanhThuVipDoi.Total;
                DoanhThuThue.Text = tongDoanhThuThue.ToString("#,#");
                DoanhThuDichVu.Text = doanhThuDichVu.ToString("#,#");
                SoPhongDat.Text = soPhongDat.Total.ToString();
                
                TenLoaiPhongDoanhThuCaoNhat.Text = loaiPhongDoanhThuCaoNhat.Name;
                DoanhThuLoaiPhongCaoNhat.Text = loaiPhongDoanhThuCaoNhat.Value.ToString("#,#");

                TenLoaiPhongDatNhieuNhat.Text = loaiPhongDatNhieuNhat.Name;
                SoLanDatLoaiPhongNhieuNhat.Text = loaiPhongDatNhieuNhat.Value.ToString();

                TenDichVuDoanhThuCaoNhat.Text = dichVuDoanhThuCaoNhat.Name;
                DoanhThuDichVuCaoNhat.Text = dichVuDoanhThuCaoNhat.Value.ToString("#,#");
            }
            catch (Exception e)
            {
                CTMessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoCao_button_Click(object sender, EventArgs e)
        {
            // Lấy khoảng thời gian đang lọc ở form thống kê
            DateTime fromDate = dtpNgayBD.Value.Date;
            DateTime toDate = dtpNgayKT.Value;

            using (var frm = new FormBaoCaoDoanhThu(fromDate, toDate))
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                
                frm.ShowDialog(this);
            }
        }


    }
}
