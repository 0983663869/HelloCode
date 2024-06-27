using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class Signup : Form
    {
        private AccountBLL userBLL = new AccountBLL();

        public Signup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(signup_email.Text) || string.IsNullOrEmpty(signup_username.Text) || string.IsNullOrEmpty(signup_password.Text) || string.IsNullOrEmpty(signup_accounttype.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(signup_email.Text))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ.", "Email không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (signup_password.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Mật khẩu yếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AccountDTO newUser = new AccountDTO
                {
                    Email = signup_email.Text.Trim(),
                    Username = signup_username.Text.Trim(),
                    Password = signup_password.Text.Trim(),
                    AccountType = signup_accounttype.Text.Trim(), // Lấy giá trị loại tài khoản từ combobox
                    DateCreated = DateTime.Today
                };

                userBLL.Register(newUser);

                MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập vào tài khoản.", "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login lForm = new Login();
                lForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void signup_loginHere_Click(object sender, EventArgs e)
        {
            Login lForm = new Login();
            lForm.Show();
            this.Hide();
        }

        private void signup_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@(eaut\.edu\.vn|gmail\.com)$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}
