using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Account : Form
    {
        private AccountDTO currentUser;
        private AccountBLL accountBLL;

        public Account(AccountDTO user)
        {
            InitializeComponent();
            currentUser = user;
            accountBLL = new AccountBLL();
            UpdateButtonStates();
            LoadAccounts();
        }

        // Load danh sách tài khoản vào DataGridView
        private void LoadAccounts()
        {
            DataTable dt = accountBLL.SearchAccount(new AccountDTO());
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false; // Ẩn cột id
        }

        // Xử lý sự kiện nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedRowId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    AccountDTO account = new AccountDTO
                    {
                        Id = selectedRowId,
                        Email = txtEmail.Text,
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        AccountType = cbbAccountType.Text
                    };

                    accountBLL.UpdateAccount(account);
                    LoadAccounts();
                }
                else
                {
                    MessageBox.Show("Chọn một tài khoản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedRowId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                    accountBLL.DeleteAccount(selectedRowId);
                    LoadAccounts();
                }
                else
                {
                    MessageBox.Show("Chọn một tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        // Xóa dữ liệu trong các TextBox và ComboBox
        private void ClearTextBoxes()
        {
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            cbbAccountType.Text = "";
        }

        // Xử lý sự kiện nút Tìm Kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            AccountDTO account = new AccountDTO
            {
                Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text,
                Username = string.IsNullOrEmpty(txtUsername.Text) ? null : txtUsername.Text,
                AccountType = string.IsNullOrEmpty(cbbAccountType.Text) ? null : cbbAccountType.Text
            };

            DataTable dt = accountBLL.SearchAccount(account);
            dataGridView1.DataSource = dt;
        }

        // Xử lý sự kiện khi chọn một dòng trong DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                cbbAccountType.Text = row.Cells["AccountType"].Value.ToString();
            }
        }

        // Cập nhật trạng thái của các nút theo quyền của người dùng
        private void UpdateButtonStates()
        {
            // Ensure buttons are always visible
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;
            btnTimKiem.Visible = true;

/*          
            if (currentUser.AccountType == "Sinh viên" || currentUser.AccountType == "Giảng viên")
            {
                // Disable buttons but keep them visible
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnTimKiem.Enabled = true;
            }
            else 
*/
            if (currentUser.AccountType == "Quản trị viên")
            {
                // Enable buttons for admin
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLamMoi.Enabled = true;
                btnTimKiem.Enabled = true;
            }
        }
    }
}
