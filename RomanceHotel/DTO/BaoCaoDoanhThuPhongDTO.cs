using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.DTO
{
    public class BaoCaoDoanhThuPhongDTO
    {
        public int STT { get; set; }
        public string MaCTDP { get; set; }
        public string MaPhong { get; set; }
        public string LoaiPhong { get; set; }
        public string HinhThucThue { get; set; }

        public System.DateTime CheckIn { get; set; }
        public System.DateTime CheckOut { get; set; }

        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        // Thông tin chung cho header report
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string NgayIn { get; set; }

        public decimal TongDoanhThu { get; set; }
        public int TongLuotThue { get; set; }
        public int SoPhongDuocThue { get; set; }
    }
}
