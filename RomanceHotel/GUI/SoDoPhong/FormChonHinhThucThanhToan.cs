using RomanceHotel.BUS;
using RomanceHotel.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormChonHinhThucThanhToan : Form
    {
        private CTDP ctdp;
        private TaiKhoan taiKhoan;
        private Phong phong;
        private decimal TongTien;

        public FormChonHinhThucThanhToan(CTDP ctdp, TaiKhoan tk, Phong phong, decimal tongTien)
        {
            InitializeComponent();
            this.ctdp = ctdp;
            this.taiKhoan = tk;
            this.phong = phong;
            this.TongTien = tongTien;

            lblTongTien.Text = TongTien.ToString("#,# VNĐ");
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormThanhToanTienMat frm = new FormThanhToanTienMat(TongTien, ctdp, taiKhoan, phong);
            frm.Owner = this.Owner;
            frm.ShowDialog();
            this.Close();
        }

        private void btnQuetQR_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormThanhToanQR frm = new FormThanhToanQR(TongTien, ctdp, taiKhoan, phong);
            frm.Owner = this.Owner;
            frm.ShowDialog();
            this.Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
