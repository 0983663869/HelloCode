using DTO;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DAL
{
    public class AccountDAL
    {
        private readonly DatabaseConnection _dbConnection;

        public AccountDAL()
        {
            _dbConnection = new DatabaseConnection();
        }

        // Lấy thông tin người dùng bằng username và password
        public DataTable GetUserByUsernameAndPassword(string username, string password)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
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

        // Thêm người dùng mới
        public bool InsertUser(AccountDTO user)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string insertData = "INSERT INTO Account (email, username, password, accounttype, date_created) VALUES(@mail, @username, @pass, @accounttype, @date)";
                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                {
                    cmd.Parameters.AddWithValue("@mail", user.Email);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@accounttype", user.AccountType);
                    cmd.Parameters.AddWithValue("@date", user.DateCreated);

                    connect.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // Kiểm tra tồn tại username
        public bool CheckUsernameExists(string username)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
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

        // Kiểm tra tồn tại email
        public bool CheckEmailExists(string email)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
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

        // Cập nhật thông tin tài khoản
        public bool UpdateAccount(AccountDTO account)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Account SET email = @Email, username = @Username, password = @Password, accounttype = @AccountType WHERE id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Email", account.Email);
                    cmd.Parameters.AddWithValue("@Username", account.Username);
                    cmd.Parameters.AddWithValue("@Password", account.Password);
                    cmd.Parameters.AddWithValue("@AccountType", account.AccountType);
                    cmd.Parameters.AddWithValue("@Id", account.Id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa tài khoản
        public bool DeleteAccount(int id)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Account WHERE id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tìm kiếm tài khoản theo điều kiện
        public DataTable SearchAccount(AccountDTO account)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SearchAccount", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Email", (object)account.Email ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@Username", (object)account.Username ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@AccountType", (object)account.AccountType ?? DBNull.Value);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Kiểm tra email trùng lặp trừ id hiện tại
        public bool CheckDuplicateEmail(int id, string email)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string checkEmail = "SELECT COUNT(*) FROM Account WHERE email = @mail AND id != @id";
                using (SqlCommand cmd = new SqlCommand(checkEmail, connect))
                {
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@id", id);
                    connect.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Kiểm tra username trùng lặp trừ id hiện tại
        public bool CheckDuplicateUsername(int id, string username)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string checkUsername = "SELECT COUNT(*) FROM Account WHERE username = @username AND id != @id";
                using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@id", id);
                    connect.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
