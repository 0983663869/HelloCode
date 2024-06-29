using System.Data;
using System.Data.SqlClient;
using DTO;

// Tầng truy cập dữ liệu
namespace DAL
{
    public class AccountDAL
    {
        private readonly DatabaseConnection _dbConnection;

        public AccountDAL()
        {
            _dbConnection = new DatabaseConnection();
        }

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
    }
}
