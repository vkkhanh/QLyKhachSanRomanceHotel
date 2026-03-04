using CrystalDecisions.CrystalReports.Engine;
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
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();
        }
        public void SetReport(ReportDocument report)
        {
            crvReport.ReportSource = report;
        }
    }
}
