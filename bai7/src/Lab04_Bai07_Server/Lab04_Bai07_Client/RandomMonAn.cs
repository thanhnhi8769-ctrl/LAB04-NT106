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
                    string localPath = File.Exists(source)
                        ? source
                        : Path.Combine(Application.StartupPath, source);

                    if (File.Exists(localPath))
                    {
                        byte[] bytes = await File.ReadAllBytesAsync(localPath);
                        var ms = new MemoryStream(bytes);
                        picAnhMonAn.Image = Image.FromStream(ms);
                        return;
                    }

                    if (source.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                        source.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    {
                        using var http = new HttpClient();
                        byte[] bytes = await http.GetByteArrayAsync(source);
                        var ms = new MemoryStream(bytes);
                        picAnhMonAn.Image = Image.FromStream(ms);
                        return;
                    }
                }
            }
            catch
            {
            }

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