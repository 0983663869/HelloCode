using BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class DeTai : Form
    {
        private AccountDTO currentUser;
        private DeTaiBLL deTaiBLL;
        private string originalMaDT;

        public DeTai(AccountDTO user)
        {
            InitializeComponent();
            currentUser = user;
            UpdateButtonStates();

            deTaiBLL = new DeTaiBLL();
            LoadDeTai();
        }

        private void LoadDeTai()
        {
            DataTable dt = deTaiBLL.GetAllDeTai();
            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DeTaiDTO deTai = new DeTaiDTO
                {
                    MaDT = txtMaDT.Text,
                    TenDT = txtTenDT.Text,
                    MaGV = txtMaGV.Text,
                    MaSV = txtMaSV.Text,
                    Diem = string.IsNullOrEmpty(txtDiem.Text) ? (float?)null : float.Parse(txtDiem.Text),
                    TrangThai = cbTrangThai.Checked,
                    XepLoai = CalculateXepLoai(txtDiem.Text)
                };

                deTaiBLL.AddDeTai(deTai);
                LoadDeTai();
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
                DeTaiDTO deTai = new DeTaiDTO
                {
                    MaDT = txtMaDT.Text,
                    TenDT = txtTenDT.Text,
                    MaGV = txtMaGV.Text,
                    MaSV = txtMaSV.Text,
                    Diem = string.IsNullOrEmpty(txtDiem.Text) ? (float?)null : float.Parse(txtDiem.Text),
                    TrangThai = cbTrangThai.Checked,
                    XepLoai = CalculateXepLoai(txtDiem.Text)
                };

                deTaiBLL.UpdateDeTai(deTai, originalMaDT);
                LoadDeTai();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deTaiBLL.DeleteDeTai(txtMaDT.Text);
            LoadDeTai();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            txtMaDT.Text = "";
            txtTenDT.Text = "";
            txtMaGV.Text = "";
            txtMaSV.Text = "";
            txtDiem.Text = "";
            cbTrangThai.Checked = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Display information in text boxes
                txtMaDT.Text = row.Cells["MaDT"].Value.ToString();
                txtTenDT.Text = row.Cells["TenDT"].Value.ToString();
                txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtDiem.Text = row.Cells["Diem"].Value.ToString();
                cbTrangThai.Checked = (bool)row.Cells["TrangThai"].Value;

                // Store original values
                originalMaDT = row.Cells["MaDT"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DeTaiDTO deTai = new DeTaiDTO
            {
                MaDT = string.IsNullOrEmpty(txtMaDT.Text) ? null : txtMaDT.Text,
                TenDT = string.IsNullOrEmpty(txtTenDT.Text) ? null : txtTenDT.Text,
                MaGV = string.IsNullOrEmpty(txtMaGV.Text) ? null : txtMaGV.Text,
                MaSV = string.IsNullOrEmpty(txtMaSV.Text) ? null : txtMaSV.Text
            };

            DataTable dt = deTaiBLL.SearchDeTai(deTai);
            dataGridView1.DataSource = dt;
        }

        private string CalculateXepLoai(string diemText)
        {
            if (string.IsNullOrEmpty(diemText))
                return null;

            if (float.TryParse(diemText, out float diem))
            {
                if (diem >= 9.0)
                    return "Xuất sắc";
                else if (diem >= 8.0)
                    return "Giỏi";
                else if (diem >= 7.0)
                    return "Khá";
                else if (diem >= 6.0)
                    return "Trung bình";
                else
                    return "Yếu";
            }
            else
            {
                return null;
            }
        }

        private void cbTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTrangThai.Checked)
            {
                // Trạng thái hoàn thành
                txtDiem.Enabled = true;
            }
            else
            {
                // Trạng thái chưa hoàn thành
                txtDiem.Enabled = false;
                txtDiem.Text = "";
            }
        }

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
                btnLamMoi.Enabled = true;
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
