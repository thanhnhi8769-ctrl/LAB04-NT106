using System;
using System.Windows.Forms;

namespace Lab04_Bai07
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;
            // Mặc định ẩn mật khẩu khi mở Form
            txtPassword.UseSystemPasswordChar = true;
            this.AcceptButton = btnLogin;
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            // Tích chọn -> hiện mật khẩu (UseSystemPasswordChar = false); bỏ tích -> ẩn mật khẩu
            txtPassword.UseSystemPasswordChar = !ckbHienMatKhau.Checked;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var (success, message) = await ApiClient.LoginAsync(username, password);
                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được tới API Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinklblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using var frmSignup = new SignupForm();
            frmSignup.ShowDialog(this);
        }

        private void lblDangNhap_Click(object sender, EventArgs e)
        {
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
        }

        private void txtUsername_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
        }

        private void txtPassword_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {
        }
    }
}