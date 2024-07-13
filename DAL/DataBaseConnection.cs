using System.Data.SqlClient;

namespace DAL
{
    public class DatabaseConnection
    {
        private readonly string connectionString = @"Data Source=NGTMINH\SQLEXPRESS;Initial Catalog=QuanLyDeTai;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
