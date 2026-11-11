using System;
using System.Data;
using System.Data.SqlClient;

namespace HRMManagement.DAL
{
    public class BangChamCongDAL
    {
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;
        private DataTable dataTable;

        // Khởi tạo bảng chấm công cho tháng/năm được chọn và nạp vào DataTable (Disconnected Model)
        public DataTable GetBangChamCongByThang(string thangNam)
        {
            using (SqlConnection conn = DatabaseAccess.GetConnection())
            {
                conn.Open();
                // 1. Tự động chèn bản ghi chấm công cho các nhân viên chưa có trong tháng được chọn
                string initQuery = @"INSERT INTO BangChamCong (MaNV, ThangNam, SoNgayCong, SoGioOT)
                                     SELECT nv.MaNV, @ThangNam, 22, 0 
                                     FROM NhanVien nv 
                                     WHERE NOT EXISTS (
                                         SELECT 1 FROM BangChamCong cc 
                                         WHERE cc.MaNV = nv.MaNV AND cc.ThangNam = @ThangNam
                                     )";
                SqlCommand cmdInit = new SqlCommand(initQuery, conn);
                cmdInit.Parameters.AddWithValue("@ThangNam", thangNam);
                cmdInit.ExecuteNonQuery();
            }

            // 2. Nạp dữ liệu vào DataTable sử dụng SqlDataAdapter
            string selectQuery = "SELECT MaCong, MaNV, ThangNam, SoNgayCong, SoGioOT FROM BangChamCong WHERE ThangNam = @ThangNam";
            SqlConnection selectConn = DatabaseAccess.GetConnection();
            SqlCommand selectCmd = new SqlCommand(selectQuery, selectConn);
            selectCmd.Parameters.AddWithValue("@ThangNam", thangNam);

            adapter = new SqlDataAdapter(selectCmd);
            builder = new SqlCommandBuilder(adapter); // Tự động sinh INSERT, UPDATE, DELETE

            dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        // Lưu đồng bộ toàn bộ thay đổi từ DataTable trên giao diện về SQL Server trong 1 thao tác
        public bool SaveChanges(DataTable dt)
        {
            if (adapter != null && dt != null)
            {
                int rowsAffected = adapter.Update(dt);
                return rowsAffected >= 0;
            }
            return false;
        }
    }
}