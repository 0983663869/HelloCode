using DTO;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DAL
{
    public interface IAccountRepository
    {
        DataTable GetUserByUsernameAndPassword(string username, string password);
        bool InsertUser(AccountDTO user);
        bool CheckUsernameExists(string username);
        bool CheckEmailExists(string email);
        bool CheckDuplicateEmail(int id, string email);
        bool CheckDuplicateUsername(int id, string username);
        bool UpdateAccount(AccountDTO account);
        bool DeleteAccount(int id);
        DataTable SearchAccount(AccountDTO account);
    }

    public class AccountDAL : IAccountRepository
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

        // Kiểm tra email trùng lặp khi cập nhật
        public bool CheckDuplicateEmail(int id, string email)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string checkDuplicateEmail = "SELECT * FROM Account WHERE email = @mail AND id != @id";
                using (SqlCommand cmd = new SqlCommand(checkDuplicateEmail, connect))
                {
                    cmd.Parameters.AddWithValue("@mail", email);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table.Rows.Count > 0;
                }
            }
        }

        // Kiểm tra username trùng lặp khi cập nhật
        public bool CheckDuplicateUsername(int id, string username)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string checkDuplicateUsername = "SELECT * FROM Account WHERE username = @username AND id != @id";
                using (SqlCommand cmd = new SqlCommand(checkDuplicateUsername, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table.Rows.Count > 0;
                }
            }
        }

        // Cập nhật tài khoản
        public bool UpdateAccount(AccountDTO account)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string updateData = "UPDATE Account SET email = @mail, username = @username, password = @pass, accounttype = @accounttype WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(updateData, connect))
                {
                    cmd.Parameters.AddWithValue("@mail", account.Email);
                    cmd.Parameters.AddWithValue("@username", account.Username);
                    cmd.Parameters.AddWithValue("@pass", account.Password);
                    cmd.Parameters.AddWithValue("@accounttype", account.AccountType);
                    cmd.Parameters.AddWithValue("@id", account.Id);

                    connect.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // Xóa tài khoản
        public bool DeleteAccount(int id)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string deleteData = "DELETE FROM Account WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    connect.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // Tìm kiếm tài khoản
        public DataTable SearchAccount(AccountDTO account)
        {
            using (SqlConnection connect = _dbConnection.GetConnection())
            {
                string searchQuery = "SELECT * FROM Account WHERE 1=1";
                if (!string.IsNullOrEmpty(account.Email))
                {
                    searchQuery += " AND email LIKE '%' + @mail + '%'";
                }
                if (!string.IsNullOrEmpty(account.Username))
                {
                    searchQuery += " AND username LIKE '%' + @username + '%'";
                }
                if (!string.IsNullOrEmpty(account.AccountType))
                {
                    searchQuery += " AND accounttype LIKE '%' + @accounttype + '%'";
                }

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    if (!string.IsNullOrEmpty(account.Email))
                    {
                        cmd.Parameters.AddWithValue("@mail", account.Email);
                    }
                    if (!string.IsNullOrEmpty(account.Username))
                    {
                        cmd.Parameters.AddWithValue("@username", account.Username);
                    }
                    if (!string.IsNullOrEmpty(account.AccountType))
                    {
                        cmd.Parameters.AddWithValue("@accounttype", account.AccountType);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }
    }
}

