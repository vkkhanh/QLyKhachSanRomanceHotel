using RomanceHotel.CTControls;
using RomanceHotel.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanceHotel.DAO
{
    internal class PhieuThueDAO
    {
        HotelDTO db = new HotelDTO();
        private static PhieuThueDAO instance;
        public static PhieuThueDAO Instance
        {
            get { if (instance == null) instance = new PhieuThueDAO(); return instance; }
            private set { instance = value; }
        }
        private PhieuThueDAO() { }
        public List<PhieuThue> GetPhieuThues()
        {
            return db.PhieuThues.Where(p => p.DaXoa == false).ToList();
        }
        public PhieuThue GetPhieuThue(string MaPT)
        {
            return db.PhieuThues.Find(MaPT);
        }
        public void UpdatePhieuThue(PhieuThue phieuThue)
        {
            try
            {
                HotelDTO db = new HotelDTO();
                phieuThue.DaXoa = false;
                phieuThue.NhanVien = db.NhanViens.Find(phieuThue.MaNV);
                phieuThue.KhachHang = db.KhachHangs.Find(phieuThue.MaKH);
                db.PhieuThues.AddOrUpdate(phieuThue);
                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public List<PhieuThue> GetPhieuThuesWithNameCus(string searchTerm)
        {
          
            return db.PhieuThues.Where(p =>
                (p.MaPT.Contains(searchTerm) ||
                    p.KhachHang.TenKH.Contains(searchTerm) ||
                    p.NhanVien.TenNV.Contains(searchTerm)) &&
                    p.DaXoa == false
            ).ToList();
            
        }

        public List<PhieuThue> GetPhieuThuesWithDate(DateTime dateTime)
        {
            return db.PhieuThues.Where(p => ( 
                p.NgPT.Month == dateTime.Month && 
                p.NgPT.Year == dateTime.Year && 
                p.NgPT.Day == dateTime.Day && 
                p.DaXoa == false)).ToList();
        }

        public List<PhieuThue> GetPhieuThuesWithDateAndName(DateTime dateTime, string name)
        {
            return db.PhieuThues.Where(p => (
                (p.MaPT.Contains(name) ||
                p.KhachHang.TenKH.Contains(name) ||
                p.NhanVien.TenNV.Contains(name)) &&
                p.NgPT.Month == dateTime.Month &&
                p.NgPT.Year == dateTime.Year &&
                p.NgPT.Day == dateTime.Day &&
                p.DaXoa == false)).ToList();
        }

        public string GetMaPTNext()
        {
            List<PhieuThue> PT = db.PhieuThues.ToList();
            string MaMax = PT[PT.Count - 1].MaPT.ToString();
            MaMax = MaMax.Substring(MaMax.Length - 3, 3);
            int max = int.Parse(MaMax);
            max++;
            if (max < 10)
            {
                return "PT00" + max.ToString();
            }
            else if (max < 100)
            {
                return "PT0" + max.ToString();
            }
            return "PT" + max.ToString();
        }
        public void RemoveAllPhieuThueWithMaKH(List<PhieuThue> phieuThues)
        {
                
            if(phieuThues!=null)
                foreach(PhieuThue phieuThue in phieuThues)
                {
                    db.PhieuThues.Remove(phieuThue);
                }
            db.SaveChanges();
        }
    }
}
