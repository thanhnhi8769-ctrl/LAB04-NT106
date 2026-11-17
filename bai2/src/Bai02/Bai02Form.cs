using System.Net;

namespace Bai02
{
    public partial class Bai02Form : Form
    {
        public Bai02Form()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "HTML Files|*.html|All Files|*.*";
                sfd.FileName = "uit.html";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = sfd.FileName;
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            string filePath = txtFilePath.Text.Trim();

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(filePath))
            {
                lblTrangThai.Text = "Vui lòng nhập đủ URL và đường dẫn!";
                lblTrangThai.ForeColor = Color.Red;
                return;
            }

            try
            {
                lblTrangThai.Text = "Đang tải...";
                lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
                Application.DoEvents(); // Cập nhật giao diện ngay lập tức

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, filePath); // Tải file
                    string html = File.ReadAllText(filePath); // Đọc nội dung
                    rtbContent.Text = html; // Hiển thị lên RichTextBox
                }

                lblTrangThai.Text = "Tải thành công!";
                lblTrangThai.ForeColor = Color.FromArgb(100, 100, 100);
                MessageBox.Show("Đã tải và lưu file thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Lỗi: " + ex.Message;
                lblTrangThai.ForeColor = Color.Red;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
