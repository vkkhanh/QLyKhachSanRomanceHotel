using RomanceHotel.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanceHotel.GUI.Reports
{
    public partial class FormInHoaDon : Form
    {
        public FormInHoaDon(List<HoaDonReportDTO> hdInfo,
                    List<HoaDonChiTietReportDTO> hdCT)
        {
            InitializeComponent();

            rptHoaDon rpt = new rptHoaDon();

            rpt.Database.Tables["HotelManagement_DTO_HoaDonReportDTO"]
                .SetDataSource(hdInfo);

            rpt.Database.Tables["HotelManagement_DTO_HoaDonChiTietReportDTO"]
                .SetDataSource(hdCT);

            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
