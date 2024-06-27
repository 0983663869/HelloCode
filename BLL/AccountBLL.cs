using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;
using System.Text.RegularExpressions;

// Tầng xử lý logic nghiệp vụ
namespace BLL
{
    public class AccountBLL
    {
        private AccountDAL userDAL = new AccountDAL();

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

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@(eaut\.edu\.vn|gmail\.com)$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}
