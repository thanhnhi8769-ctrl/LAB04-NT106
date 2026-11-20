using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab04_Bai07
{
    public partial class ThemMonAn : Form
    {
        private TextBox? txtDiaChi;
        private Button? btnThem;
        private Button? btnClear;

        public ThemMonAn()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;
            EnsureActionControls();
        }

        private void EnsureActionControls()
        {
            if (this.Controls.Find("btnThem", true).Length == 0)
            {
                int bottomY = Math.Max(richTxtMoTa.Bottom + 12, this.ClientSize.Height - 46);

                btnClear = new Button
                {
                    Name = "btnClear",
                    Text = "Clear",
                    Size = new Size(78, 30),
                    Location = new Point(richTxtMoTa.Right - 166, bottomY),
                    BackColor = Color.PapayaWhip,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnClear.FlatAppearance.BorderColor = Color.BurlyWood;
                btnClear.Click += BtnClear_Click;

                btnThem = new Button
                {
                    Name = "btnThem",
                    Text = "Thêm",
                    Size = new Size(78, 30),
                    Location = new Point(richTxtMoTa.Right - 78, bottomY),
                    BackColor = Color.NavajoWhite,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnThem.FlatAppearance.BorderColor = Color.SandyBrown;
                btnThem.Click += BtnThem_Click;

                this.Controls.AddRange(new Control[] { btnClear, btnThem });
                btnClear.BringToFront();
                btnThem.BringToFront();
            }
            else
            {
                btnThem = this.Controls.Find("btnThem", true)[0] as Button;
                btnClear = this.Controls.Find("btnClear", true)[0] as Button;
                if (btnThem != null)
                {
                    btnThem.Click -= BtnThem_Click;
                    btnThem.Click += BtnThem_Click;
                }
                if (btnClear != null)
                {
                    btnClear.Click -= BtnClear_Click;
                    btnClear.Click += BtnClear_Click;
                }
            }

            if (this.Controls.Find("txtDiaChi", true).Length > 0)
            {
                txtDiaChi = this.Controls.Find("txtDiaChi", true)[0] as TextBox;
            }
        }

        private void btnLinkAnh_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn hình ảnh món ăn",
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*"
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtHinhAnh.Text = ofd.FileName;
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            txtTenMonAn.Clear();
            txtGia.Clear();
            txtHinhAnh.Clear();
            richTxtMoTa.Clear();
            txtDiaChi?.Clear();
            txtTenMonAn.Focus();
        }

        private async void BtnThem_Click(object? sender, EventArgs e)
        {
            string tenMon = txtTenMonAn.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenMon))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMonAn.Focus();
                return;
            }

            string giaRaw = txtGia.Text.Trim().Replace(",", "").Replace(".", "").Replace("đ", "").Replace("VNĐ", "").Trim();
            if (!int.TryParse(giaRaw, out int gia) || gia < 0)
            {
                MessageBox.Show("Giá món ăn không hợp lệ! Vui lòng nhập số nguyên dương.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            string imgPath = txtHinhAnh.Text.Trim();
            string imgBase64 = "";
            string imgFileNameOrUrl = imgPath;

            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
            {
                try
                {
                    byte[] fileBytes = await File.ReadAllBytesAsync(imgPath);
                    imgBase64 = Convert.ToBase64String(fileBytes);
                    imgFileNameOrUrl = Path.GetFileName(imgPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể đọc file ảnh đã chọn: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MonAnDto mon = new MonAnDto
            {
                TenMonAn = tenMon,
                Gia = gia,
                DiaChi = txtDiaChi?.Text.Trim() ?? "",
                HinhAnh = imgFileNameOrUrl,
                ImageBase64 = imgBase64,
                MoTa = richTxtMoTa.Text.Trim()
            };

            if (btnThem != null) btnThem.Enabled = false;
            try
            {
                var (success, message) = await ApiClient.AddMonAnAsync(mon);
                if (success)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Thêm món thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được tới API Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (btnThem != null && !this.IsDisposed) btnThem.Enabled = true;
            }
        }

        private void lblThemMonAn_Click(object sender, EventArgs e) { }
        private void lblTenMonAn_Click(object sender, EventArgs e) { }
        private void txtTenMonAn_TextChanged(object sender, EventArgs e) { }
        private void lblGia_Click(object sender, EventArgs e) { }
        private void txtGia_TextChanged(object sender, EventArgs e) { }
        private void lblHinhAnh_Click(object sender, EventArgs e) { }
        private void txtHinhAnh_TextChanged(object sender, EventArgs e) { }
        private void lblMoTa_Click(object sender, EventArgs e) { }
        private void richTxtMoTa_TextChanged(object sender, EventArgs e) { }
    }
}