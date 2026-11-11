using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SalesManagement.DTO;

namespace SalesManagement.DAL
{
    public class NhanVienDAL
    {
        public List<NhanVienDTO> GetAll()
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "SELECT MaNV, TenNV, SoDienThoai, ChucVu FROM NhanVien";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienDTO
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            TenNV = reader["TenNV"].ToString(),
                            SoDienThoai = reader["SoDienThoai"]?.ToString(),
                            ChucVu = reader["ChucVu"]?.ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}