using RomanceHotel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanceHotel.DAO;

namespace RomanceHotel.BUS
{
    internal class LoaiPhongBUS
    {
        private static LoaiPhongBUS instance;
        public static LoaiPhongBUS Instance
        {
            get { if (instance == null) instance = new LoaiPhongBUS(); return instance; }
            private set { instance = value; }
        }
        private LoaiPhongBUS() { }
        public List<LoaiPhong> GetLoaiPhongs()
        {
            return LoaiPhongDAO.Instance.GetLoaiPhongs();
        }
        public LoaiPhong getLoaiPhong(string MaLP)
        {
            return LoaiPhongDAO.Instance.getLoaiPhong(MaLP);
        }
        public void AddOrUpdate(LoaiPhong loaiPhong)
        {
            LoaiPhongDAO.Instance.AddOrUpdate(loaiPhong);
        }
        public void RemoveLoaiPhong(LoaiPhong loaiPhong)
        {
            LoaiPhongDAO.Instance.RemoveLoaiPhong(loaiPhong);
        }
        public List<LoaiPhong> getLoaiPhongWithName(string TenLP)
        {
            return LoaiPhongDAO.Instance.getLoaiPhongWithName(TenLP);
        }
    }
}
