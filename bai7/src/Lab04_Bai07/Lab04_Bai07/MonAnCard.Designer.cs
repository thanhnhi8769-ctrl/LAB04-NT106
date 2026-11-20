namespace Lab04_Bai07
{
    partial class MonAnCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonAnCard));
            lblTenMon = new Label();
            lblGia = new Label();
            lblDongGop = new Label();
            txtGia = new Label();
            txtDongGop = new Label();
            picAnhMonAn = new PictureBox();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)picAnhMonAn).BeginInit();
            SuspendLayout();
            // 
            // lblTenMon
            // 
            lblTenMon.Anchor = AnchorStyles.None;
            lblTenMon.BackColor = Color.Transparent;
            lblTenMon.Font = new Font("Times New Roman", 13F);
            lblTenMon.ForeColor = Color.Maroon;
            lblTenMon.Location = new Point(335, 67);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(217, 28);
            lblTenMon.TabIndex = 0;
            lblTenMon.Click += lblTenMon_Click;
            // 
            // lblGia
            // 
            lblGia.Anchor = AnchorStyles.None;
            lblGia.AutoSize = true;
            lblGia.BackColor = Color.Transparent;
            lblGia.Font = new Font("Times New Roman", 10F);
            lblGia.ForeColor = Color.SaddleBrown;
            lblGia.Location = new Point(335, 95);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(26, 16);
            lblGia.TabIndex = 1;
            lblGia.Text = "Giá";
            lblGia.Click += lblGia_Click;
            // 
            // lblDongGop
            // 
            lblDongGop.Anchor = AnchorStyles.None;
            lblDongGop.AutoSize = true;
            lblDongGop.BackColor = Color.Transparent;
            lblDongGop.Font = new Font("Times New Roman", 10F);
            lblDongGop.ForeColor = Color.SaddleBrown;
            lblDongGop.Location = new Point(335, 114);
            lblDongGop.Name = "lblDongGop";
            lblDongGop.Size = new Size(84, 16);
            lblDongGop.TabIndex = 2;
            lblDongGop.Text = "Đóng góp bởi";
            lblDongGop.Click += lblDongGop_Click;
            // 
            // txtGia
            // 
            txtGia.Anchor = AnchorStyles.None;
            txtGia.BackColor = Color.Transparent;
            txtGia.Font = new Font("Times New Roman", 10F);
            txtGia.Location = new Point(367, 96);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(177, 15);
            txtGia.TabIndex = 3;
            txtGia.Click += txtGia_Click;
            // 
            // txtDongGop
            // 
            txtDongGop.Anchor = AnchorStyles.None;
            txtDongGop.AutoSize = true;
            txtDongGop.BackColor = Color.Transparent;
            txtDongGop.Font = new Font("Times New Roman", 10F);
            txtDongGop.Location = new Point(425, 111);
            txtDongGop.Name = "txtDongGop";
            txtDongGop.Size = new Size(0, 16);
            txtDongGop.TabIndex = 4;
            txtDongGop.Click += txtDongGop_Click;
            // 
            // picAnhMonAn
            // 
            picAnhMonAn.Anchor = AnchorStyles.None;
            picAnhMonAn.BackColor = Color.Transparent;
            picAnhMonAn.Location = new Point(220, 67);
            picAnhMonAn.Name = "picAnhMonAn";
            picAnhMonAn.Size = new Size(100, 66);
            picAnhMonAn.SizeMode = PictureBoxSizeMode.StretchImage;
            picAnhMonAn.TabIndex = 5;
            picAnhMonAn.TabStop = false;
            picAnhMonAn.Click += picAnhMonAn_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.None;
            btnXoa.BackColor = Color.Bisque;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.DarkRed;
            btnXoa.Location = new Point(611, 69);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 64);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // MonAnCard
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnXoa);
            Controls.Add(picAnhMonAn);
            Controls.Add(txtDongGop);
            Controls.Add(txtGia);
            Controls.Add(lblDongGop);
            Controls.Add(lblGia);
            Controls.Add(lblTenMon);
            DoubleBuffered = true;
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4);
            Name = "MonAnCard";
            Size = new Size(766, 190);
            Load += MonAnCard_Load;
            ((System.ComponentModel.ISupportInitialize)picAnhMonAn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenMon;
        private Label lblGia;
        private Label lblDongGop;
        private Label txtGia;
        private Label txtDongGop;
        private PictureBox picAnhMonAn;
        private Button btnXoa;
    }
}
