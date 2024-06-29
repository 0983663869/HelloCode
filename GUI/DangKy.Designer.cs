namespace GUI
{
    partial class DangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKy));
            this.panel1 = new System.Windows.Forms.Panel();
            this.signup_accounttype = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.signup_close = new System.Windows.Forms.Label();
            this.signup_email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.signup_loginHere = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.signup_showPass = new System.Windows.Forms.CheckBox();
            this.btnSignup = new System.Windows.Forms.Button();
            this.signup_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.signup_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.signup_accounttype);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.signup_close);
            this.panel1.Controls.Add(this.signup_email);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.signup_loginHere);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.signup_showPass);
            this.panel1.Controls.Add(this.btnSignup);
            this.panel1.Controls.Add(this.signup_password);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.signup_username);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(254, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 473);
            this.panel1.TabIndex = 0;
            // 
            // signup_accounttype
            // 
            this.signup_accounttype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signup_accounttype.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_accounttype.FormattingEnabled = true;
            this.signup_accounttype.Items.AddRange(new object[] {
            "Sinh viên",
            "Giảng viên",
            "Quản trị viên"});
            this.signup_accounttype.Location = new System.Drawing.Point(126, 105);
            this.signup_accounttype.Name = "signup_accounttype";
            this.signup_accounttype.Size = new System.Drawing.Size(100, 25);
            this.signup_accounttype.TabIndex = 21;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel6.Location = new System.Drawing.Point(22, 132);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(205, 1);
            this.panel6.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Account Type:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel5.Location = new System.Drawing.Point(23, 296);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(340, 1);
            this.panel5.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel3.Location = new System.Drawing.Point(23, 241);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 1);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel4.Location = new System.Drawing.Point(22, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(340, 1);
            this.panel4.TabIndex = 17;
            // 
            // signup_close
            // 
            this.signup_close.AutoSize = true;
            this.signup_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.signup_close.Location = new System.Drawing.Point(359, 4);
            this.signup_close.Name = "signup_close";
            this.signup_close.Size = new System.Drawing.Size(17, 17);
            this.signup_close.TabIndex = 13;
            this.signup_close.Text = "X";
            this.signup_close.Click += new System.EventHandler(this.signup_close_Click);
            // 
            // signup_email
            // 
            this.signup_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.signup_email.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_email.Location = new System.Drawing.Point(126, 162);
            this.signup_email.Multiline = true;
            this.signup_email.Name = "signup_email";
            this.signup_email.Size = new System.Drawing.Size(225, 18);
            this.signup_email.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email Address:";
            // 
            // signup_loginHere
            // 
            this.signup_loginHere.AutoSize = true;
            this.signup_loginHere.BackColor = System.Drawing.SystemColors.Window;
            this.signup_loginHere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup_loginHere.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_loginHere.ForeColor = System.Drawing.Color.Gray;
            this.signup_loginHere.Location = new System.Drawing.Point(216, 435);
            this.signup_loginHere.Name = "signup_loginHere";
            this.signup_loginHere.Size = new System.Drawing.Size(78, 18);
            this.signup_loginHere.TabIndex = 10;
            this.signup_loginHere.Text = "Login here";
            this.signup_loginHere.Click += new System.EventHandler(this.signup_loginHere_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Already have an account?";
            // 
            // signup_showPass
            // 
            this.signup_showPass.AutoSize = true;
            this.signup_showPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup_showPass.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_showPass.Location = new System.Drawing.Point(233, 303);
            this.signup_showPass.Name = "signup_showPass";
            this.signup_showPass.Size = new System.Drawing.Size(129, 22);
            this.signup_showPass.TabIndex = 8;
            this.signup_showPass.Text = "Show Password";
            this.signup_showPass.UseVisualStyleBackColor = true;
            this.signup_showPass.CheckedChanged += new System.EventHandler(this.signup_showPass_CheckedChanged);
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnSignup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignup.FlatAppearance.BorderSize = 0;
            this.btnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignup.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSignup.Location = new System.Drawing.Point(22, 341);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(100, 30);
            this.btnSignup.TabIndex = 7;
            this.btnSignup.Text = "SIGNUP";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // signup_password
            // 
            this.signup_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.signup_password.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_password.Location = new System.Drawing.Point(105, 272);
            this.signup_password.Multiline = true;
            this.signup_password.Name = "signup_password";
            this.signup_password.PasswordChar = '*';
            this.signup_password.Size = new System.Drawing.Size(225, 18);
            this.signup_password.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // signup_username
            // 
            this.signup_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.signup_username.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_username.Location = new System.Drawing.Point(105, 217);
            this.signup_username.Multiline = true;
            this.signup_username.Name = "signup_username";
            this.signup_username.Size = new System.Drawing.Size(225, 18);
            this.signup_username.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Get Started";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel2.Controls.Add(this.iconPictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 473);
            this.panel2.TabIndex = 11;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Meteor;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.Window;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 107;
            this.iconPictureBox1.Location = new System.Drawing.Point(75, 176);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(122, 107);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(634, 475);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox signup_showPass;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.TextBox signup_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox signup_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label signup_loginHere;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox signup_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label signup_close;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox signup_accounttype;
    }
}