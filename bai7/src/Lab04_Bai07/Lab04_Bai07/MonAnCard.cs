using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_Bai07
{
    public partial class MonAnCard : UserControl
    {
        public MonAnDto MonAnData { get; private set; } = new MonAnDto();
        public event EventHandler<int>? DeleteClicked;

        public MonAnCard()
        {
            InitializeComponent();
            picAnhMonAn.SizeMode = PictureBoxSizeMode.StretchImage;
            picAnhMonAn.BorderStyle = BorderStyle.None;

            // Đổi con trỏ thành hình bàn tay và gắn sự kiện bấm vào tên món
            lblTenMon.Cursor = Cursors.Hand;
            lblTenMon.Click -= lblTenMon_Click;
            lblTenMon.Click += lblTenMon_Click;

            this.Resize += MonAnCard_Resize;
            ApplyResponsiveLayout();
        }

        private void MonAnCard_Resize(object? sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            if (w <= 0 || h <= 0) return;

            // 1. Khung hiển thị ảnh món ăn nằm gọn bên trong viền khung gỗ
            int picSize = Math.Max(60, (int)(h * 0.46));
            int picX = (int)(w * 0.262);
            int picY = (int)(h * 0.28);
            picAnhMonAn.SetBounds(picX, picY, picSize, picSize);

            // Bo góc nhẹ 8px cho ảnh hòa vào khung gỗ
            var path = new GraphicsPath();
            int r = 8;
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(picSize - r, 0, r, r, 270, 90);
            path.AddArc(picSize - r, picSize - r, r, r, 0, 90);
            path.AddArc(0, picSize - r, r, r, 90, 90);
            path.CloseFigure();
            picAnhMonAn.Region?.Dispose();
            picAnhMonAn.Region = new Region(path);

            // 2. Cột thông tin nằm gọn trong bảng gỗ
            int infoLeft = picAnhMonAn.Right + 10;
            int infoRight = (int)(w * 0.675);
            int infoWidth = Math.Max(100, infoRight - infoLeft);

            int topY = (int)(h * 0.265);
            int rowGap = Math.Max(22, (int)(h * 0.17));

            lblTenMon.SetBounds(infoLeft, topY, infoWidth, rowGap);

            // Dòng Giá
            lblGia.AutoSize = true;
            lblGia.Location = new Point(infoLeft, topY + rowGap);
            txtGia.AutoSize = false;
            txtGia.SetBounds(
                lblGia.Right + 4,
                topY + rowGap,
                Math.Max(60, infoRight - (lblGia.Right + 4)),
                rowGap
            );

            // Dòng Đóng góp bởi
            lblDongGop.AutoSize = true;
            lblDongGop.Location = new Point(infoLeft, topY + rowGap * 2);
            txtDongGop.AutoSize = false;
            txtDongGop.SetBounds(
                lblDongGop.Right + 4,
                topY + rowGap * 2,
                Math.Max(60, infoRight - (lblDongGop.Right + 4)),
                rowGap
            );

            // 3. Nút Xóa nằm bên phải bảng gỗ
            int btnW = Math.Max(56, (int)(w * 0.095));
            int btnH = Math.Max(38, (int)(h * 0.31));
            int btnX = (int)(w * 0.772);
            int btnY = (int)(h * 0.375);
            btnXoa.SetBounds(btnX, btnY, btnW, btnH);
        }

        public void SetData(MonAnDto mon, bool allowDelete = true)
        {
            MonAnData = mon;

            lblTenMon.Text = mon.TenMonAn;
            txtGia.Text = $"{mon.Gia:N0} VNĐ";
            txtDongGop.Text = mon.NguoiDongGop;
            btnXoa.Visible = allowDelete;

            ApplyResponsiveLayout();
            _ = LoadImageAsync(mon.HinhAnh, mon.TenMonAn);
        }

        private async Task LoadImageAsync(string source, string tenMon)
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
                        var ms = new MemoryStream(bytes);
                        picAnhMonAn.Image = Image.FromStream(ms);
                        return;
                    }

                    // 2. Nếu có sẵn file trên máy cục bộ -> đọc từ ổ cứng
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

                    // 3. Nếu không có trên máy Client -> lấy tên file và tải qua endpoint /images/<tenfile> của Server
                    string fileName = Path.GetFileName(source.Replace('\\', '/'));
                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        string serverImageUrl = $"{ApiClient.BaseUrl.TrimEnd('/')}/images/{Uri.EscapeDataString(fileName)}";
                        using var http = new HttpClient();
                        byte[] bytes = await http.GetByteArrayAsync(serverImageUrl);
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
                    new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Brushes.SaddleBrown,
                    new RectangleF(4, 4, w - 8, h - 8),
                    sf
                );
            }
            picAnhMonAn.Image = bmp;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, MonAnData.Id);
        }

        private void lblTenMon_Click(object? sender, EventArgs e)
        {
            string moTa = string.IsNullOrWhiteSpace(MonAnData.MoTa)
                ? "Chưa có mô tả cho món ăn này."
                : MonAnData.MoTa;

            MessageBox.Show(
                moTa,
                $"Mô tả món: {MonAnData.TenMonAn}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void lblGia_Click(object sender, EventArgs e) { }
        private void lblDongGop_Click(object sender, EventArgs e) { }
        private void picAnhMonAn_Click(object sender, EventArgs e) { }
        private void txtDongGop_Click(object sender, EventArgs e) { }
        private void txtGia_Click(object sender, EventArgs e) { }
        private void MonAnCard_Load(object sender, EventArgs e) { }
    }
}