namespace Bai02
{
    partial class Bai02Form
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
            lblTaiTrangWeb = new Label();
            label1 = new Label();
            lblDiaChi = new Label();
            txtURL = new TextBox();
            lblFilePath = new Label();
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            lblTrangThai = new Label();
            btnDownload = new Button();
            btnThoat = new Button();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // lblTaiTrangWeb
            // 
            lblTaiTrangWeb.AutoSize = true;
            lblTaiTrangWeb.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTaiTrangWeb.ForeColor = Color.SteelBlue;
            lblTaiTrangWeb.Location = new Point(160, 40);
            lblTaiTrangWeb.Name = "lblTaiTrangWeb";
            lblTaiTrangWeb.Size = new Size(271, 45);
            lblTaiTrangWeb.TabIndex = 0;
            lblTaiTrangWeb.Text = "TẢI TRANG WEB";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.WindowFrame;
            label1.Location = new Point(140, 90);
            label1.Name = "label1";
            label1.Size = new Size(300, 20);
            label1.TabIndex = 1;
            label1.Text = "Hệ thống tải dữ liệu từ Internet • NT106.R14";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDiaChi.Location = new Point(80, 150);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(91, 20);
            lblDiaChi.TabIndex = 2;
            lblDiaChi.Text = "Địa chỉ URL:";
            // 
            // txtURL
            // 
            txtURL.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtURL.ForeColor = SystemColors.WindowFrame;
            txtURL.Location = new Point(80, 180);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(400, 27);
            txtURL.TabIndex = 3;
            txtURL.Text = "http://uit.edu.vn";
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFilePath.Location = new Point(80, 240);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(84, 20);
            lblFilePath.TabIndex = 4;
            lblFilePath.Text = "Lưu file tại:";
            // 
            // txtFilePath
            // 
            txtFilePath.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFilePath.ForeColor = SystemColors.WindowFrame;
            txtFilePath.Location = new Point(80, 270);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(250, 27);
            txtFilePath.TabIndex = 5;
            txtFilePath.Text = "http://uit.edu.vn";
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(51, 122, 183);
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnBrowse.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(340, 270);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(140, 27);
            btnBrowse.TabIndex = 21;
            btnBrowse.Text = "Chọn...";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTrangThai.ForeColor = SystemColors.WindowFrame;
            lblTrangThai.Location = new Point(80, 320);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(138, 20);
            lblTrangThai.TabIndex = 22;
            lblTrangThai.Text = "Trạng thái: Chưa tải";
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.FromArgb(51, 122, 183);
            btnDownload.Cursor = Cursors.Hand;
            btnDownload.FlatAppearance.BorderSize = 0;
            btnDownload.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 96, 145);
            btnDownload.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 138, 204);
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(80, 370);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(150, 40);
            btnDownload.TabIndex = 23;
            btnDownload.Text = "Tải xuống";
            btnDownload.UseVisualStyleBackColor = false;
            btnDownload.Click += btnDownload_Click;
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
            btnThoat.Location = new Point(330, 370);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(150, 40);
            btnThoat.TabIndex = 24;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // rtbContent
            // 
            rtbContent.BackColor = Color.White;
            rtbContent.BorderStyle = BorderStyle.FixedSingle;
            rtbContent.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbContent.Location = new Point(80, 450);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new Size(400, 160);
            rtbContent.TabIndex = 25;
            rtbContent.Text = "";
            // 
            // Bai02
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 661);
            Controls.Add(rtbContent);
            Controls.Add(btnThoat);
            Controls.Add(btnDownload);
            Controls.Add(lblTrangThai);
            Controls.Add(btnBrowse);
            Controls.Add(txtFilePath);
            Controls.Add(lblFilePath);
            Controls.Add(txtURL);
            Controls.Add(lblDiaChi);
            Controls.Add(label1);
            Controls.Add(lblTaiTrangWeb);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Bai02";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 2 - Tải trang web";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaiTrangWeb;
        private Label label1;
        private Label lblDiaChi;
        private TextBox txtURL;
        private Label lblFilePath;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private Label lblTrangThai;
        private Button btnDownload;
        private Button btnThoat;
        private RichTextBox rtbContent;
    }
}
