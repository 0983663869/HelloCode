using DAL;
using DTO;
using System.Data;
using System.Text.RegularExpressions;
using System;

namespace BLL
{
    public class AccountBLL
    {
        private AccountDAL userDAL = new AccountDAL();

        // Đăng nhập
        public AccountDTO Login(string username, string password)
        {
            DataTable table = userDAL.GetUserByUsernameAndPassword(username, password);
            if (table.Rows.Count == 1)
            {
                DataRow row = table.Rows[0];
                return new AccountDTO
                {
                    Id = Convert.ToInt32(row["id"]),
                    Email = row["email"].ToString(),
                    Username = row["username"].ToString(),
                    Password = row["password"].ToString(),
                    AccountType = row["accounttype"].ToString(),
                    DateCreated = Convert.ToDateTime(row["date_created"])
                };
            }
            return null;
        }

        // Đăng ký tài khoản
        public bool Register(AccountDTO user)
        {
            if (userDAL.CheckUsernameExists(user.Username))
            {
                throw new Exception("Username đã tồn tại");
            }
            if (userDAL.CheckEmailExists(user.Email))
            {
                throw new Exception("Email đã tồn tại");
            }
            return userDAL.InsertUser(user);
        }

        // Kiểm tra định dạng email hợp lệ
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@(eaut\.edu\.vn|gmail\.com)$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        // Cập nhật tài khoản
        public void UpdateAccount(AccountDTO account)
        {
            if (userDAL.CheckDuplicateEmail(account.Id, account.Email))
            {
                throw new Exception("Email đã tồn tại.");
            }
            if (userDAL.CheckDuplicateUsername(account.Id, account.Username))
            {
                throw new Exception("Username đã tồn tại.");
            }

            if (!userDAL.UpdateAccount(account))
            {
                throw new Exception("Cập nhật tài khoản không thành công");
            }
        }

        // Xóa tài khoản
        public void DeleteAccount(int id)
        {
            if (!userDAL.DeleteAccount(id))
            {
                throw new Exception("Xóa tài khoản không thành công");
            }
        }

        // Tìm kiếm tài khoản
        public DataTable SearchAccount(AccountDTO account)
        {
            return userDAL.SearchAccount(account);
        }
    }
}
