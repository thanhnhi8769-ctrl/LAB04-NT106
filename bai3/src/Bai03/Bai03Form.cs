using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Web.WebView2.Core;

namespace Bai03
{
    public partial class Bai03Form : Form
    {
        public Bai03Form()
        {
            InitializeComponent();
        }

        private async void Bai03Form_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);

            if (!string.IsNullOrWhiteSpace(txtURL.Text))
            {
                webView21.CoreWebView2.Navigate(txtURL.Text);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtURL.Text))
            {
                if (webView21 != null && webView21.CoreWebView2 != null)
                {
                    webView21.CoreWebView2.Navigate(txtURL.Text);
                }
                else
                {
                    MessageBox.Show("WebView2 đang khởi tạo, vui lòng đợi 1-2 giây rồi thử lại!", "Thông báo");
                }
            }
        }

        private void btnDownloadFiles_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "HTML Files|*.html";
                sfd.FileName = "page.html";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(txtURL.Text, sfd.FileName);
                        }
                        MessageBox.Show("Tải file HTML thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải file: " + ex.Message);
                    }
                }
            }
        }

        private void btnDownloadResources_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Chọn thư mục để lưu hình ảnh";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string html = "";
                        using (WebClient client = new WebClient())
                        {
                            html = client.DownloadString(txtURL.Text);
                        }

                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(html);
                        var imgNodes = doc.DocumentNode.SelectNodes("//img");

                        if (imgNodes == null)
                        {
                            MessageBox.Show("Không tìm thấy hình ảnh nào!");
                            return;
                        }

                        int count = 0;
                        using (WebClient client = new WebClient())
                        {
                            foreach (var img in imgNodes)
                            {
                                string src = img.GetAttributeValue("src", null);
                                if (string.IsNullOrEmpty(src)) continue;

                                Uri baseUri = new Uri(txtURL.Text);
                                Uri imgUri = new Uri(baseUri, src);

                                string fileName = Path.GetFileName(imgUri.LocalPath);
                                if (string.IsNullOrEmpty(fileName)) continue;

                                string savePath = Path.Combine(fbd.SelectedPath, fileName);

                                try
                                {
                                    client.DownloadFile(imgUri, savePath);
                                    count++;
                                }
                                catch { }
                            }
                        }
                        MessageBox.Show($"Đã tải thành công {count} hình ảnh vào thư mục:\n{fbd.SelectedPath}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải resource: " + ex.Message);
                    }
                }
            }
        }

        private void btnViewSource_Click(object sender, EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string html = client.DownloadString(txtURL.Text);
                    Form sourceForm = new Form();
                    sourceForm.Text = "Mã nguồn HTML";
                    sourceForm.Size = new System.Drawing.Size(800, 600);

                    RichTextBox rtb = new RichTextBox();
                    rtb.Dock = DockStyle.Fill;
                    rtb.Text = html;
                    rtb.Font = new System.Drawing.Font("Consolas", 10);

                    sourceForm.Controls.Add(rtb);
                    sourceForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã nguồn: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close()
        }
    }
}
