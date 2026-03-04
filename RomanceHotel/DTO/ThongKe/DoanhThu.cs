using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.DTO.ThongKe
{
    public class DoanhThu
    {
        public List<DoanhThuTheoNgay> List { get; set; }
        public decimal Total { get; set; }
        public DoanhThu (List<DoanhThuTheoNgay> list, decimal total)
        {
            List = list;
            Total = total;
        }
    }
}
