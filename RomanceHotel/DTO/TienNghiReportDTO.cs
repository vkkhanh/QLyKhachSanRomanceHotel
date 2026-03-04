using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.DTO
{
    public class TienNghiReportDTO
    {
        public TienNghiReportDTO() { }   // BẮT BUỘC CHO CRYSTAL REPORT

        public int STT { get; set; }
        public string MaTN { get; set; }
        public string TenTN { get; set; }
    }
}

