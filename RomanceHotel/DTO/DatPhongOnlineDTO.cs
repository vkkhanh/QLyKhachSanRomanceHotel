using System;

namespace RomanceHotel.DTO
{
    public class DatPhongOnlineDTO
    {
        public int MaYeuCau { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int SoKhach { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public TimeSpan? GioNhan { get; set; }
        public string MaLPH { get; set; }
        public string YeuCauThem { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
    }
}
