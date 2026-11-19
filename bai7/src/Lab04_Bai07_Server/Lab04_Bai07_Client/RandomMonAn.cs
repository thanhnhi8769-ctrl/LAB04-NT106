using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_Bai07_Client
{
    public partial class RandomMonAn : Form
    {
        public MonAnDto? SelectedMonAn { get; private set; }

        public RandomMonAn()
        {
            InitializeComponent();
            picAnhMonAn.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public RandomMonAn(MonAnDto mon) : this()
        {
            SetData(mon);
        }

        public void SetData(MonAnDto mon)
        {
            SelectedMonAn = mon;
            this.Text = $"Ăn {mon.TenMonAn} đi!!!!";
            lblTenMon.Text = mon.TenMonAn;

            _ = LoadAnhMonAnAsync(mon.HinhAnh, mon.TenMonAn);
        }

        private async Task LoadAnhMonAnAsync(string source, string tenMon)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(source))
                {
                    // 1. Nếu là URL đầy đủ (http/https) -> tải trực tiếp từ mạng
                    if (source.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        source.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        using var http = new HttpClient();
                        byte[] bytes = await http.GetByteArrayAsync(source);
                        if (!IsDisposed)
                        {
                            var ms = new MemoryStream(bytes);
                            picAnhMonAn.Image = Image.FromStream(ms);
                        }
                        return;
                    }

                    // 2. Nếu có sẵn file trên máy cục bộ -> đọc từ ổ cứng
                    string localPath = File.Exists(source)
                        ? source
                        : Path.Combine(Application.StartupPath, source);

                    if (File.Exists(localPath))
                    {
                        byte[] bytes = await File.ReadAllBytesAsync(localPath);
                        if (!IsDisposed)
                        {
                            var ms = new MemoryStream(bytes);
                            picAnhMonAn.Image = Image.FromStream(ms);
                        }
                        return;
                    }

                    // 3. Nếu không có trên máy Client -> tải qua endpoint /images/<tenfile> của Server
                    string fileName = Path.GetFileName(source.Replace('\\', '/'));
                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        string serverImageUrl = $"{ApiClient.BaseUrl.TrimEnd('/')}/images/{Uri.EscapeDataString(fileName)}";
                        using var http = new HttpClient();
                        byte[] bytes = await http.GetByteArrayAsync(serverImageUrl);
                        if (!IsDisposed)
                        {
                            var ms = new MemoryStream(bytes);
                            picAnhMonAn.Image = Image.FromStream(ms);
                        }
                        return;
                    }
                }
            }
            catch
            {
            }

            if (IsDisposed) return;

            int w = Math.Max(1, picAnhMonAn.Width);
            int h = Math.Max(1, picAnhMonAn.Height);
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Bisque);
                using var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(
                    tenMon,
                    lblTenMon.Font,
                    Brushes.SaddleBrown,
                    new RectangleF(8, 8, w - 16, h - 16),
                    sf
                );
            }
            picAnhMonAn.Image = bmp;
        }

        private void picAnhMonAn_Click(object sender, EventArgs e)
        {
        }

        private void lblTenMon_Click(object sender, EventArgs e)
        {
        }
    }
}