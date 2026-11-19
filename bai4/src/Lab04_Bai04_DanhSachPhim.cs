using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LAB03
{
    // Form tạo hoàn toàn bằng code -> chỉ cần Add > Existing Item, không cần Designer.
    public class Lab04_Bai04_DanhSachPhim : Form
    {
        private readonly string tenKhach;
        private readonly string jsonPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phim.json");

        private Button btnLay;
        private ProgressBar prg;
        private Label lblTrangThai;
        private FlowLayoutPanel flow;

        public Lab04_Bai04_DanhSachPhim(string tenKhachHang)
        {
            tenKhach = tenKhachHang;

            Text = "Phim đang chiếu - Beta Cinemas";
            Size = new Size(760, 620);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(30, 20, 50);

            var top = new Panel { Dock = DockStyle.Top, Height = 90 };

            var lblTieuDe = new Label
            {
                Text = "Phim đang chiếu  |  Khách hàng: " + tenKhach,
                ForeColor = Color.Cornsilk,
                Font = new Font("Tahoma", 11F, FontStyle.Bold),
                AutoSize = true,
                Left = 12,
                Top = 10
            };

            btnLay = new Button
            {
                Text = "Lấy dữ liệu từ website",
                Left = 12,
                Top = 40,
                Width = 190,
                Height = 34,
                BackColor = Color.MediumPurple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLay.Click += btnLay_Click;

            prg = new ProgressBar { Left = 215, Top = 44, Width = 500, Height = 12, Minimum = 0, Maximum = 100 };
            lblTrangThai = new Label
            {
                Left = 215,
                Top = 60,
                Width = 500,
                ForeColor = Color.BurlyWood,
                Text = "Sẵn sàng."
            };

            top.Controls.AddRange(new Control[] { lblTieuDe, btnLay, prg, lblTrangThai });

            flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(30, 20, 50)
            };
            // Chỉ cuộn dọc, tắt thanh cuộn ngang
            flow.AutoScroll = false;
            flow.HorizontalScroll.Enabled = false;
            flow.HorizontalScroll.Visible = false;
            flow.HorizontalScroll.Maximum = 0;
            flow.AutoScroll = true;

            Controls.Add(flow);
            Controls.Add(top);

            Load += (s, e) =>
            {
                var ds = PhimScraper.DocJson(jsonPath);
                if (ds.Count > 0)
                {
                    HienThi(ds);
                    lblTrangThai.Text = $"Đã đọc {ds.Count} phim từ phim.json";
                }
                else
                {
                    lblTrangThai.Text = "Chưa có dữ liệu. Bấm \"Lấy dữ liệu từ website\".";
                }
            };
        }

        private async void btnLay_Click(object sender, EventArgs e)
        {
            btnLay.Enabled = false;
            prg.Value = 0;
            try
            {
                var progress = new Progress<int>(v => prg.Value = Math.Max(0, Math.Min(100, v)));
                var status = new Progress<string>(s => lblTrangThai.Text = s);

                var ds = await PhimScraper.LayDanhSachAsync(progress, status);

                if (ds.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy phim nào.\nTrang web có thể đổi cấu trúc. " +
                        "Mở file debug_phim.html (cạnh file .exe) để xem HTML.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblTrangThai.Text = "Không lấy được dữ liệu.";
                    return;
                }

                PhimScraper.LuuJson(jsonPath, ds);
                HienThi(ds);
                prg.Value = 100;
                lblTrangThai.Text = $"Hoàn tất: {ds.Count} phim, đã lưu vào phim.json";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTrangThai.Text = "Lỗi.";
            }
            finally
            {
                btnLay.Enabled = true;
            }
        }

        private void HienThi(List<PhimOnline> ds)
        {
            flow.SuspendLayout();
            foreach (Control c in flow.Controls) c.Dispose();
            flow.Controls.Clear();
            foreach (var p in ds) flow.Controls.Add(TaoItem(p));
            flow.ResumeLayout();
        }

        private Control TaoItem(PhimOnline p)
        {
            int w = flow.ClientSize.Width - 30;
            var pn = new Panel
            {
                Width = w,
                Height = 125,
                Margin = new Padding(5),
                BackColor = Color.FromArgb(50, 38, 80),
                Cursor = Cursors.Hand
            };

            // Poster (banner phim)
            var pb = new PictureBox
            {
                Left = 6,
                Top = 6,
                Width = 75,
                Height = 112,
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand
            };
            if (!string.IsNullOrEmpty(p.PosterUrl))
            {
                try { pb.LoadAsync(p.PosterUrl); } catch { }
            }

            // Tên phim
            var lblTen = new Label
            {
                Left = 92,
                Top = 6,
                Width = w - 210,
                Height = 24,
                AutoEllipsis = true,
                Font = new Font("Tahoma", 10.5F, FontStyle.Bold),
                ForeColor = Color.Cornsilk,
                Text = p.TenPhim,
                Cursor = Cursors.Hand
            };

            // Đường link phim (giống giao diện mẫu của đề)
            var lblLink = new Label
            {
                Left = 92,
                Top = 32,
                Width = w - 210,
                Height = 18,
                AutoEllipsis = true,
                Font = new Font("Tahoma", 8F, FontStyle.Underline),
                ForeColor = Color.LightSkyBlue,
                Text = p.LinkChiTiet,
                Cursor = Cursors.Hand
            };

            // Thể loại, thời lượng, mô tả
            var lblMoTa = new Label
            {
                Left = 92,
                Top = 54,
                Width = w - 210,
                Height = 64,
                AutoEllipsis = true,
                ForeColor = Color.Gainsboro,
                Text = p.MoTa,
                Cursor = Cursors.Hand
            };

            var btnDat = new Button
            {
                Text = "Đặt vé",
                Width = 95,
                Height = 34,
                Left = w - 108,
                Top = 45,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.MediumPurple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDat.Click += (s, e) => DatVe(p);

            // Click vào banner/tên/link/mô tả -> mở trang chi tiết phim
            EventHandler moChiTiet = (s, e) => MoChiTiet(p);
            pb.Click += moChiTiet;
            lblTen.Click += moChiTiet;
            lblLink.Click += moChiTiet;
            lblMoTa.Click += moChiTiet;
            pn.Click += moChiTiet;

            pn.Controls.AddRange(new Control[] { pb, lblTen, lblLink, lblMoTa, btnDat });
            return pn;
        }

        private void MoChiTiet(PhimOnline p)
        {
            if (string.IsNullOrEmpty(p.LinkChiTiet)) return;
            using (var f = new Lab04_Bai04_ChiTietPhim(p.TenPhim, p.LinkChiTiet))
                f.ShowDialog(this);
        }

        private void DatVe(PhimOnline p)
        {
            Hide();
            using (var f = new Lab04_Bai04_BookingForm(p.TenPhim, p.GiaVeChuan, tenKhach))
                f.ShowDialog();
            Show();
        }
    }

    // Hiển thị trang chi tiết phim ngay trong ứng dụng (cần NuGet: Microsoft.Web.WebView2)
    public class Lab04_Bai04_ChiTietPhim : Form
    {
        public Lab04_Bai04_ChiTietPhim(string tenPhim, string url)
        {
            Text = tenPhim;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterParent;

            var web = new Microsoft.Web.WebView2.WinForms.WebView2 { Dock = DockStyle.Fill };
            Controls.Add(web);

            Load += async (s, e) =>
            {
                try
                {
                    await web.EnsureCoreWebView2Async();

                    // Cố gắng ẩn popup chọn tỉnh/rạp của website sau khi trang tải xong
                    web.CoreWebView2.NavigationCompleted += async (sender, args) =>
                    {
                        await web.CoreWebView2.ExecuteScriptAsync(@"
                            (function () {
                                document.querySelectorAll('.modal, .modal-backdrop').forEach(function (el) {
                                    el.style.display = 'none';
                                });
                                document.body.classList.remove('modal-open');
                                document.body.style.overflow = 'auto';
                            })();");
                    };

                    web.CoreWebView2.Navigate(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không mở được trình duyệt nhúng: " + ex.Message +
                        "\nMở bằng trình duyệt mặc định.");
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
                    Close();
                }
            };
        }
    }
}