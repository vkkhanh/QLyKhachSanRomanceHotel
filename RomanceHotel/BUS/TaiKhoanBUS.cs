using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;
using RomanceHotel.DAO;
using RomanceHotel.DTO;

namespace RomanceHotel.BUS
{
    internal class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;
        public static TaiKhoanBUS Instance
        {
            get { if (instance == null) instance = new TaiKhoanBUS(); return instance; }
            private set { instance = value; }
        }
        private TaiKhoanBUS() { }

        public bool checkLogin(string username, string password)
        {
            return TaiKhoanDAO.Instance.CheckLogin(username, password);
        }
        public int getQuyenTruyCap(string username)
        {
            return TaiKhoanDAO.Instance.GetQuyenTruyCap(username);
        }
        public List<TaiKhoan> GetTaiKhoans()
        {
            return TaiKhoanDAO.Instance.GetTaiKhoans();
        }
        public List<TaiKhoan> GetTaiKhoansWithUserName(string username)
        {
            return TaiKhoanDAO.Instance.GetTaiKhoansWithUserName(username);
        }
        public TaiKhoan CheckLegit(string username, string email)
        {
            return TaiKhoanDAO.Instance.CheckLegit(username, email);
        }
        public void AddOrUpdateTK(TaiKhoan taiKhoan)
        {
            TaiKhoanDAO.Instance.AddOrUpdateTK(taiKhoan);
        }
        public void RemoveTk(TaiKhoan taiKhoan)
        {
            TaiKhoanDAO.Instance.RemoveTk(taiKhoan);
        }
        public TaiKhoan GetTKDangNhap(string username)
        {
            return TaiKhoanDAO.Instance.GetTKDangNhap(username);
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
                    dv.Sort = "TenTK ASC";
                    sortedTable = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sortedTable;
        }
    }
}
