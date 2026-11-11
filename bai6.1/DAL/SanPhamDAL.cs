using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SalesManagement.DTO;

namespace SalesManagement.DAL
{
    public class SanPhamDAL
    {
        public List<SanPhamDTO> Search(string keyword)
        {
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon FROM SanPham WHERE MaSP LIKE @Kw OR TenSP LIKE @Kw";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Kw", "%" + keyword + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SanPhamDTO
                        {
                            MaSP = reader["MaSP"].ToString(),
                            TenSP = reader["TenSP"].ToString(),
                            GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                            SoLuongTon = Convert.ToInt32(reader["SoLuongTon"])
                        });
                    }
                }
            }
            return list;
        }
    }
}