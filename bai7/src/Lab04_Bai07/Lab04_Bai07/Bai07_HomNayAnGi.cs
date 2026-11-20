using Lab04_Bai07;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_Bai07
{
    public partial class HomNayAnGi : Form
    {
        private const int DefaultPageSize = 5;

        private bool isUpdatingPagination = false;
        private bool _isLoadingTab = false;

        // Timer đồng bộ tự động mỗi 2 giây khi có Client/Server thêm hoặc xoá món
        private readonly System.Windows.Forms.Timer _syncTimer = new System.Windows.Forms.Timer();
        private string _lastKnownVersion = "";

        public HomNayAnGi()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureFlowLayout(flpAll);
            ConfigureFlowLayout(flpMine);

            isUpdatingPagination = true;
            if (cboPage.Items.Count == 0)
            {
                cboPage.Items.Add(1);
            }
            if (cboPage.SelectedIndex < 0 && cboPage.Items.Count > 0)
            {
                cboPage.SelectedIndex = 0;
            }
            isUpdatingPagination = false;

            cboPage.SelectedIndexChanged -= cboPage_SelectedIndexChanged;
            cboPage.SelectedIndexChanged += cboPage_SelectedIndexChanged;

            this.Load += HomNayAnGi_Load;
            this.FormClosed += (s, e) =>
            {
                _syncTimer.Stop();
                EmbeddedApiServer.UserLoggedIn -= OnServerUserLoggedIn;
            };
        }

        private void OnServerUserLoggedIn(string logMsg)
        {
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(
                        this,
                        logMsg,
                        "Thông báo đăng nhập từ Client",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }));
            }
        }

        private void ConfigureFlowLayout(FlowLayoutPanel flp)
        {
            flp.FlowDirection = FlowDirection.TopDown;
            flp.WrapContents = false;
            flp.AutoScroll = true;
            flp.Padding = new Padding(4);
            flp.SizeChanged += (s, e) => ResizeCardsInFlowLayout(flp);
        }

        private void ResizeCardsInFlowLayout(FlowLayoutPanel flp)
        {
            int targetWidth = Math.Max(220, flp.ClientSize.Width - 26);

            foreach (Control ctrl in flp.Controls)
            {
                if (ctrl is MonAnCard card)
                {
                    double ratio = 0.36;
                    card.Width = targetWidth;
                    card.Height = Math.Max(135, (int)Math.Round(targetWidth * ratio));
                    card.Margin = new Padding(0, 0, 0, 10);
                }
            }
        }

        private TabControl? GetParentTabControl()
        {
            return flpAll.Parent?.Parent as TabControl ?? flpMine.Parent?.Parent as TabControl;
        }

        private bool IsMineTabSelected()
        {
            var tab = GetParentTabControl();
            if (tab != null)
            {
                return tab.SelectedTab?.Controls.Contains(flpMine) == true || tab.SelectedIndex == 1;
            }
            return false;
        }

        private async void HomNayAnGi_Load(object? sender, EventArgs e)
        {
            if (EmbeddedApiServer.IsHostingLocally)
            {
                ApiClient.SetBaseUrl("http://localhost:8080/");
                EmbeddedApiServer.UserLoggedIn -= OnServerUserLoggedIn;
                EmbeddedApiServer.UserLoggedIn += OnServerUserLoggedIn;
            }
            else
            {
                await ApiClient.LoadServerUrlFromGitHubAsync();
            }

            var tab = GetParentTabControl();
            if (tab != null)
            {
                tab.SelectedIndexChanged += async (s, args) =>
                {
                    isUpdatingPagination = true;
                    if (cboPage.Items.Count > 0) cboPage.SelectedIndex = 0;
                    isUpdatingPagination = false;
                    await LoadCurrentTabAsync();
                };
            }

            UpdateAuthUI();
            await LoadCurrentTabAsync();
            StartRealtimeSync();
        }

        private void StartRealtimeSync()
        {
            _syncTimer.Interval = 2000; // Kiểm tra thay đổi mỗi 2 giây
            _syncTimer.Tick += async (s, e) =>
            {
                if (_isLoadingTab) return;

                try
                {
                    if (EmbeddedApiServer.IsHostingLocally)
                    {
                        string currentVer = EmbeddedApiServer.DataVersion.ToString();
                        if (_lastKnownVersion != currentVer)
                        {
                            bool isFirst = string.IsNullOrEmpty(_lastKnownVersion);
                            _lastKnownVersion = currentVer;
                            if (!isFirst)
                            {
                                await LoadCurrentTabAsync();
                            }
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(ApiClient.BaseUrl))
                    {
                        using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(4) };
                        http.DefaultRequestHeaders.Add("ngrok-skip-browser-warning", "true");
                        string verJson = await http.GetStringAsync($"{ApiClient.BaseUrl.TrimEnd('/')}/api/version");
                        if (_lastKnownVersion != verJson)
                        {
                            bool isFirst = string.IsNullOrEmpty(_lastKnownVersion);
                            _lastKnownVersion = verJson;
                            if (!isFirst)
                            {
                                await LoadCurrentTabAsync();
                            }
                        }
                    }
                }
                catch
                {
                    // Bỏ qua nếu mạng chập chờn ở nhịp kiểm tra hiện tại
                }
            };
            _syncTimer.Start();
        }

        private void UpdateAuthUI()
        {
            if (ApiClient.IsLoggedIn)
            {
                lblAuthStatus.Text = $"Welcome, {ApiClient.CurrentFirstname}";
                lblAuthStatus.ForeColor = Color.SeaGreen;
                lnkAuthAction.Text = "Logout";
            }
            else
            {
                lblAuthStatus.Text = "Unauthenticated";
                lblAuthStatus.ForeColor = Color.Crimson;
                lnkAuthAction.Text = "Login";
            }
        }

        private void SetLoadingState(bool loading)
        {
            progressBar.Visible = loading;
            progressBar.Style = loading ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            btnAnGiGio.Enabled = !loading;
            btnThemMonAn.Enabled = !loading;
        }

        private async Task LoadCurrentTabAsync()
        {
            if (_isLoadingTab) return;
            _isLoadingTab = true;

            bool onlyMine = IsMineTabSelected();
            FlowLayoutPanel targetPanel = onlyMine ? flpMine : flpAll;

            try
            {
                if (onlyMine && !ApiClient.IsLoggedIn)
                {
                    targetPanel.Controls.Clear();
                    targetPanel.Controls.Add(new Label
                    {
                        Text = "Vui lòng đăng nhập để xem các món ăn bạn đã đóng góp.",
                        AutoSize = true,
                        Padding = new Padding(12),
                        ForeColor = Color.DimGray,
                        BackColor = Color.Transparent
                    });
                    return;
                }

                int page = cboPage.SelectedItem is int p ? p : (int.TryParse(cboPage.Text, out int parsedP) ? parsedP : 1);

                SetLoadingState(true);
                var res = await ApiClient.GetMonAnAsync(onlyMine, page, DefaultPageSize);

                isUpdatingPagination = true;
                int totalPages = Math.Max(1, res.TotalPages);
                cboPage.Items.Clear();
                for (int i = 1; i <= totalPages; i++)
                {
                    cboPage.Items.Add(i);
                }
                cboPage.SelectedItem = page <= totalPages ? page : 1;
                isUpdatingPagination = false;

                targetPanel.SuspendLayout();
                targetPanel.Controls.Clear();

                foreach (var mon in res.Data)
                {
                    MonAnCard card = new MonAnCard();
                    card.SetData(mon, allowDelete: ApiClient.IsLoggedIn);
                    card.DeleteClicked += async (s, monId) =>
                    {
                        var confirm = MessageBox.Show(
                            $"Bạn có chắc muốn xoá món '{mon.TenMonAn}' không?",
                            "Xác nhận",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (confirm == DialogResult.Yes)
                        {
                            var (ok, msg) = await ApiClient.DeleteMonAnAsync(monId);
                            if (ok)
                            {
                                await LoadCurrentTabAsync();
                            }
                            else
                            {
                                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };
                    targetPanel.Controls.Add(card);
                }

                ResizeCardsInFlowLayout(targetPanel);
                targetPanel.ResumeLayout();
            }
            catch (Exception ex)
            {
                targetPanel.Controls.Clear();
                targetPanel.Controls.Add(new Label
                {
                    Text = $"Chưa kết nối được API Server ({ApiClient.BaseUrl.TrimEnd('/')}).\nChi tiết: " + ex.Message,
                    AutoSize = true,
                    Padding = new Padding(12),
                    ForeColor = Color.Firebrick,
                    BackColor = Color.Transparent
                });
            }
            finally
            {
                SetLoadingState(false);
                _isLoadingTab = false;
            }
        }

        private async void btnAnGiGio_Click(object sender, EventArgs e)
        {
            bool onlyMine = IsMineTabSelected();
            if (onlyMine && !ApiClient.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập để chọn ngẫu nhiên trong danh sách đóng góp của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetLoadingState(true);
            try
            {
                var (mon, err) = await ApiClient.GetRandomMonAnAsync(onlyMine);
                if (mon != null)
                {
                    using var frmRandom = new RandomMonAn(mon);
                    frmRandom.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được tới API Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private async void btnThemMonAn_Click(object sender, EventArgs e)
        {
            if (!ApiClient.IsLoggedIn)
            {
                MessageBox.Show("Bạn cần đăng nhập trước khi thêm món ăn!", "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using var frmLogin = new LoginForm();
                if (frmLogin.ShowDialog(this) != DialogResult.OK) return;
                UpdateAuthUI();
            }

            using var frmThem = new ThemMonAn();
            if (frmThem.ShowDialog(this) == DialogResult.OK)
            {
                await LoadCurrentTabAsync();
            }
        }

        private async void lnkAuthAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ApiClient.IsLoggedIn)
            {
                ApiClient.Logout();
                UpdateAuthUI();
                flpMine.Controls.Clear();

                var tab = GetParentTabControl();
                if (tab != null) tab.SelectedIndex = 0;

                await LoadCurrentTabAsync();
            }
            else
            {
                using var frmLogin = new LoginForm();
                if (frmLogin.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateAuthUI();
                    await LoadCurrentTabAsync();
                }
            }
        }

        private async void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isUpdatingPagination)
            {
                await LoadCurrentTabAsync();
            }
        }

        private void lblHomNayAnGi_Click(object sender, EventArgs e) { }
        private void flpMine_Paint(object sender, PaintEventArgs e) { }
        private void flpAll_Paint(object sender, PaintEventArgs e) { }
        private void lblAuthStatus_Click(object sender, EventArgs e) { }
        private void progressBar_Click(object sender, EventArgs e) { }
        private void lblPage_Click(object sender, EventArgs e) { }
        private void HomNayAnGi_Load_1(object sender, EventArgs e) { }
    }
}