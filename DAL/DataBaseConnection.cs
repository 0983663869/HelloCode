using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
