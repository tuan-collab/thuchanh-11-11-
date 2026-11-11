using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SalesManagement.DAL
{
    public class BaoCaoDAL
    {
        public decimal TinhTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE NgayLap BETWEEN @TuNgay AND @DenNgay";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public List<string> GetTop5SanPhamBanChay()
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = @"SELECT TOP 5 sp.TenSP, SUM(ct.SoLuong) AS TongBan
                                FROM ChiTietHoaDon ct
                                JOIN SanPham sp ON ct.MaSP = sp.MaSP
                                GROUP BY sp.MaSP, sp.TenSP
                                ORDER BY TongBan DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add($"{reader["TenSP"]} - Đã bán: {reader["TongBan"]} SP");
                    }
                }
            }
            return result;
        }
    }
}