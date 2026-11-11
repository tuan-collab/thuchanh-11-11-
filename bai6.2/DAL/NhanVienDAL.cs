using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HRMManagement.DTO;

namespace HRMManagement.DAL
{
    public class NhanVienDAL
    {
        public List<NhanVienDTO> Search(string keyword, int? maPB)
        {
            List<NhanVienDTO> list = new List<NhanVienDTO>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = @"SELECT nv.MaNV, nv.HoTen, nv.NgaySinh, nv.CCCD, nv.MaPB, pb.TenPB, nv.LuongCoBan, nv.HeSoLuong 
                                FROM NhanVien nv 
                                JOIN PhongBan pb ON nv.MaPB = pb.MaPB 
                                WHERE (nv.HoTen LIKE @Kw OR nv.CCCD LIKE @Kw) 
                                AND (@MaPB IS NULL OR nv.MaPB = @MaPB)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Kw", "%" + (keyword ?? "") + "%");
                cmd.Parameters.AddWithValue("@MaPB", (object)maPB ?? DBNull.Value);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienDTO
                        {
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                            CCCD = reader["CCCD"].ToString(),
                            MaPB = Convert.ToInt32(reader["MaPB"]),
                            TenPB = reader["TenPB"].ToString(),
                            LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]),
                            HeSoLuong = Convert.ToDouble(reader["HeSoLuong"])
                        });
                    }
                }
            }
            return list;
        }

        public bool Insert(NhanVienDTO nv)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = @"INSERT INTO NhanVien (HoTen, NgaySinh, CCCD, MaPB, LuongCoBan, HeSoLuong) 
                                VALUES (@HoTen, @NgaySinh, @CCCD, @MaPB, @LuongCoBan, @HeSoLuong)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                cmd.Parameters.AddWithValue("@MaPB", nv.MaPB);
                cmd.Parameters.AddWithValue("@LuongCoBan", nv.LuongCoBan);
                cmd.Parameters.AddWithValue("@HeSoLuong", nv.HeSoLuong);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(NhanVienDTO nv)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = @"UPDATE NhanVien 
                                SET HoTen = @HoTen, NgaySinh = @NgaySinh, CCCD = @CCCD, MaPB = @MaPB, 
                                    LuongCoBan = @LuongCoBan, HeSoLuong = @HeSoLuong 
                                WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                cmd.Parameters.AddWithValue("@MaPB", nv.MaPB);
                cmd.Parameters.AddWithValue("@LuongCoBan", nv.LuongCoBan);
                cmd.Parameters.AddWithValue("@HeSoLuong", nv.HeSoLuong);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maNV)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}