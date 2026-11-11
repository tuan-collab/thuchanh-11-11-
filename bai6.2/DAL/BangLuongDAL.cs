using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HRMManagement.DTO;

namespace HRMManagement.DAL
{
    public class BangLuongDAL
    {
        // Thực thi SqlTransaction tính lương và khóa dữ liệu chấm công cho toàn bộ nhân viên trong tháng
        public bool ChotLuongThang(string thangNam)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Lấy danh sách nhân viên kèm số ngày công và giờ OT trong tháng
                    string sqlGetData = @"SELECT nv.MaNV, nv.LuongCoBan, nv.HeSoLuong, cc.SoNgayCong, cc.SoGioOT 
                                          FROM NhanVien nv 
                                          JOIN BangChamCong cc ON nv.MaNV = cc.MaNV 
                                          WHERE cc.ThangNam = @ThangNam";
                    SqlCommand cmdGet = new SqlCommand(sqlGetData, conn, trans);
                    cmdGet.Parameters.AddWithValue("@ThangNam", thangNam);

                    List<Tuple<int, decimal>> listLuong = new List<Tuple<int, decimal>>();

                    using (SqlDataReader reader = cmdGet.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maNV = Convert.ToInt32(reader["MaNV"]);
                            decimal luongCoBan = Convert.ToDecimal(reader["LuongCoBan"]);
                            double heSoLuong = Convert.ToDouble(reader["HeSoLuong"]);
                            double soNgayCong = Convert.ToDouble(reader["SoNgayCong"]);
                            double soGioOT = Convert.ToDouble(reader["SoGioOT"]);

                            // Công thức: ThucLinh = (LuongCoBan * HeSoLuong / 22) * SoNgayCong + (SoGioOT * 50,000)
                            decimal thucLinh = (decimal)((((double)luongCoBan * heSoLuong) / 22.0) * soNgayCong) + (decimal)(soGioOT * 50000.0);

                            listLuong.Add(new Tuple<int, decimal>(maNV, Math.Round(thucLinh, 0)));
                        }
                    }

                    if (listLuong.Count == 0)
                    {
                        throw new Exception($"Không có dữ liệu chấm công cho tháng [{thangNam}] để chốt lương!");
                    }

                    // 2. Ghi nhận vào bảng BangLuong (Xóa bản ghi lương cũ của tháng nếu có để ghi đè)
                    string sqlDeleteOld = "DELETE FROM BangLuong WHERE ThangNam = @ThangNam";
                    SqlCommand cmdDelete = new SqlCommand(sqlDeleteOld, conn, trans);
                    cmdDelete.Parameters.AddWithValue("@ThangNam", thangNam);
                    cmdDelete.ExecuteNonQuery();

                    string sqlInsertLuong = @"INSERT INTO BangLuong (MaNV, ThangNam, ThucLinh) 
                                              VALUES (@MaNV, @ThangNam, @ThucLinh)";

                    foreach (var item in listLuong)
                    {
                        SqlCommand cmdInsert = new SqlCommand(sqlInsertLuong, conn, trans);
                        cmdInsert.Parameters.AddWithValue("@MaNV", item.Item1);
                        cmdInsert.Parameters.AddWithValue("@ThangNam", thangNam);
                        cmdInsert.Parameters.AddWithValue("@ThucLinh", item.Item2);
                        cmdInsert.ExecuteNonQuery();
                    }

                    // 3. Commit SqlTransaction khi tất cả bước thành công
                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public List<BangLuongDTO> GetBangLuongByThang(string thangNam)
        {
            List<BangLuongDTO> list = new List<BangLuongDTO>();
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                string query = @"SELECT bl.MaLuong, bl.MaNV, nv.HoTen, bl.ThangNam, bl.ThucLinh 
                                FROM BangLuong bl 
                                JOIN NhanVien nv ON bl.MaNV = nv.MaNV 
                                WHERE bl.ThangNam = @ThangNam";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ThangNam", thangNam);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BangLuongDTO
                        {
                            MaLuong = Convert.ToInt32(reader["MaLuong"]),
                            MaNV = Convert.ToInt32(reader["MaNV"]),
                            HoTen = reader["HoTen"].ToString(),
                            ThangNam = reader["ThangNam"].ToString(),
                            ThucLinh = Convert.ToDecimal(reader["ThucLinh"])
                        });
                    }
                }
            }
            return list;
        }
    }
}