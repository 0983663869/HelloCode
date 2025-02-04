﻿using BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class Khoa : Form
    {
        private KhoaBLL khoaBLL;
        private AccountDTO currentUser;

        public Khoa(AccountDTO user)
        {
            InitializeComponent();
            currentUser = user;
            UpdateButtonStates();

            khoaBLL = new KhoaBLL();
            LoadKhoa();
        }

        private void LoadKhoa()
        {
            DataTable dt = khoaBLL.GetAllKhoa();
            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                KhoaDTO khoa = new KhoaDTO
                {
                    MaKhoa = txtMaKhoa.Text,
                    TenKhoa = txtTenKhoa.Text
                };

                khoaBLL.AddKhoa(khoa);
                LoadKhoa();
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
                KhoaDTO khoa = new KhoaDTO
                {
                    MaKhoa = txtMaKhoa.Text,
                    TenKhoa = txtTenKhoa.Text
                };

                khoaBLL.UpdateKhoa(khoa);
                LoadKhoa();
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
                khoaBLL.DeleteKhoa(txtMaKhoa.Text);
                LoadKhoa(); // Load lại dữ liệu sau khi xóa
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
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị thông tin lên các TextBox
                txtMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();
                txtTenKhoa.Text = row.Cells["TenKhoa"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            KhoaDTO khoa = new KhoaDTO
            {
                MaKhoa = string.IsNullOrEmpty(txtMaKhoa.Text) ? null : txtMaKhoa.Text,
                TenKhoa = string.IsNullOrEmpty(txtTenKhoa.Text) ? null : txtTenKhoa.Text
            };

            DataTable dt = khoaBLL.SearchKhoa(khoa);
            dataGridView1.DataSource = dt;
        }

        private void UpdateButtonStates()
        {
            // Đảm bảo các nút luôn hiển thị
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;
            btnTimKiem.Visible = true;

            if (currentUser.AccountType == "Sinh viên" || currentUser.AccountType == "Giảng viên")
            {
                // Vô hiệu hóa các nút nhưng vẫn hiển thị chúng
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = true;
                btnTimKiem.Enabled = true;
            }
            else 

            if (currentUser.AccountType == "Quản trị viên")
            {
                // Bật nút cho quản trị viên
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLamMoi.Enabled = true;
                btnTimKiem.Enabled = true;
            }
        }
    }
}
