using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DTO;
using FontAwesome.Sharp;

namespace GUI
{
    public partial class MainForm : Form
    {
        // Các trường
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private AccountDTO currentUser;

        // Hàm khởi tạo
        public MainForm(AccountDTO user)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 55);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            currentUser = user;
        }

        // Cấu trúc cho màu RGB
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(24, 161, 251);
        }

        // Kích hoạt nút
        public void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                // Nút
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                // Đường viền bên trái của nút
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                // Biểu tượng của form con hiện tại
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        // Vô hiệu hóa nút
        public void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        // Mở form con
        public void OpenChildForm(Form childForm)
        {
            // Mở duy nhất một form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            // Thiết lập form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        // Đặt lại
        public void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.HomeLg;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        // Thoát chương trình
        public void Exit()
        {
            Application.Exit();
        }

        // Phóng to thu nhỏ cửa sổ
        public void Maximize()
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        // Thu nhỏ cửa sổ
        public void Minimize()
        {
            WindowState = FormWindowState.Minimized;
        }

        // Cập nhật thời gian
        public void UpdateTime()
        {
            lblRunTimes.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        // Kéo thả form
        public void DragForm(MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Sự kiện nhấn nút trong menu
        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new SinhVien(currentUser)); // Mở form Sinh Viên
        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new GiangVien(currentUser)); // Mở form Giảng Viên
        }

        private void btnDeTai_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new DeTai(currentUser)); // Mở form Đề Tài
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Khoa(currentUser)); // Mở form Khoa
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new Account(currentUser)); // Mở form Tài Khoản
        }

        // Sự kiện
        // Đặt lại
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        // Kéo thả form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitelBar_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm(e);
        }

        // Đóng - Phóng to - Thu nhỏ
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            Maximize();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            Minimize();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDateNow.Text = DateTime.Now.ToLongDateString();

            lblWelcome.Text = "Welcome, " + currentUser.Username;

            if (currentUser.AccountType == "Sinh viên")
            {
                btnSinhVien.Enabled = true;
                btnDeTai.Enabled = true;
                btnKhoa.Enabled = true;

                // Disable other buttons
                btnGiangVien.Enabled = false;
                btnTaiKhoan.Enabled = false;
            }
            else if (currentUser.AccountType == "Giảng viên")
            {
                btnGiangVien.Enabled = true;
                btnDeTai.Enabled = true;

                // Disable other buttons
                btnSinhVien.Enabled = false;
                btnKhoa.Enabled = false;
                btnTaiKhoan.Enabled = false;
            }
            else if (currentUser.AccountType == "Quản trị viên")
            {
                btnSinhVien.Enabled = true;
                btnGiangVien.Enabled = true;
                btnDeTai.Enabled = true;
                btnKhoa.Enabled = true;
                btnTaiKhoan.Enabled = true;
            }
        }
    

        // Sự kiện cập nhật thời gian
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        // Xử lý sự kiện đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng MainForm
            DangNhap loginForm = new DangNhap();
            loginForm.Show(); // Hiển thị lại form đăng nhập
        }
    }
}
