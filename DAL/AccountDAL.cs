using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

// tầng truy cập dữ liệu
namespace DAL
{
    public class AccountDAL
    {
        private string connectionString = @"Data Source=NGTMINH\SQLEXPRESS;Initial Catalog=QuanLyDeTai;Integrated Security=True";

        // Lấy thông tin người dùng từ database dựa trên username và password
        public DataTable GetUserByUsernameAndPassword(string username, string password)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string selectData = "SELECT * FROM Account WHERE username = @username AND password = @pass";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        // Thêm người dùng mới vào database
        public bool InsertUser(AccountDTO user)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string insertData = "INSERT INTO Account (email, username, password, accounttype, date_created) VALUES(@mail, @username, @pass, @accounttype, @date)";
                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                {
                    cmd.Parameters.AddWithValue("@mail", user.Email);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@accounttype", user.AccountType); // Thêm trường này
                    cmd.Parameters.AddWithValue("@date", user.DateCreated);

                    connect.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    

        // Check username tồn tại 
        public bool CheckUsernameExists(string username)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string checkUsername = "SELECT * FROM Account WHERE username = @username";
                using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table.Rows.Count > 0;
                }
            }
        }

        // Check email tồn tại 
        public bool CheckEmailExists(string email)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                string checkEmail = "SELECT * FROM Account WHERE email = @mail";
                using (SqlCommand cmd = new SqlCommand(checkEmail, connect))
                {
                    cmd.Parameters.AddWithValue("@mail", email);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table.Rows.Count > 0;
                }
            }
        }
    }
}
