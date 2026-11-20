using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Lab04_Bai04_BookingForm : Form
    {
        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;
        private Thread listenThread;

        private string tenPhim;
        private decimal giaVeChuan;
        private string tenKhachHang;
        private decimal tongTien = 0;
        private volatile string currentMovieKey = "";
        private volatile bool dangChoPhanHoi = false;

        public Lab04_Bai04_BookingForm(string phim, decimal giaChuan, string khachHang)
        {
            InitializeComponent();

            // Gắn sự kiện chắc chắn cho nút Thanh Toán (tránh gắn trùng)
            btnThanhToan.Click -= btnThanhToan_Click;
            btnThanhToan.Click += btnThanhToan_Click;
            btnThanhToan.Enabled = true;
            btnThanhToan.BringToFront();

            tenPhim = phim;
            giaVeChuan = giaChuan;
            tenKhachHang = khachHang;

            txtTenPhim.Text = tenPhim;
            txtTenKhachHang.Text = tenKhachHang;
            txtTenPhim.ReadOnly = true;
            txtTenKhachHang.ReadOnly = true;
            rtbHoaDon.Visible = false;

            cbPhongChieu.Items.Clear();
            if (tenPhim == "Đào, phở và piano")
            {
                cbPhongChieu.Items.AddRange(new object[] { "Phòng chiếu 1", "Phòng chiếu 2", "Phòng chiếu 3" });
            }
            else if (tenPhim == "Mai")
            {
                cbPhongChieu.Items.AddRange(new object[] { "Phòng chiếu 2", "Phòng chiếu 3" });
            }
            else if (tenPhim == "Gặp lại chị bầu")
            {
                cbPhongChieu.Items.Add("Phòng chiếu 1");
            }
            else if (tenPhim == "Tarot")
            {
                cbPhongChieu.Items.Add("Phòng chiếu 3");
            }
            else
            {
                // Phim lấy từ website
                cbPhongChieu.Items.AddRange(new object[] { "Phòng chiếu 1", "Phòng chiếu 2", "Phòng chiếu 3" });
            }

            if (cbPhongChieu.Items.Count > 0)
                cbPhongChieu.SelectedIndex = 0;

            UpdateCurrentMovieKey();
            this.Load += (s, e) => ConnectToServerAndListen();
        }

        private void UpdateCurrentMovieKey()
        {
            string phong = cbPhongChieu.SelectedItem?.ToString() ?? "Phòng chiếu 1";
            currentMovieKey = $"{tenPhim}_{phong}";
        }

        private string GetCurrentMovieKey() => currentMovieKey;

        private void RunOnUI(Action action)
        {
            if (IsDisposed || !IsHandleCreated) return;
            try { Invoke(action); }
            catch { }
        }

        private void ConnectToServerAndListen()
        {
            for (int attempt = 0; attempt < 10; attempt++)
            {
                try
                {
                    tcpClient = new TcpClient(Lab04_Bai04_Server.ServerIp, Lab04_Bai04_Server.Port);
                    NetworkStream stream = tcpClient.GetStream();
                    UTF8Encoding utf8 = new UTF8Encoding(false);
                    reader = new StreamReader(stream, utf8);
                    writer = new StreamWriter(stream, utf8) { AutoFlush = true };

                    listenThread = new Thread(ListenFromServer);
                    listenThread.IsBackground = true;
                    listenThread.Start();

                    RequestServerSeats();
                    return;
                }
                catch
                {
                    Thread.Sleep(200);
                }
            }

            MessageBox.Show($"Không thể kết nối đến Server {Lab04_Bai04_Server.ServerIp}:{Lab04_Bai04_Server.Port}!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Trả về true nếu gửi được, false nếu chưa kết nối / lỗi
        private bool SendToServer(string message)
        {
            try
            {
                lock (this)
                {
                    if (writer == null || tcpClient == null || !tcpClient.Connected) return false;
                    writer.WriteLine(message);
                    return true;
                }
            }
            catch { return false; }
        }

        private void RequestServerSeats()
        {
            SendToServer($"GET_SEATS|{GetCurrentMovieKey()}");
        }

        private void ListenFromServer()
        {
            try
            {
                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    string[] parts = message.Split('|');
                    string command = parts[0];

                    if (command == "SEATS" || command == "SEAT_UPDATED")
                    {
                        if (parts.Length > 2 && parts[1] == GetCurrentMovieKey())
                        {
                            string seatsStr = parts[2];
                            RunOnUI(() => ApplyBookedSeatsToUI(seatsStr));
                        }
                    }
                    else if (command == "SUCCESS")
                    {
                        dangChoPhanHoi = false;
                        string msg = parts.Length > 1 ? parts[1] : "Đặt vé thành công!";
                        RunOnUI(() =>
                        {
                            HienThiHoaDonThanhCong();
                            GhiDuLieuVaoInput5TrucTiep();   // ghi TRƯỚC khi khóa ghế
                            LockSelectedSeats();
                            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                    else if (command == "FAILED")
                    {
                        dangChoPhanHoi = false;
                        string msg = parts.Length > 1 ? parts[1] : "Ghế đã có người khác đặt!";
                        RunOnUI(() =>
                        {
                            MessageBox.Show(msg, "Cảnh báo tranh chấp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RequestServerSeats();
                        });
                    }
                }
            }
            catch { }
        }

        private void ApplyBookedSeatsToUI(string seatsStr)
        {
            HashSet<string> bookedSeats = new HashSet<string>(
                seatsStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            bool conflict = false;

            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btn)
                {
                    string seatName = btn.Text.Trim();
                    if (bookedSeats.Contains(seatName))
                    {
                        if (btn.BackColor == Color.Green) conflict = true;
                        btn.BackColor = Color.Red;
                        btn.ForeColor = Color.White;
                        btn.Enabled = false;
                    }
                    else if (btn.BackColor != Color.Green)
                    {
                        btn.BackColor = Color.FromKnownColor(KnownColor.Control);
                        btn.ForeColor = Color.Black;
                        btn.Enabled = true;
                    }
                }
            }

            TinhTongTien();

            if (conflict)
            {
                lblTinhTien.ForeColor = Color.Red;
                lblTinhTien.Text = "Ghế bạn chọn vừa có người khác đặt!";
            }
        }

        private void cbPhongChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentMovieKey();

            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btn.ForeColor = Color.Black;
                    btn.Enabled = true;
                }
            }
            tongTien = 0;
            lblTinhTien.ForeColor = Color.White;
            lblTinhTien.Text = "Tổng tiền: 0 VNĐ";
            rtbHoaDon.Visible = false;

            RequestServerSeats();
        }

        private void Ghe_Click(object sender, EventArgs e)
        {
            Button btnGhe = sender as Button;
            if (btnGhe == null || !btnGhe.Enabled) return;

            if (btnGhe.BackColor != Color.Green)
            {
                btnGhe.BackColor = Color.Green;
                btnGhe.ForeColor = Color.White;
            }
            else
            {
                btnGhe.BackColor = Color.FromKnownColor(KnownColor.Control);
                btnGhe.ForeColor = Color.Black;
            }

            TinhTongTien();
        }

        private void TinhTongTien()
        {
            tongTien = 0;
            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == Color.Green)
                {
                    string tenGhe = btn.Text.Trim();
                    if (tenGhe == "A1" || tenGhe == "A5" || tenGhe == "C1" || tenGhe == "C5")
                        tongTien += giaVeChuan * 0.25m;
                    else if (tenGhe == "B2" || tenGhe == "B3" || tenGhe == "B4")
                        tongTien += giaVeChuan * 2.0m;
                    else
                        tongTien += giaVeChuan * 1.0m;
                }
            }
            lblTinhTien.ForeColor = Color.White;
            lblTinhTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (tongTien == 0)
            {
                lblTinhTien.ForeColor = Color.Red;
                lblTinhTien.Text = "Vui lòng chọn ít nhất một ghế ngồi!";
                return;
            }

            List<string> listGheChon = new List<string>();
            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == Color.Green)
                    listGheChon.Add(btn.Text.Trim());
            }

            string lenh = $"BOOK|{GetCurrentMovieKey()}|{string.Join(",", listGheChon)}";

            if (!SendToServer(lenh))
            {
                // Thử kết nối lại 1 lần (tự báo lỗi nếu vẫn không kết nối được)
                try { tcpClient?.Close(); } catch { }
                ConnectToServerAndListen();
                if (!SendToServer(lenh)) return;
            }

            ChoPhanHoi();
        }

        // Nếu sau 3 giây Server không trả lời thì báo cho người dùng biết
        private async void ChoPhanHoi()
        {
            dangChoPhanHoi = true;
            await Task.Delay(3000);
            if (dangChoPhanHoi && !IsDisposed)
            {
                dangChoPhanHoi = false;
                MessageBox.Show(
                    "Server không phản hồi.\nKiểm tra máy chủ đã chạy, cổng 9090 và tường lửa.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HienThiHoaDonThanhCong()
        {
            string phongChieu = cbPhongChieu.SelectedItem.ToString();
            string danhSachGhe = "";
            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == Color.Green)
                    danhSachGhe += btn.Text + " ";
            }

            rtbHoaDon.Visible = true;
            rtbHoaDon.Clear();
            rtbHoaDon.AppendText("        HÓA ĐƠN ĐẶT VÉ XEM PHIM        \n");
            rtbHoaDon.AppendText($" - Khách hàng : {tenKhachHang}\n");
            rtbHoaDon.AppendText($" - Tên phim   : {tenPhim}\n");
            rtbHoaDon.AppendText($" - Phòng chiếu: {phongChieu}\n");
            rtbHoaDon.AppendText($" - Ghế đã chọn: {danhSachGhe}\n");
            rtbHoaDon.AppendText($" - Tổng tiền  : {tongTien:N0} VNĐ\n");
            rtbHoaDon.AppendText("   Cảm ơn quý khách và chúc xem phim vui vẻ!   ");
        }

        private void LockSelectedSeats()
        {
            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == Color.Green)
                {
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.White;
                    btn.Enabled = false;
                }
            }
            tongTien = 0;
            lblTinhTien.ForeColor = Color.White;
            lblTinhTien.Text = "Tổng tiền: 0 VNĐ";
        }

        private void GhiDuLieuVaoInput5TrucTiep()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input5.txt");

                // Số vé vừa đặt = số ghế đang màu xanh
                int soVeMoi = 0;
                foreach (Control ctrl in panelGhe.Controls)
                {
                    if (ctrl is Button btn && btn.BackColor == Color.Green) soVeMoi++;
                }
                if (soVeMoi == 0) soVeMoi = 1;

                string phongChieu = cbPhongChieu.SelectedItem?.ToString() ?? "Phòng chiếu 1";

                // Mỗi phần tử: [tên phim, giá, phòng, tổng vé, đã bán]
                var ds = new List<string[]>();
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    for (int i = 0; i + 4 < lines.Length; i += 5)
                    {
                        ds.Add(new[]
                        {
                            lines[i].Trim(), lines[i + 1].Trim(), lines[i + 2].Trim(),
                            lines[i + 3].Trim(), lines[i + 4].Trim()
                        });
                    }
                }

                // Tìm đúng phim + phòng đang đặt: cộng thêm vé, chưa có thì thêm dòng mới
                string[] dong = ds.Find(d => d[0] == tenPhim && d[2] == phongChieu);
                if (dong != null)
                {
                    int.TryParse(dong[4], out int daBan);
                    dong[4] = (daBan + soVeMoi).ToString();
                }
                else
                {
                    ds.Add(new[]
                    {
                        tenPhim, giaVeChuan.ToString("0"), phongChieu, "15", soVeMoi.ToString()
                    });
                }

                using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(false)))
                {
                    foreach (var d in ds)
                    {
                        sw.WriteLine(d[0]);
                        sw.WriteLine(d[1]);
                        sw.WriteLine(d[2]);
                        sw.WriteLine(d[3]);
                        sw.WriteLine(d[4]);
                    }
                }
            }
            catch { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            rtbHoaDon.Visible = false;
            foreach (Control ctrl in panelGhe.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == Color.Green)
                {
                    btn.BackColor = Color.FromKnownColor(KnownColor.Control);
                    btn.ForeColor = Color.Black;
                }
            }
            tongTien = 0;
            lblTinhTien.ForeColor = Color.White;
            lblTinhTien.Text = "Tổng tiền: 0 VNĐ";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { tcpClient?.Close(); } catch { }
            base.OnFormClosing(e);
        }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();
        private void btnMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void btnMaximize_Click(object sender, EventArgs e) => this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }
    }
}