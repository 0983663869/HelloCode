using System;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class DangNhap : Form
    {
        private AccountBLL userBLL = new AccountBLL();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(login_username.Text) || string.IsNullOrEmpty(login_password.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AccountDTO user = userBLL.Login(login_username.Text, login_password.Text);
                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MainForm mForm = new MainForm(user); // Truyền thông tin người dùng vào MainForm
                    mForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình đăng nhập. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void login_registerHere_Click(object sender, EventArgs e)
        {
            DangKy sForm = new DangKy();
            sForm.Show();
            this.Hide();
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }
    }
}
