using RomanceHotel.CTControls;
using RomanceHotel.DAO;
using RomanceHotel.DTO.ThongKe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanceHotel.BUS
{
    internal class ThongKeBUS
    {
        private readonly ThongKeDAO thongKeDAO;
        public DateTime CurrentStartDate { get; set; }
        public DateTime CurrentEndDate { get; set; }

        public ThongKeBUS()
        {
            thongKeDAO = new ThongKeDAO();
        }

        public bool IsDateRangeChanged(DateTime startDate, DateTime endDate)
        {
            DateTime start = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
            DateTime end = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

            bool changed = !start.Equals(this.CurrentStartDate) || !end.Equals(this.CurrentEndDate);

            if (changed)
            {
                this.CurrentStartDate = start;
                this.CurrentEndDate = end;
            }

            return changed;
        }

        public DoanhThu GetDoanhThuThuongDon(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetDoanhThuThuongDon(startDate, endDate);
        }
        public DoanhThu GetDoanhThuThuongDoi(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetDoanhThuThuongDoi(startDate, endDate);
        }
        public DoanhThu GetDoanhThuVipDon(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetDoanhThuVipDon(startDate, endDate);
        }
        public DoanhThu GetDoanhThuVipDoi(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetDoanhThuVipDoi(startDate, endDate);
        }
        public decimal GetDoanhThuDichVu(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetDoanhThuDichVu(startDate, endDate);
        }

        public SoPhongDat GetSoPhongDat(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetSoPhongDat(startDate, endDate);
        }

        public List<KeyValuePair<string, int>> GetDichVuBieuDo(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetDichVuBieuDo(startDate, endDate);
        }

        public Top1DoanhThu GetLoaiPhongDoanhThuCaoNhat(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetLoaiPhongDoanhThuCaoNhat(startDate, endDate);
        }

        public Top1DoanhThu GetDichVuDoanhThuCaoNhat(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetDichVuDoanhThuCaoNhat(startDate, endDate);
        }

        public Top1LoaiPhong GetLoaiPhongDatNhieuNhat(DateTime startDate, DateTime endDate)
        {
            return thongKeDAO.GetLoaiPhongDatNhieuNhat(startDate, endDate);
        }
    }
}

