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

namespace RomanceHotel.BUS
{
    internal class NhanVienBUS
    {
        private static NhanVienBUS instance;
        public static NhanVienBUS Instance
        {
            get { if (instance == null) instance = new NhanVienBUS(); return instance; }
            private set { instance = value; }
        }
        public List<NhanVien> GetAllNhanViens()
        {
            return NhanVienDAO.Instance.GetAllNhanViens();
        }
        private NhanVienBUS() { }
        public List<NhanVien> GetNhanViens()
        {
            return NhanVienDAO.Instance.GetNhanViens();
        }
        public NhanVien GetNhanVien(string MaNV)
        {
            return NhanVienDAO.Instance.GetNhanVien(MaNV);
        }
        public void UpdateOrInsert(NhanVien nhanVien)
        {
            NhanVienDAO.Instance.UpdateOrInsert(nhanVien);
        }
        public void RemoveNhanVien(NhanVien nhanVien)
        {
            NhanVienDAO.Instance.RemoveNhanVien(nhanVien);
        }
        public List<NhanVien> GetNhanViensWithName(string tenNV)
        {
            return NhanVienDAO.Instance.GetNhanViensWithName(tenNV);
        }
        public string GetMaNVNext()
        {
            return NhanVienDAO.Instance.GetMaNVNext();
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
                    dv.Sort = "MaNV ASC";
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
