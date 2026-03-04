using RomanceHotel.CTControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormTrangChu : Form
    {
        private FormMain formMain;
        public FormTrangChu()
        {
            InitializeComponent();
        }
        public FormTrangChu(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }
    }
}
