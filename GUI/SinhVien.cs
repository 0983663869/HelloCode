using BLL;
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
    public partial class SinhVien : Form
    {
        private SinhVienBLL sinhVienBLL;

        private AccountDTO currentUser;

        private string originalMaSV;
        private string originalDienThoai;
        private string originalEmail;

        public SinhVien(AccountDTO user)
        {
            InitializeComponent();
            currentUser = user;
            UpdateButtonStates();

            sinhVienBLL = new SinhVienBLL();
            LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            DataTable dt = sinhVienBLL.GetAllSinhVien();
            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVienDTO sinhVien = new SinhVienDTO
                {
                    MaSV = txtMaSV.Text,
                    TenSV = txtTenSV.Text,
                    DienThoai = txtDienThoai.Text,
                    Email = txtEmail.Text,
                    Lop = txtLop.Text,
                    MaKhoa = txtMaKhoa.Text
                };

                sinhVienBLL.AddSinhVien(sinhVien);
                LoadSinhVien();
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
                SinhVienDTO sinhVien = new SinhVienDTO
                {
                    MaSV = txtMaSV.Text,
                    TenSV = txtTenSV.Text,
                    DienThoai = txtDienThoai.Text,
                    Email = txtEmail.Text,
                    Lop = txtLop.Text,
                    MaKhoa = txtMaKhoa.Text
                };

                sinhVienBLL.UpdateSinhVien(sinhVien, originalMaSV);
                LoadSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            sinhVienBLL.DeleteSinhVien(txtMaSV.Text);
            LoadSinhVien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtLop.Text = "";
            txtMaKhoa.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị thông tin lên các TextBox
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtTenSV.Text = row.Cells["TenSV"].Value.ToString();
                txtDienThoai.Text = row.Cells["DienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtLop.Text = row.Cells["Lop"].Value.ToString();
                txtMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();

                // Lưu trữ giá trị gốc
                originalMaSV = row.Cells["MaSV"].Value.ToString();
                originalDienThoai = row.Cells["DienThoai"].Value.ToString();
                originalEmail = row.Cells["Email"].Value.ToString();
            }
        }
        

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SinhVienDTO sinhVien = new SinhVienDTO
            {
                MaSV = string.IsNullOrEmpty(txtMaSV.Text) ? null : txtMaSV.Text,
                TenSV = string.IsNullOrEmpty(txtTenSV.Text) ? null : txtTenSV.Text,
                DienThoai = string.IsNullOrEmpty(txtDienThoai.Text) ? null : txtDienThoai.Text,
                Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text,
                Lop = string.IsNullOrEmpty(txtLop.Text) ? null : txtLop.Text,
                MaKhoa = string.IsNullOrEmpty(txtMaKhoa.Text) ? null : txtMaKhoa.Text
            };

            DataTable dt = sinhVienBLL.SearchSinhVien(sinhVien);
            dataGridView1.DataSource = dt;
        }

        // =================================================

        private void UpdateButtonStates()
        {
            // Ensure buttons are always visible
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;
            btnTimKiem.Visible = true;

            if (currentUser.AccountType == "Sinh viên" || currentUser.AccountType == "Giảng viên")
            {
                // Disable buttons but keep them visible
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnTimKiem.Enabled = true;
            }
            else if (currentUser.AccountType == "Quản trị viên")
            {
                // Enable buttons for admin
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLamMoi.Enabled = true;
                btnTimKiem.Enabled = true;
            }
        }
    }
}
