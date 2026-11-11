using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HRMManagement.DTO;

namespace HRMManagement.DAL
{
    public class PhongBanDAL
    {
        public List<PhongBanDTO> GetAll()
        {
            List<PhongBanDTO> list = new List<PhongBanDTO>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "SELECT MaPB, TenPB, MoTa FROM PhongBan";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhongBanDTO
                        {
                            MaPB = Convert.ToInt32(reader["MaPB"]),
                            TenPB = reader["TenPB"].ToString(),
                            MoTa = reader["MoTa"]?.ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}