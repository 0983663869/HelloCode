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
    public partial class Faculty : Form
    {
        private AccountDTO currentUser;

        public Faculty(AccountDTO user)
        {
            InitializeComponent();
            currentUser = user;
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            // Ensure buttons are always visible
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;
            btnTimKiem.Visible = true;

/*            if (currentUser.AccountType == "Student" || currentUser.AccountType == "Lecturer")
            {
                // Disable buttons but keep them visible
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnTimKiem.Enabled = true;
            }
            else 
*/
            if (currentUser.AccountType == "Admin")
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
