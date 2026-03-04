using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.DTO
{
    public class DichVuReportDTO
    {
        public int STT { get; set; }        // Số thứ tự
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public decimal DonGia { get; set; }
        public int SLConLai { get; set; }
    }
}



