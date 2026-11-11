using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SalesManagement.DTO;

namespace SalesManagement.DAL
{
    public class KhachHangDAL
    {
        public List<KhachHangDTO> GetAll()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "SELECT MaKH, TenKH, DienThoai, DiemTichLuy FROM KhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHangDTO
                        {
                            MaKH = Convert.ToInt32(reader["MaKH"]),
                            TenKH = reader["TenKH"].ToString(),
                            DienThoai = reader["DienThoai"]?.ToString(),
                            DiemTichLuy = Convert.ToInt32(reader["DiemTichLuy"])
                        });
                    }
                }
            }
            return list;
        }
    }
}