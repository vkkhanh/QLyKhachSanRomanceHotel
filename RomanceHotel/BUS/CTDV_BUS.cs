using System;
using System.Collections.Generic;
using System.Linq;
using RomanceHotel.DTO;
using RomanceHotel.DAO;

namespace RomanceHotel.BUS
{
    internal class CTDV_BUS
    {
        private static CTDV_BUS instance;
        public static CTDV_BUS Instance
        {
            get
            {
                if (instance == null) instance = new CTDV_BUS();
                return instance;
            }
            private set { instance = value; }
        }

        private CTDV_BUS() { }

        // ===========================
        // LẤY DANH SÁCH CTDV (KHÔNG LỖI)
        // ===========================
        public List<CTDV> GetCTDVs()
        {
            return CTDV_DAO.Instance.GetCTDVs();
        }

        // ===========================
        // LẤY CTDV THEO MÃ CTDP
        // ===========================
        public List<CTDV> FindCTDV(string maCTDP)
        {
            return CTDV_DAO.Instance.FindCTDV(maCTDP);
        }

        // ===========================
        // THÊM HOẶC CẬP NHẬT LIST
        // ===========================
        public void InsertOrUpdateList(List<CTDV> cTDVs)
        {
            CTDV_DAO.Instance.InsertOrUpdateList(cTDVs);
        }

        // ===========================
        // TÍNH TIỀN DỊCH VỤ
        // ===========================
        public decimal TinhTienDV(string maCTDP)
        {
            try
            {
                var list = GetCTDVs()
                           .Where(x => x.MaCTDP == maCTDP && (x.DaXoa == null || x.DaXoa == false))
                           .ToList();

                decimal tong = 0;

                foreach (var dv in list)
                {
                    if (dv.ThanhTien > 0)
                        tong += dv.ThanhTien;
                    else
                        tong += dv.DonGia * dv.SL;
                }

                return tong;
            }
            catch
            {
                return 0;
            }
        }
    }
}
