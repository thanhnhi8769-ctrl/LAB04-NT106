using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
namespace Bai01
{
    public partial class Bai01Form : Form
    {
        public Bai01Form()
        {
            InitializeComponent();
        }

#pragma warning disable SYSLIB0014

        private string getHTML(string szURL)
        {
            // Tạo yêu cầu gửi đến Web Server
            WebRequest request = WebRequest.Create(szURL);

            // Thời gian chờ tối đa: 10 giây
            request.Timeout = 10000;

            // Nhận phản hồi và đọc nội dung HTML
            using (WebResponse response = request.GetResponse())
            using (Stream dataStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                return reader.ReadToEnd();
            }
        }

#pragma warning restore SYSLIB0014        
        private void btnGET_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy URL từ TextBox
                string url = txtURL.Text.Trim();

                // Kiểm tra URL rỗng
                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show(
                        "Vui lòng nhập địa chỉ URL!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Kiểm tra định dạng URL
                Uri uri;

                if (!Uri.TryCreate(url, UriKind.Absolute, out uri)
                    || (uri.Scheme != Uri.UriSchemeHttp
                    && uri.Scheme != Uri.UriSchemeHttps))
                {
                    MessageBox.Show(
                        "Địa chỉ URL không hợp lệ!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Xóa dữ liệu cũ
                rtbHTML.Clear();

                // Gọi hàm lấy HTML
                string html = getHTML(url);

                // Hiển thị HTML
                rtbHTML.Text = html;
            }
            catch (WebException ex)
            {
                MessageBox.Show(
                    "Lỗi kết nối Web Server!\n" + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

     
}
