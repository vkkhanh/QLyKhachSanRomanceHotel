using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.DTO
{
    public class BaoCaoDoanhThuDichVuDTO
    {
        public int STT { get; set; }
        public string MaCTDP { get; set; }

        public string MaDV { get; set; }
        public string TenDV { get; set; }   // ➜ THÊM DÒNG NÀY

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string NgayIn { get; set; }

        public decimal TongDoanhThu { get; set; }
        public int TongLanSuDung { get; set; }
    }
}
