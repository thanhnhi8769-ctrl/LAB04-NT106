namespace Bai03
{
    partial class Bai03Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTrinhDuyetWeb = new Label();
            lblHeThongDuyetWeb = new Label();
            lblDiaChi = new Label();
            txtURL = new TextBox();
            btnLoad = new Button();
            btnDownloadResources = new Button();
            btnDownloadFiles = new Button();
            btnViewSource = new Button();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // lblTrinhDuyetWeb
            // 
            lblTrinhDuyetWeb.AutoSize = true;
            lblTrinhDuyetWeb.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrinhDuyetWeb.ForeColor = Color.SteelBlue;
            lblTrinhDuyetWeb.Location = new Point(230, 40);
            lblTrinhDuyetWeb.Name = "lblTrinhDuyetWeb";
            lblTrinhDuyetWeb.Size = new Size(442, 45);
            lblTrinhDuyetWeb.TabIndex = 1;
            lblTrinhDuyetWeb.Text = "TRÌNH DUYỆT WEB CƠ BẢN";
            // 
            // lblHeThongDuyetWeb
            // 
            lblHeThongDuyetWeb.AutoSize = true;
            lblHeThongDuyetWeb.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHeThongDuyetWeb.ForeColor = SystemColors.WindowFrame;
            lblHeThongDuyetWeb.Location = new Point(330, 90);
            lblHeThongDuyetWeb.Name = "lblHeThongDuyetWeb";
            lblHeThongDuyetWeb.Size = new Size(229, 20);
            lblHeThongDuyetWeb.TabIndex = 2;
            lblHeThongDuyetWeb.Text = "Hệ thống duyệt web • NT106.R14";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiaChi.Location = new Point(80, 150);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(120, 20);
            lblDiaChi.TabIndex = 3;
            lblDiaChi.Text = "Địa chỉ truy cập:";
            // 
            // txtURL
            // 
            txtURL.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtURL.ForeColor = SystemColors.WindowFrame;
            txtURL.Location = new Point(80, 180);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(690, 27);
            txtURL.TabIndex = 4;
            txtURL.Text = "http://uit.edu.vn";
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(51, 122, 183);
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnLoad.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(80, 240);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(150, 40);
            btnLoad.TabIndex = 24;
            btnLoad.Text = "Tải trang (Load)";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDownloadResources
            // 
            btnDownloadResources.BackColor = Color.FromArgb(51, 122, 183);
            btnDownloadResources.Cursor = Cursors.Hand;
            btnDownloadResources.FlatAppearance.BorderSize = 0;
            btnDownloadResources.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnDownloadResources.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnDownloadResources.FlatStyle = FlatStyle.Flat;
            btnDownloadResources.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnDownloadResources.ForeColor = Color.White;
            btnDownloadResources.Location = new Point(440, 240);
            btnDownloadResources.Name = "btnDownloadResources";
            btnDownloadResources.Size = new Size(150, 40);
            btnDownloadResources.TabIndex = 25;
            btnDownloadResources.Text = "Tải Ảnh";
            btnDownloadResources.UseVisualStyleBackColor = false;
            btnDownloadResources.Click += btnDownloadResources_Click;
            // 
            // btnDownloadFiles
            // 
            btnDownloadFiles.BackColor = Color.FromArgb(51, 122, 183);
            btnDownloadFiles.Cursor = Cursors.Hand;
            btnDownloadFiles.FlatAppearance.BorderSize = 0;
            btnDownloadFiles.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnDownloadFiles.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnDownloadFiles.FlatStyle = FlatStyle.Flat;
            btnDownloadFiles.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnDownloadFiles.ForeColor = Color.White;
            btnDownloadFiles.Location = new Point(260, 240);
            btnDownloadFiles.Name = "btnDownloadFiles";
            btnDownloadFiles.Size = new Size(150, 40);
            btnDownloadFiles.TabIndex = 26;
            btnDownloadFiles.Text = "Tải HTML";
            btnDownloadFiles.UseVisualStyleBackColor = false;
            btnDownloadFiles.Click += btnDownloadFiles_Click;
            // 
            // btnViewSource
            // 
            btnViewSource.BackColor = Color.FromArgb(51, 122, 183);
            btnViewSource.Cursor = Cursors.Hand;
            btnViewSource.FlatAppearance.BorderSize = 0;
            btnViewSource.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnViewSource.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnViewSource.FlatStyle = FlatStyle.Flat;
            btnViewSource.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnViewSource.ForeColor = Color.White;
            btnViewSource.Location = new Point(620, 240);
            btnViewSource.Name = "btnViewSource";
            btnViewSource.Size = new Size(150, 40);
            btnViewSource.TabIndex = 27;
            btnViewSource.Text = "Xem Code";
            btnViewSource.UseVisualStyleBackColor = false;
            btnViewSource.Click += btnViewSource_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.BackgroundImageLayout = ImageLayout.Center;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(80, 320);
            webView21.Name = "webView21";
            webView21.Size = new Size(690, 440);
            webView21.TabIndex = 28;
            webView21.ZoomFactor = 1D;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.White;
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnThoat.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 225, 225);
            btnThoat.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 10.5F);
            btnThoat.ForeColor = Color.FromArgb(64, 64, 64);
            btnThoat.Location = new Point(620, 790);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 40);
            btnThoat.TabIndex = 29;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // Bai03Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(864, 861);
            Controls.Add(btnThoat);
            Controls.Add(webView21);
            Controls.Add(btnViewSource);
            Controls.Add(btnDownloadFiles);
            Controls.Add(btnDownloadResources);
            Controls.Add(btnLoad);
            Controls.Add(txtURL);
            Controls.Add(lblDiaChi);
            Controls.Add(lblHeThongDuyetWeb);
            Controls.Add(lblTrinhDuyetWeb);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Bai03Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 3 - Web Browser cơ bản ";
            Load += Bai03Form_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTrinhDuyetWeb;
        private Label lblHeThongDuyetWeb;
        private Label lblDiaChi;
        private TextBox txtURL;
        private Button btnLoad;
        private Button btnDownloadResources;
        private Button btnDownloadFiles;
        private Button btnViewSource;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button btnThoat;
    }
}
