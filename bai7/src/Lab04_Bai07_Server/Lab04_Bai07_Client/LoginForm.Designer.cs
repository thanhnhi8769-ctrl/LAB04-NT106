namespace Lab04_Bai07_Client
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lblDangNhap = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new MaskedTextBox();
            txtPassword = new MaskedTextBox();
            lblSignup = new Label();
            LinklblSignUp = new LinkLabel();
            btnLogin = new Button();
            ckbHienMatKhau = new CheckBox();
            SuspendLayout();
            // 
            // lblDangNhap
            // 
            lblDangNhap.AutoSize = true;
            lblDangNhap.BackColor = Color.Transparent;
            lblDangNhap.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblDangNhap.ForeColor = Color.SaddleBrown;
            lblDangNhap.Location = new Point(220, 151);
            lblDangNhap.Name = "lblDangNhap";
            lblDangNhap.Size = new Size(124, 22);
            lblDangNhap.TabIndex = 0;
            lblDangNhap.Text = "ĐĂNG NHẬP";
            lblDangNhap.Click += lblDangNhap_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Location = new Point(128, 218);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(69, 17);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            lblUsername.Click += lblUsername_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(128, 252);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            lblPassword.Click += lblPassword_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(220, 215);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(143, 24);
            txtUsername.TabIndex = 3;
            txtUsername.MaskInputRejected += txtUsername_MaskInputRejected;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(220, 249);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(143, 24);
            txtPassword.TabIndex = 4;
            txtPassword.MaskInputRejected += txtPassword_MaskInputRejected;
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.BackColor = Color.Transparent;
            lblSignup.Location = new Point(163, 303);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(169, 17);
            lblSignup.TabIndex = 5;
            lblSignup.Text = "Don't have an account yet?";
            lblSignup.Click += lblSignup_Click;
            // 
            // LinklblSignUp
            // 
            LinklblSignUp.ActiveLinkColor = Color.SaddleBrown;
            LinklblSignUp.AutoSize = true;
            LinklblSignUp.BackColor = Color.Transparent;
            LinklblSignUp.Location = new Point(338, 303);
            LinklblSignUp.Name = "LinklblSignUp";
            LinklblSignUp.Size = new Size(51, 17);
            LinklblSignUp.TabIndex = 6;
            LinklblSignUp.TabStop = true;
            LinklblSignUp.Text = "Sign up";
            LinklblSignUp.LinkClicked += LinklblSignUp_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 13F);
            btnLogin.ForeColor = Color.Bisque;
            btnLogin.Location = new Point(397, 215);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(69, 75);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // ckbHienMatKhau
            // 
            ckbHienMatKhau.AutoSize = true;
            ckbHienMatKhau.BackColor = Color.Transparent;
            ckbHienMatKhau.FlatAppearance.BorderSize = 0;
            ckbHienMatKhau.FlatStyle = FlatStyle.Flat;
            ckbHienMatKhau.Font = new Font("Times New Roman", 10F);
            ckbHienMatKhau.ForeColor = SystemColors.ControlText;
            ckbHienMatKhau.Location = new Point(220, 279);
            ckbHienMatKhau.Name = "ckbHienMatKhau";
            ckbHienMatKhau.Size = new Size(104, 20);
            ckbHienMatKhau.TabIndex = 8;
            ckbHienMatKhau.Text = "Hiện mật khẩu";
            ckbHienMatKhau.UseVisualStyleBackColor = false;
            ckbHienMatKhau.CheckedChanged += ckbHienMatKhau_CheckedChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(563, 366);
            Controls.Add(ckbHienMatKhau);
            Controls.Add(btnLogin);
            Controls.Add(LinklblSignUp);
            Controls.Add(lblSignup);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblDangNhap);
            DoubleBuffered = true;
            Font = new Font("Times New Roman", 11F);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDangNhap;
        private Label lblUsername;
        private Label lblPassword;
        private MaskedTextBox txtUsername;
        private MaskedTextBox txtPassword;
        private Label lblSignup;
        private LinkLabel LinklblSignUp;
        private Button btnLogin;
        private CheckBox ckbHienMatKhau;
    }
}