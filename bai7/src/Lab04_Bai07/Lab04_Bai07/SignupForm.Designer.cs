namespace Lab04_Bai07
{
    partial class SignupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignupForm));
            lblDangKiTaiKhoan = new Label();
            gpbSignup = new GroupBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            gpbUserInformation = new GroupBox();
            rabtnMale = new RadioButton();
            rabtnFemale = new RadioButton();
            lblSex = new Label();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtLastname = new TextBox();
            txtFirstname = new TextBox();
            lblLastname = new Label();
            lblFirstname = new Label();
            btnClear = new Button();
            btnSubmit = new Button();
            ckbShowPassword = new CheckBox();
            gpbSignup.SuspendLayout();
            gpbUserInformation.SuspendLayout();
            SuspendLayout();
            // 
            // lblDangKiTaiKhoan
            // 
            lblDangKiTaiKhoan.AutoSize = true;
            lblDangKiTaiKhoan.BackColor = Color.Transparent;
            lblDangKiTaiKhoan.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblDangKiTaiKhoan.ForeColor = Color.SaddleBrown;
            lblDangKiTaiKhoan.Location = new Point(214, 96);
            lblDangKiTaiKhoan.Name = "lblDangKiTaiKhoan";
            lblDangKiTaiKhoan.Size = new Size(205, 22);
            lblDangKiTaiKhoan.TabIndex = 0;
            lblDangKiTaiKhoan.Text = "ĐĂNG KÍ TÀI KHOẢN";
            lblDangKiTaiKhoan.TextAlign = ContentAlignment.MiddleCenter;
            lblDangKiTaiKhoan.Click += lblDangKiTaiKhoan_Click;
            // 
            // gpbSignup
            // 
            gpbSignup.BackColor = Color.Transparent;
            gpbSignup.Controls.Add(txtPassword);
            gpbSignup.Controls.Add(txtUsername);
            gpbSignup.Controls.Add(lblPassword);
            gpbSignup.Controls.Add(lblUsername);
            gpbSignup.ForeColor = Color.SaddleBrown;
            gpbSignup.Location = new Point(206, 177);
            gpbSignup.Name = "gpbSignup";
            gpbSignup.Size = new Size(224, 69);
            gpbSignup.TabIndex = 1;
            gpbSignup.TabStop = false;
            gpbSignup.Text = "Sign up";
            gpbSignup.Enter += gpbSignup_Enter;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(81, 43);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(137, 24);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(81, 13);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(137, 24);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(6, 46);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            lblPassword.Click += lblPassword_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(6, 20);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(69, 17);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            lblUsername.Click += lblUsername_Click;
            // 
            // gpbUserInformation
            // 
            gpbUserInformation.BackColor = Color.Transparent;
            gpbUserInformation.Controls.Add(rabtnMale);
            gpbUserInformation.Controls.Add(rabtnFemale);
            gpbUserInformation.Controls.Add(lblSex);
            gpbUserInformation.Controls.Add(dateTimePicker1);
            gpbUserInformation.Controls.Add(comboBox1);
            gpbUserInformation.Controls.Add(textBox2);
            gpbUserInformation.Controls.Add(textBox1);
            gpbUserInformation.Controls.Add(label5);
            gpbUserInformation.Controls.Add(label4);
            gpbUserInformation.Controls.Add(label3);
            gpbUserInformation.Controls.Add(label2);
            gpbUserInformation.Controls.Add(txtLastname);
            gpbUserInformation.Controls.Add(txtFirstname);
            gpbUserInformation.Controls.Add(lblLastname);
            gpbUserInformation.Controls.Add(lblFirstname);
            gpbUserInformation.ForeColor = Color.SaddleBrown;
            gpbUserInformation.Location = new Point(191, 312);
            gpbUserInformation.Name = "gpbUserInformation";
            gpbUserInformation.Size = new Size(262, 245);
            gpbUserInformation.TabIndex = 5;
            gpbUserInformation.TabStop = false;
            gpbUserInformation.Text = "User Information";
            gpbUserInformation.Enter += gpbUserInformation_Enter;
            // 
            // rabtnMale
            // 
            rabtnMale.AutoSize = true;
            rabtnMale.ForeColor = Color.Black;
            rabtnMale.Location = new Point(183, 211);
            rabtnMale.Name = "rabtnMale";
            rabtnMale.Size = new Size(56, 21);
            rabtnMale.TabIndex = 18;
            rabtnMale.TabStop = true;
            rabtnMale.Text = "Male";
            rabtnMale.UseVisualStyleBackColor = true;
            rabtnMale.CheckedChanged += rabtnMale_CheckedChanged;
            // 
            // rabtnFemale
            // 
            rabtnFemale.AutoSize = true;
            rabtnFemale.ForeColor = Color.Black;
            rabtnFemale.Location = new Point(93, 210);
            rabtnFemale.Name = "rabtnFemale";
            rabtnFemale.Size = new Size(69, 21);
            rabtnFemale.TabIndex = 17;
            rabtnFemale.TabStop = true;
            rabtnFemale.Text = "Female";
            rabtnFemale.UseVisualStyleBackColor = true;
            rabtnFemale.CheckedChanged += rabtnFemale_CheckedChanged;
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Location = new Point(15, 212);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(30, 17);
            lblSex.TabIndex = 16;
            lblSex.Text = "Sex";
            lblSex.Click += lblSex_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(56, 146);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 24);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(93, 176);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(163, 25);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(87, 116);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(169, 24);
            textBox2.TabIndex = 10;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(87, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 24);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 179);
            label5.Name = "label5";
            label5.Size = new Size(72, 17);
            label5.TabIndex = 7;
            label5.Text = "Languages";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 152);
            label4.Name = "label4";
            label4.Size = new Size(37, 17);
            label4.TabIndex = 6;
            label4.Text = "Birth";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 119);
            label3.Name = "label3";
            label3.Size = new Size(45, 17);
            label3.TabIndex = 5;
            label3.Text = "Phone";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 89);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 4;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // txtLastname
            // 
            txtLastname.Location = new Point(87, 56);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(169, 24);
            txtLastname.TabIndex = 3;
            txtLastname.TextChanged += txtLastname_TextChanged;
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(87, 26);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(169, 24);
            txtFirstname.TabIndex = 2;
            txtFirstname.TextChanged += txtFirstname_TextChanged;
            // 
            // lblLastname
            // 
            lblLastname.AutoSize = true;
            lblLastname.Location = new Point(15, 59);
            lblLastname.Name = "lblLastname";
            lblLastname.Size = new Size(70, 17);
            lblLastname.TabIndex = 1;
            lblLastname.Text = "Last name";
            lblLastname.Click += lblLastname_Click;
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Location = new Point(15, 29);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(70, 17);
            lblFirstname.TabIndex = 0;
            lblFirstname.Text = "First name";
            lblFirstname.Click += lblFirstname_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Transparent;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Times New Roman", 13F);
            btnClear.ForeColor = Color.SeaShell;
            btnClear.Location = new Point(387, 635);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 28);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Times New Roman", 13F);
            btnSubmit.ForeColor = Color.SeaShell;
            btnSubmit.Location = new Point(518, 635);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 28);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // ckbShowPassword
            // 
            ckbShowPassword.AutoSize = true;
            ckbShowPassword.BackColor = Color.Transparent;
            ckbShowPassword.Cursor = Cursors.Hand;
            ckbShowPassword.FlatAppearance.BorderSize = 0;
            ckbShowPassword.FlatStyle = FlatStyle.Flat;
            ckbShowPassword.Font = new Font("Times New Roman", 9F);
            ckbShowPassword.ForeColor = Color.SaddleBrown;
            ckbShowPassword.Location = new Point(287, 252);
            ckbShowPassword.Name = "ckbShowPassword";
            ckbShowPassword.Size = new Size(100, 19);
            ckbShowPassword.TabIndex = 9;
            ckbShowPassword.Text = "Show Password";
            ckbShowPassword.UseVisualStyleBackColor = false;
            ckbShowPassword.CheckedChanged += ckbShowPassword_CheckedChanged;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(631, 685);
            Controls.Add(ckbShowPassword);
            Controls.Add(btnSubmit);
            Controls.Add(btnClear);
            Controls.Add(gpbUserInformation);
            Controls.Add(gpbSignup);
            Controls.Add(lblDangKiTaiKhoan);
            DoubleBuffered = true;
            Font = new Font("Times New Roman", 11F);
            Name = "SignupForm";
            Text = "SignupForm";
            Load += SignupForm_Load;
            gpbSignup.ResumeLayout(false);
            gpbSignup.PerformLayout();
            gpbUserInformation.ResumeLayout(false);
            gpbUserInformation.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDangKiTaiKhoan;
        private GroupBox gpbSignup;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblPassword;
        private Label lblUsername;
        private GroupBox gpbUserInformation;
        private TextBox txtLastname;
        private TextBox txtFirstname;
        private Label lblLastname;
        private Label lblFirstname;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private Button btnClear;
        private Button btnSubmit;
        private RadioButton rabtnMale;
        private RadioButton rabtnFemale;
        private Label lblSex;
        private CheckBox ckbShowPassword;
    }
}