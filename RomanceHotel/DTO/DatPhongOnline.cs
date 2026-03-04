using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomanceHotel.DTO
{
    [Table("DatPhongOnline")]
    public partial class DatPhongOnline
    {
        [Key]
        public int MaYeuCau { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int SoKhach { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTra { get; set; }

        public TimeSpan? GioNhan { get; set; }

        [StringLength(10)]
        public string MaLPH { get; set; }

        [StringLength(500)]
        public string YeuCauThem { get; set; }

        public DateTime NgayTao { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }
    }
}
