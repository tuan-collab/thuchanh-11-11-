using System.Data.SqlClient;

namespace HRMManagement.DAL
{
    public class DatabaseAccess
    {
        private static string connectionString = @"Server=.\MSSQLSERVER01;Database=HRMDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static string ConnectionString => connectionString;
    }
}