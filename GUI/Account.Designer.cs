namespace GUI
{
    partial class Account
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account));
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.Menu;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnTimKiem.Location = new System.Drawing.Point(661, 215);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 32);
            this.btnTimKiem.TabIndex = 31;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.Menu;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnLamMoi.Location = new System.Drawing.Point(661, 160);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.TabIndex = 30;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnSua.Location = new System.Drawing.Point(661, 48);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 29;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.Menu;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnXoa.Location = new System.Drawing.Point(661, 104);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 28;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbAccountType);
            this.groupBox2.Controls.Add(this.lblAccountType);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.lblUsername);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.groupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Location = new System.Drawing.Point(27, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(724, 157);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cập Nhập Thông Tin";
            // 
            // cbbAccountType
            // 
            this.cbbAccountType.FormattingEnabled = true;
            this.cbbAccountType.Items.AddRange(new object[] {
            "Sinh Viên",
            "Giảng viên",
            "Quản trị viên"});
            this.cbbAccountType.Location = new System.Drawing.Point(501, 94);
            this.cbbAccountType.Name = "cbbAccountType";
            this.cbbAccountType.Size = new System.Drawing.Size(178, 24);
            this.cbbAccountType.TabIndex = 30;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(395, 97);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(91, 17);
            this.lblAccountType.TabIndex = 28;
            this.lblAccountType.Text = "AccountType";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtPassword.Location = new System.Drawing.Point(120, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(217, 23);
            this.txtPassword.TabIndex = 15;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(43, 98);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtEmail.Location = new System.Drawing.Point(455, 56);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(224, 23);
            this.txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(395, 59);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtUsername.Location = new System.Drawing.Point(120, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(217, 23);
            this.txtUsername.TabIndex = 11;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(43, 59);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "Username";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(604, 270);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(775, 481);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Account";
            this.Text = "Account";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbbAccountType;
    }
}