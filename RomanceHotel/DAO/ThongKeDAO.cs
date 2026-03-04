using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using RomanceHotel.DTO.ThongKe;

namespace RomanceHotel.DAO
{
    internal class ThongKeDAO
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HotelDTO"].ConnectionString;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        public ThongKeDAO()
        {

        }

        private IEnumerable<TResult> GroupOrdersBy<TResult>(
            IEnumerable<KeyValuePair<DateTime, decimal>> resultTable,
            Func<KeyValuePair<DateTime, decimal>, string> groupByFunc,
            Func<IGrouping<string, KeyValuePair<DateTime, decimal>>, TResult> selector)
        {
            var groupedOrders = from results in resultTable
                                group results by groupByFunc(results)
                                into order
                                select selector(order);
            return groupedOrders;
        }

        private List<DoanhThuTheoNgay> GroupResults(List<KeyValuePair<DateTime, decimal>> results, DateTime startDate, DateTime endDate)
        {
            int days = (endDate - startDate).Days;
            //Group by Hours
            if (days <= 1)
            {
                return GroupOrdersBy(
                    results,
                    result => result.Key.ToString("hh tt"),
                    order => new DoanhThuTheoNgay
                    {
                        Date = order.Key,
                        TotalAmount = order.Sum(amount => amount.Value)
                    }
                ).ToList();
            }
            //Group by Days
            else if (days <= 30)
            {
                return GroupOrdersBy(
                    results,
                    result => result.Key.ToString("dd MMM"),
                    order => new DoanhThuTheoNgay
                    {
                        Date = order.Key,
                        TotalAmount = order.Sum(amount => amount.Value)
                    }
                ).ToList();
            }
            //Group by Weeks
            else if (days <= 92)
            {
                return (from orderList in results
                        group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                            orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                    into order
                        select new DoanhThuTheoNgay
                        {
                            Date = "Week " + order.Key.ToString(),
                            TotalAmount = order.Sum(amount => amount.Value)
                        }).ToList();
            }
            //Group by Months
            else if (days <= (365 * 2))
            {
                bool isYear = days <= 365;
                return (from orderList in results
                        group orderList by orderList.Key.ToString("MMM yyyy")
                    into order
                        select new DoanhThuTheoNgay
                        {
                            Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                            TotalAmount = order.Sum(amount => amount.Value)
                        }).ToList();
            }
            //Group by Years
            else
            {
                return GroupOrdersBy(
                    results,
                    result => result.Key.ToString("yyyy"),
                    order => new DoanhThuTheoNgay
                    {
                        Date = order.Key,
                        TotalAmount = order.Sum(amount => amount.Value)
                    }
                ).ToList();
            }
        }
        private List<SoPhongTheoNgay> GroupSoPhong(List<KeyValuePair<DateTime, int>> results, DateTime startDate, DateTime endDate)
        {
            int days = (endDate - startDate).Days;

            //Group by Hours
            if (days <= 1)
            {
                return (from orderList in results
                        group orderList by orderList.Key.ToString("hh tt")
                                    into order
                        select new SoPhongTheoNgay
                        {
                            Date = order.Key,
                            TotalAmount = order.Sum(amount => amount.Value)
                        }).ToList();
            }
            //Group by Days
            else if (days <= 30)
            {
                return (from orderList in results
                        group orderList by orderList.Key.ToString("dd MMM")
                                   into order
                        select new SoPhongTheoNgay
                        {
                            Date = order.Key,
                            TotalAmount = order.Sum(amount => amount.Value)
                        }).ToList();
            }
            //Group by Weeks
            else if (days <= 92)
            {
                return (from orderList in results
                        group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                      orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                   into order
                        select new SoPhongTheoNgay
                        {
                            Date = "Week " + order.Key.ToString(),
                            TotalAmount = order.Sum(amount => amount.Value)
                        }).ToList();
            }
            //Group by Months
            else if (days <= (365 * 2))
            {
                bool isYear = days <= 365 ? true : false;
                return (from orderList in results
                        group orderList by orderList.Key.ToString("MMM yyyy")
                                   into order
                        select new SoPhongTheoNgay
                        {
                            Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                            TotalAmount = order.Sum(amount => amount.Value)
                        }).ToList();
            }
            //Group by Years
            else
            {
                return (from orderList in results
                        group orderList by orderList.Key.ToString("yyyy")
                                   into order
                        select new SoPhongTheoNgay
                        {
                            Date = order.Key,
                            TotalAmount = order.Sum(amount => amount.Value)
                        }).ToList();
            }
        }
        public DoanhThu GetDoanhThuThuongDon(DateTime startDate, DateTime endDate)
        {
            List<DoanhThuTheoNgay> list = new List<DoanhThuTheoNgay>();
            decimal total = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select NgHD, SUM(ThanhTien)
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong
                                              on Phong.MaPH = CTDP.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'NOR01' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                              group by NgHD
                                              order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        total += (decimal)reader[1];
                    }

                    reader.Close();

