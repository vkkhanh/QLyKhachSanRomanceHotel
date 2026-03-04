using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RomanceHotel.DTO
{
    public class PhongReportDTO
    {
        public int STT { get; set; }   // ← THÊM DÒNG NÀY
        public string MaPH { get; set; }
        public string TTPH { get; set; }
        public string TTDD { get; set; }
        public string GhiChu { get; set; }
        public string TenLPH { get; set; }
    }
}

