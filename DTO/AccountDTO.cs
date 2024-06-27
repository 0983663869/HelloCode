using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tầng chứa các đối tượng truyền dữ liệu
namespace DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; } 
        public DateTime DateCreated { get; set; }
    }
}
