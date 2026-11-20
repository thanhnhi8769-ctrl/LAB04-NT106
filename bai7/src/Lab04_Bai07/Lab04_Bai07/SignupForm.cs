using System;
using System.Text.RegularExpressions;
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

            // Giới hạn ô SĐT tối đa 10 ký tự và chỉ cho nhập chữ số
            textBox2.MaxLength = 10;
            textBox2.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
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
            string email = textBox1.Text.Trim();
            string phone = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Username và Password!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            // Kiểm tra định dạng Email (ví dụ: ten@gmail.com)
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Định dạng Email không hợp lệ (ví dụ: ten@gmail.com)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }

            // Kiểm tra định dạng Số điện thoại Việt Nam (10 chữ số, đầu số 03, 05, 07, 08, 09)
            if (string.IsNullOrEmpty(phone) || !Regex.IsMatch(phone, @"^(0[3|5|7|8|9])[0-9]{8}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng đầu số Việt Nam (03, 05, 07, 08, 09)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }

            UserDto user = new UserDto
            {
                Username = username,
                Password = password,
                Firstname = txtFirstname.Text.Trim(),
                Lastname = txtLastname.Text.Trim(),
                Email = email,
                Phone = phone,
                Birthday = dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                Language = comboBox1.SelectedItem?.ToString() ?? "vi",
                Sex = rabtnFemale.Checked ? "Female" : "Male"
            };

            btnSubmit.Enabled = false;
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
            finally
            {
                btnSubmit.Enabled = true;
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