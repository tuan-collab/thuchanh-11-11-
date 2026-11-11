using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SalesManagement.DTO;

namespace SalesManagement.DAL
{
    public class HoaDonDAL
    {
        public int ThanhToan(HoaDonDTO hd, List<ChiTietHoaDonDTO> listCT)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Chèn Hóa đơn mới
                    string sqlInsertHD = @"INSERT INTO HoaDon (MaNV, MaKH, TongTien) 
                                          VALUES (@MaNV, @MaKH, @TongTien); 
                                          SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdHD = new SqlCommand(sqlInsertHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@MaNV", hd.MaNV);
                    cmdHD.Parameters.AddWithValue("@MaKH", (object)hd.MaKH ?? DBNull.Value);
                    cmdHD.Parameters.AddWithValue("@TongTien", hd.TongTien);

                    int maHD = Convert.ToInt32(cmdHD.ExecuteScalar());

                    // 2. Duyệt giỏ hàng -> Kiểm tra kho -> Trừ kho -> Thêm CTHD
                    foreach (var item in listCT)
                    {
                        string sqlCheckStock = "SELECT SoLuongTon FROM SanPham WHERE MaSP = @MaSP";
                        SqlCommand cmdCheck = new SqlCommand(sqlCheckStock, conn, trans);
                        cmdCheck.Parameters.AddWithValue("@MaSP", item.MaSP);
                        int tonKho = Convert.ToInt32(cmdCheck.ExecuteScalar());

                        if (tonKho < item.SoLuong)
                        {
                            throw new Exception($"Sản phẩm [{item.TenSP}] không đủ tồn kho! (Kho còn: {tonKho}, Mua: {item.SoLuong})");
                        }

                        string sqlUpdateStock = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdateStock, conn, trans);
                        cmdUpdate.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdUpdate.Parameters.AddWithValue("@MaSP", item.MaSP);
                        cmdUpdate.ExecuteNonQuery();

                        string sqlInsertCT = @"INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) 
                                               VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
                        SqlCommand cmdCT = new SqlCommand(sqlInsertCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                        cmdCT.Parameters.AddWithValue("@MaSP", item.MaSP);
                        cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", item.DonGia);
                        cmdCT.ExecuteNonQuery();
                    }

                    // 3. Cộng điểm tích lũy cho Khách hàng
                    if (hd.MaKH.HasValue)
                    {
                        int diemCong = (int)(hd.TongTien / 100000);
                        if (diemCong > 0)
                        {
                            string sqlUpdateDiem = "UPDATE KhachHang SET DiemTichLuy = DiemTichLuy + @Diem WHERE MaKH = @MaKH";
                            SqlCommand cmdDiem = new SqlCommand(sqlUpdateDiem, conn, trans);
                            cmdDiem.Parameters.AddWithValue("@Diem", diemCong);
                            cmdDiem.Parameters.AddWithValue("@MaKH", hd.MaKH.Value);
                            cmdDiem.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    return maHD;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}