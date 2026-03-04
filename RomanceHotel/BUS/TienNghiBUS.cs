using RomanceHotel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanceHotel.DAO;
using ClosedXML.Excel;
using System.Data;
using System.Windows.Forms;

namespace RomanceHotel.BUS
{
    internal class TienNghiBUS
    {
        private static TienNghiBUS instance;
        public static TienNghiBUS Instance
        {
            get { if (instance == null) instance = new TienNghiBUS(); return instance; }
            private set { instance = value; }
        }
        private TienNghiBUS() { }
        public List<TienNghi> GetTienNghis()
        {
            return TienNghiDAO.Instance.GetTienNghis();
        }
        public TienNghi FindTienNghi(string MaTN)
        {
            return TienNghiDAO.Instance.FindTienNghi(MaTN);
        }
        public void RemoveTN(TienNghi tienNghi) // try catch th có phòng có mã tiện nghi đó
        {
            TienNghiDAO.Instance.RemoveTN(tienNghi);
        }
        public void InsertOrUpdate(TienNghi tienNghi)
        {
            TienNghiDAO.Instance.InsertOrUpdate(tienNghi);
        }
        public List<TienNghi> FindTienNghiWithName(string name)
        {
            return TienNghiDAO.Instance.FindTienNghiWithName(name);
        }
        public string GetMaTNNext()
        {
            return TienNghiDAO.Instance.GetMaTNNext();
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
                    dv.Sort = "MaTN ASC";
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