                    list = GroupResults(resultTable, startDate, endDate);
                }
            }

            return new DoanhThu(list, total);
        }
        public DoanhThu GetDoanhThuThuongDoi(DateTime startDate, DateTime endDate)
        {
            List<DoanhThuTheoNgay> list = new List<DoanhThuTheoNgay>();
            decimal total = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select NgHD, SUM(ThanhTien)
                                                from HoaDon inner join CTDP
                                                on HoaDon.MaCTDP = CTDP.MaCTDP
                                                inner join Phong
                                                on Phong.MaPH = CTDP.MaPH
                                                inner join LoaiPhong
                                                on LoaiPhong.MaLPH = Phong.MaLPH
                                                where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'NOR02' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                                group by NgHD, CTDP.CheckIn, CTDP.CheckOut
                                                order by NgHD asc
                                                    ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        total += (decimal)reader[1];
                    }

                    reader.Close();
                    list = GroupResults(resultTable, startDate, endDate);
                }
            }

            return new DoanhThu(list, total);
        }
        public DoanhThu GetDoanhThuVipDon(DateTime startDate, DateTime endDate)
        {
            List<DoanhThuTheoNgay> list = new List<DoanhThuTheoNgay>();
            decimal total = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select NgHD, SUM(ThanhTien)
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong
                                              on Phong.MaPH = CTDP.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'VIP01' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán' 
                                              group by NgHD, CTDP.CheckIn, CTDP.CheckOut
                                              order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        total += (decimal)reader[1];
                    }

                    reader.Close();
                    list = GroupResults(resultTable, startDate, endDate);
                }
            }

            return new DoanhThu(list, total);
        }
        public DoanhThu GetDoanhThuVipDoi(DateTime startDate, DateTime endDate)
        {
            List<DoanhThuTheoNgay> list = new List<DoanhThuTheoNgay>();
            decimal total = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select NgHD, SUM(ThanhTien)
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong
                                              on Phong.MaPH = CTDP.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'VIP02' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán' 
                                              group by NgHD, CTDP.CheckIn, CTDP.CheckOut
                                              order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        total += (decimal)reader[1];
                    }

                    reader.Close();
                    list = GroupResults(resultTable, startDate, endDate);
                }
            }

            return new DoanhThu(list, total);
        }
        public decimal GetDoanhThuDichVu(DateTime startDate, DateTime endDate)
        {
            decimal total = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"select DichVu.MaDV, ThanhTien
                                            from CTDV inner join HoaDon
                                            on CTDV.MaCTDP = HoaDon.MaCTDP
                                            inner join DichVu
                                            on DichVu.MaDV = CTDV.MaDV
                                            where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                            group by DichVu.MaDV, NgHD, ThanhTien, HoaDon.MaHD
                                            order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        total += (decimal)reader[1];
                    }
                    reader.Close();
                }
            }
            return total;
        }
        public SoPhongDat GetSoPhongDat(DateTime startDate, DateTime endDate)
        {
            List<SoPhongTheoNgay> list = new List<SoPhongTheoNgay>();
            int total = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select NgPT, count(*) as SoPhongDat
                                                  from PhieuThue inner join CTDP
                                                  on CTDP.MaPT = PhieuThue.MaPT
                                                  where PhieuThue.DaXoa = 0 and NgPT between @fromDate and @toDate
                                                  group by NgPT, MaPH
                                                  order by NgPT asc
                                                ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, int>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, int>((DateTime)reader[0], (int)reader[1])
                            );
                        total += (int)reader[1];
                    }

                    reader.Close();
                    list = GroupSoPhong(resultTable, startDate, endDate);
                }

                return new SoPhongDat
                {
                    List = list,
                    Total = total
                };
            }
        }
        public List<KeyValuePair<string, int>> GetDichVuBieuDo(DateTime startDate, DateTime endDate)
        {
            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select top 5 TenDV, sum(SL)
                                                from CTDV inner join HoaDon
                                                on CTDV.MaCTDP = HoaDon.MaCTDP
                                                inner join DichVu
                                                on DichVu.MaDV = CTDV.MaDV
                                                where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                                group by DichVu.MaDV, TenDV
                                                order by sum(SL) desc";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public Top1DoanhThu GetLoaiPhongDoanhThuCaoNhat(DateTime startDate, DateTime endDate)
        {
            string name = "";
            decimal revenue = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select top 1 TenLPH, HoaDon.TriGia
	                                          from HoaDon inner join CTDP
	                                          on HoaDon.MaCTDP = CTDP.MaCTDP
	                                          inner join Phong
	                                          on Phong.MaPH = CTDP.MaPH
	                                          inner join LoaiPhong
	                                          on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
	                                          group by LoaiPhong.MaLPH, TenLPH, HoaDon.TriGia
                                              order by TriGia desc";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = (string)reader[0];
                        revenue = (decimal)reader[1];
                    }
                    reader.Close();
                }
            }
            return new Top1DoanhThu
            {
                Name = name,
                Value = revenue
            };
        }
        public Top1DoanhThu GetDichVuDoanhThuCaoNhat(DateTime startDate, DateTime endDate)
        {
            string name = "";
            decimal revenue = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select top 1 TenDV, SUM(ThanhTien) as DoanhThu
                                                from DichVu inner join CTDV
                                                on DichVu.MaDV = CTDV.MaDV
                                                inner join HoaDon
                                                on CTDV.MaCTDP = HoaDon.MaCTDP
                                                where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                                group by DichVu.MaDV, TenDV, CTDV.DonGia
                                                order by SUM(ThanhTien) desc";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = (string)reader[0];
                        revenue = (decimal)reader[1];
                    }
                    reader.Close();
                }
            }
            return new Top1DoanhThu
            {
                Name = name,
                Value = revenue
            };
        }
        public Top1LoaiPhong GetLoaiPhongDatNhieuNhat(DateTime startDate, DateTime endDate)
        {
            string name = "";
            int count = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    command.CommandText = @"  select top 1 TenLPH, COUNT(CTDP.MaCTDP) AS SoLanDat
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong 
                                              on CTDP.MaPH = Phong.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                              group by TenLPH, LoaiPhong.MaLPH
                                              order by COUNT(CTDP.MaCTDP) desc";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = (string)reader[0];
                        count = (int)reader[1];
                    }
                    reader.Close();
                }
            }
            return new Top1LoaiPhong
            {
                Name = name,
                Value = count
            };
        }
    }
}