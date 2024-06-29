namespace GUI
{
    partial class DeTai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeTai));
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTrangThai = new System.Windows.Forms.CheckBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.lblDiem = new System.Windows.Forms.Label();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.lblMaGV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtTenDT = new System.Windows.Forms.TextBox();
            this.lblMaDT = new System.Windows.Forms.Label();
            this.txtMaDT = new System.Windows.Forms.TextBox();
            this.lblTenDT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.Menu;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnTimKiem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTimKiem.Location = new System.Drawing.Point(591, 185);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 32);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(727, 228);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.Menu;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnLamMoi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLamMoi.Location = new System.Drawing.Point(465, 185);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.TabIndex = 15;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnSua.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSua.Location = new System.Drawing.Point(346, 185);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.Menu;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnXoa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnXoa.Location = new System.Drawing.Point(223, 185);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.Menu;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnThem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnThem.Location = new System.Drawing.Point(102, 185);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTrangThai);
            this.groupBox2.Controls.Add(this.lblTrangThai);
            this.groupBox2.Controls.Add(this.txtDiem);
            this.groupBox2.Controls.Add(this.lblDiem);
            this.groupBox2.Controls.Add(this.txtMaGV);
            this.groupBox2.Controls.Add(this.lblMaGV);
            this.groupBox2.Controls.Add(this.txtMaSV);
            this.groupBox2.Controls.Add(this.lblMaSV);
            this.groupBox2.Controls.Add(this.txtTenDT);
            this.groupBox2.Controls.Add(this.lblMaDT);
            this.groupBox2.Controls.Add(this.txtMaDT);
            this.groupBox2.Controls.Add(this.lblTenDT);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.groupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Location = new System.Drawing.Point(32, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(707, 161);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cập Nhập Thông Tin";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.AutoSize = true;
            this.cbTrangThai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbTrangThai.Location = new System.Drawing.Point(561, 130);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(15, 14);
            this.cbTrangThai.TabIndex = 15;
            this.cbTrangThai.UseVisualStyleBackColor = true;
            this.cbTrangThai.CheckedChanged += new System.EventHandler(this.cbTrangThai_CheckedChanged);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTrangThai.Location = new System.Drawing.Point(481, 127);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(78, 18);
            this.lblTrangThai.TabIndex = 14;
            this.lblTrangThai.Text = "Trạng Thái";
            // 
            // txtDiem
            // 
            this.txtDiem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtDiem.Location = new System.Drawing.Point(464, 80);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(206, 24);
            this.txtDiem.TabIndex = 13;
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDiem.Location = new System.Drawing.Point(404, 83);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(43, 18);
            this.lblDiem.TabIndex = 12;
            this.lblDiem.Text = "Điểm";
            // 
            // txtMaGV
            // 
            this.txtMaGV.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtMaGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtMaGV.Location = new System.Drawing.Point(92, 124);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(177, 24);
            this.txtMaGV.TabIndex = 11;
            // 
            // lblMaGV
            // 
            this.lblMaGV.AutoSize = true;
            this.lblMaGV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMaGV.Location = new System.Drawing.Point(32, 127);
            this.lblMaGV.Name = "lblMaGV";
            this.lblMaGV.Size = new System.Drawing.Size(54, 18);
            this.lblMaGV.TabIndex = 10;
            this.lblMaGV.Text = "Mã GV";
            // 
            // txtMaSV
            // 
            this.txtMaSV.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtMaSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtMaSV.Location = new System.Drawing.Point(464, 35);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(206, 24);
            this.txtMaSV.TabIndex = 5;
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMaSV.Location = new System.Drawing.Point(404, 38);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(52, 18);
            this.lblMaSV.TabIndex = 4;
            this.lblMaSV.Text = "Mã SV";
            // 
            // txtTenDT
            // 
            this.txtTenDT.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtTenDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtTenDT.Location = new System.Drawing.Point(92, 80);
            this.txtTenDT.Name = "txtTenDT";
            this.txtTenDT.Size = new System.Drawing.Size(228, 24);
            this.txtTenDT.TabIndex = 3;
            // 
            // lblMaDT
            // 
            this.lblMaDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblMaDT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMaDT.Location = new System.Drawing.Point(32, 38);
            this.lblMaDT.Name = "lblMaDT";
            this.lblMaDT.Size = new System.Drawing.Size(54, 18);
            this.lblMaDT.TabIndex = 0;
            this.lblMaDT.Text = "Mã DT";
            // 
            // txtMaDT
            // 
            this.txtMaDT.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtMaDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.txtMaDT.Location = new System.Drawing.Point(92, 36);
            this.txtMaDT.Name = "txtMaDT";
            this.txtMaDT.Size = new System.Drawing.Size(177, 24);
            this.txtMaDT.TabIndex = 2;
            // 
            // lblTenDT
            // 
            this.lblTenDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTenDT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTenDT.Location = new System.Drawing.Point(32, 83);
            this.lblTenDT.Name = "lblTenDT";
            this.lblTenDT.Size = new System.Drawing.Size(60, 18);
            this.lblTenDT.TabIndex = 1;
            this.lblTenDT.Text = "Tên DT";
            // 
            // DeTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(775, 481);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeTai";
            this.Text = "Topics";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.Label lblMaGV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtTenDT;
        private System.Windows.Forms.Label lblMaDT;
        private System.Windows.Forms.TextBox txtMaDT;
        private System.Windows.Forms.Label lblTenDT;
    }
}