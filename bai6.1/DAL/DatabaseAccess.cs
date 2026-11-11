using System.Data.SqlClient;

namespace SalesManagement.DAL
{
    public class DatabaseAccess
    {
        // Sử dụng Server name từ SSMS của bạn
        private static string connectionString = @"Server=.\MSSQLSERVER01;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}