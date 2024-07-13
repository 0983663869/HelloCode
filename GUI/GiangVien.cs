using BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class GiangVien : Form
    {
        private GiangVienBLL giangVienBLL;
        private AccountDTO currentUser;

        private string originalMaGV;

        public GiangVien(AccountDTO user)
        {
            InitializeComponent();
            currentUser = user;
            UpdateButtonStates();

            giangVienBLL = new GiangVienBLL();
            LoadGiangVien();
        }

        private void LoadGiangVien()
        {
            DataTable dt = giangVienBLL.GetAllGiangVien();
            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    MaGV = txtMaGV.Text,
                    TenGV = txtTenGV.Text,
                    DienThoai = txtDienThoai.Text,
                    Email = txtEmail.Text,
                    NoiCongTac = txtNoiCongTac.Text
                };

                giangVienBLL.AddGiangVien(giangVien);
                LoadGiangVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                giangVienBLL.DeleteGiangVien(txtMaGV.Text);
                LoadGiangVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    MaGV = txtMaGV.Text,
                    TenGV = txtTenGV.Text,
                    DienThoai = txtDienThoai.Text,
                    Email = txtEmail.Text,
                    NoiCongTac = txtNoiCongTac.Text
                };

                giangVienBLL.UpdateGiangVien(giangVien, originalMaGV);
                LoadGiangVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();

        }

        private void ClearTextBoxes()
        {
            txtMaGV.Text = "";
            txtTenGV.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtNoiCongTac.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            GiangVienDTO giangVien = new GiangVienDTO
            {
                MaGV = string.IsNullOrEmpty(txtMaGV.Text) ? null : txtMaGV.Text,
                TenGV = string.IsNullOrEmpty(txtTenGV.Text) ? null : txtTenGV.Text,
                DienThoai = string.IsNullOrEmpty(txtDienThoai.Text) ? null : txtDienThoai.Text,
                Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text
            };

            DataTable dt = giangVienBLL.SearchGiangVien(giangVien);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị thông tin lên các TextBox
                txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                txtTenGV.Text = row.Cells["TenGV"].Value.ToString();
                txtDienThoai.Text = row.Cells["DienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtNoiCongTac.Text = row.Cells["NoiCongTac"].Value.ToString();

                // Lưu trữ giá trị gốc
                originalMaGV = row.Cells["MaGV"].Value.ToString();
            }
        }

        private void UpdateButtonStates()
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;
            btnTimKiem.Visible = true;

            if (currentUser.AccountType == "Sinh viên" || currentUser.AccountType == "Giảng viên")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = true;
                btnTimKiem.Enabled = true;
            }
            else if (currentUser.AccountType == "Quản trị viên")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLamMoi.Enabled = true;
                btnTimKiem.Enabled = true;
            }
        }
    }
}
