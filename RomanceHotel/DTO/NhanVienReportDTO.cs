using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.DTO
{
    public class NhanVienReportDTO
    {
        public NhanVienReportDTO() { }  // BẮT BUỘC để Crystal Report load class

        public int STT { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
    }
}

