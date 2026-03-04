using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.DTO
{
    public class TaiKhoanReportDTO
    {
        public TaiKhoanReportDTO() { }  // Crystal Report BẮT BUỘC phải có constructor rỗng

        public int STT { get; set; }
        public string TenTK { get; set; }
        public string TenNhanVien { get; set; }
        public int CapDoQuyen { get; set; }
    }
}

