using System;
using System.Windows.Forms;

namespace Lab04_Bai07
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;
            txtPassword.UseSystemPasswordChar = true;

            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.AddRange(new object[] { "vi", "en" });
            }
            if (comboBox1.SelectedIndex < 0 && comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            if (!rabtnFemale.Checked && !rabtnMale.Checked)
            {
                rabtnMale.Checked = true;
            }
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0 && comboBox1.SelectedIndex < 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void ckbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !ckbShowPassword.Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            ckbShowPassword.Checked = false;
            txtPassword.UseSystemPasswordChar = true;

            txtFirstname.Clear();
            txtLastname.Clear();
            textBox1.Clear(); // Email
            textBox2.Clear(); // Phone
            dateTimePicker1.Value = DateTime.Today;

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            rabtnMale.Checked = true;
            rabtnFemale.Checked = false;
            txtUsername.Focus();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDto user = new UserDto
            {
                Username = username,
                Password = password,
                Firstname = txtFirstname.Text.Trim(),
                Lastname = txtLastname.Text.Trim(),
                Email = textBox1.Text.Trim(),
                Phone = textBox2.Text.Trim(),
                Birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                Language = comboBox1.SelectedItem?.ToString() ?? "vi",
                Sex = rabtnFemale.Checked ? "Female" : "Male"
            };

            try
            {
                var (success, message) = await ApiClient.SignupAsync(user);
                if (success)
                {
                    MessageBox.Show(message, "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Đăng ký thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được tới API Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void lblDangKiTaiKhoan_Click(object sender, EventArgs e)
        {
        }

        private void gpbSignup_Enter(object sender, EventArgs e)
        {
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
        }

        private void gpbUserInformation_Enter(object sender, EventArgs e)
        {
        }

        private void lblFirstname_Click(object sender, EventArgs e)
        {
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblLastname_Click(object sender, EventArgs e)
        {
        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lblSex_Click(object sender, EventArgs e)
        {
        }

        private void rabtnFemale_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rabtnMale_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}