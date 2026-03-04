using ClosedXML.Excel;
using RomanceHotel.DAO;
using RomanceHotel.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace RomanceHotel.BUS
{
    internal class KhachHangBUS
    {
        
        private static KhachHangBUS instance;
        public static KhachHangBUS Instance
        {
            get { if (instance == null) instance = new KhachHangBUS(); return instance; }
            private set { instance = value; }
        }
        private KhachHangBUS() { }
        public List<KhachHang> GetKhachHangs()
        {
            return KhachHangDAO.Instance.GetKhachHangs();
        }
        public KhachHang FindKhachHang(string MaKH)
        {
            return KhachHangDAO.Instance.FindKhachHang(MaKH);
        }
        public void UpdateOrAdd(KhachHang khachHang)
        {
            KhachHangDAO.Instance.UpdateOrAdd(khachHang);
        }
        public void RemoveKH(KhachHang khachHang)
        {
            KhachHangDAO.Instance.RemoveKH(khachHang);
        }
        public List<KhachHang> FindKhachHangWithName(string TenKH)
        {
            return KhachHangDAO.Instance.FindKhachHangWithName(TenKH);
        }
        public string GetMaKHNext()
        {
            return KhachHangDAO.Instance.GetMaKHNext();
        }
        public KhachHang FindKHWithCCCD(string cccd)
        {
            return KhachHangDAO.Instance.FindKHWithCCCD(cccd);
        }

        public DataTable ImportFormExcelToDataTable(string filename)
        {
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            DataTable result = dataTable;
            DataTable temp = dataTable1;
            bool isHeader = true;
            // Sử dụng FileStream để mở tệp Excel
            using (var wb = new XLWorkbook(filename))
            {
                var ws = wb.Worksheet(1);
                // Lấy tên của các cột từ dòng header (dòng đầu tiên)
                foreach (var row in ws.RowsUsed())
                {
                    if (row.CellsUsed().Any(cell => !string.IsNullOrEmpty(cell.Value.ToString())))
                    {
                        if (isHeader)
                        {
                            foreach (var cell in row.Cells())
                            {
                                temp.Columns.Add(cell.Value.ToString());
                            }
                            isHeader = false;
                        }
                        else
                        {
                            DataRow dataRow = temp.NewRow();
                            int colIndex = 0;
                            foreach (var cell in row.Cells())
                            {
                                if (colIndex < temp.Columns.Count)
                                {
                                    dataRow[colIndex++] = cell.Value;
                                }
                                else
                                {
                                    // MessageBox.Show("Not fit !");
                                }
                            }
                            temp.Rows.Add(dataRow);
                        }
                    }
                }
                result = sort(temp);// sort dựa trên cột ID truyền vào 
            }
            return result;
        }

        private DataTable sort(DataTable dt)
        {
            DataTable dataTable = new DataTable();
            DataTable sortedTable = dataTable;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataView dv = dt.DefaultView;
                    dv.Sort = "MaKH ASC";
                    sortedTable = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sortedTable;
        }

        public List<KhachHang> GetKhachHangsTheoKhoangNgayThue(DateTime tuNgay, DateTime denNgay)
        {
            DateTime fromDate = tuNgay.Date;
            DateTime toDate = denNgay.Date;

            using (var db = new HotelDTO())
            {
                var query = from pt in db.PhieuThues
                            join kh in db.KhachHangs
                                on pt.MaKH equals kh.MaKH
                            where
                                DbFunctions.TruncateTime(pt.NgPT) >= fromDate &&
                                DbFunctions.TruncateTime(pt.NgPT) <= toDate &&
                                (pt.DaXoa == null || pt.DaXoa == false)
                            select kh;

                return query.Distinct().ToList();
            }
        }

    }
}
