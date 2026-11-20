namespace Lab04_Bai07
{
    partial class ThemMonAn
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemMonAn));
            lblThemMonAn = new Label();
            lblTenMonAn = new Label();
            lblGia = new Label();
            lblHinhAnh = new Label();
            lblMoTa = new Label();
            txtTenMonAn = new TextBox();
            txtGia = new TextBox();
            txtHinhAnh = new TextBox();
            richTxtMoTa = new RichTextBox();
            btnLinkAnh = new Button();
            SuspendLayout();
            // 
            // lblThemMonAn
            // 
            lblThemMonAn.AutoSize = true;
            lblThemMonAn.BackColor = Color.Transparent;
            lblThemMonAn.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblThemMonAn.ForeColor = Color.SaddleBrown;
            lblThemMonAn.Location = new Point(180, 38);
            lblThemMonAn.Margin = new Padding(4, 0, 4, 0);
            lblThemMonAn.Name = "lblThemMonAn";
            lblThemMonAn.Size = new Size(152, 22);
            lblThemMonAn.TabIndex = 0;
            lblThemMonAn.Text = "THÊM MÓN ĂN";
            lblThemMonAn.Click += lblThemMonAn_Click;
            // 
            // lblTenMonAn
            // 
            lblTenMonAn.AutoSize = true;
            lblTenMonAn.BackColor = Color.Transparent;
            lblTenMonAn.Font = new Font("Times New Roman", 12F);
            lblTenMonAn.ForeColor = Color.SaddleBrown;
            lblTenMonAn.Location = new Point(65, 76);
            lblTenMonAn.Margin = new Padding(4, 0, 4, 0);
            lblTenMonAn.Name = "lblTenMonAn";
            lblTenMonAn.Size = new Size(87, 19);
            lblTenMonAn.TabIndex = 1;
            lblTenMonAn.Text = "Tên món ăn: ";
            lblTenMonAn.Click += lblTenMonAn_Click;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.BackColor = Color.Transparent;
            lblGia.Font = new Font("Times New Roman", 12F);
            lblGia.ForeColor = Color.SaddleBrown;
            lblGia.Location = new Point(65, 108);
            lblGia.Margin = new Padding(4, 0, 4, 0);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(33, 19);
            lblGia.TabIndex = 2;
            lblGia.Text = "Giá:";
            lblGia.Click += lblGia_Click;
            // 
            // lblHinhAnh
            // 
            lblHinhAnh.AutoSize = true;
            lblHinhAnh.BackColor = Color.Transparent;
            lblHinhAnh.Font = new Font("Times New Roman", 12F);
            lblHinhAnh.ForeColor = Color.SaddleBrown;
            lblHinhAnh.Location = new Point(65, 142);
            lblHinhAnh.Margin = new Padding(4, 0, 4, 0);
            lblHinhAnh.Name = "lblHinhAnh";
            lblHinhAnh.Size = new Size(65, 19);
            lblHinhAnh.TabIndex = 3;
            lblHinhAnh.Text = "Hình ảnh:";
            lblHinhAnh.Click += lblHinhAnh_Click;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.BackColor = Color.Transparent;
            lblMoTa.Font = new Font("Times New Roman", 12F);
            lblMoTa.ForeColor = Color.Sienna;
            lblMoTa.Location = new Point(65, 173);
            lblMoTa.Margin = new Padding(4, 0, 4, 0);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(49, 19);
            lblMoTa.TabIndex = 4;
            lblMoTa.Text = "Mô tả:";
            lblMoTa.Click += lblMoTa_Click;
            // 
            // txtTenMonAn
            // 
            txtTenMonAn.Location = new Point(159, 73);
            txtTenMonAn.Name = "txtTenMonAn";
            txtTenMonAn.Size = new Size(282, 26);
            txtTenMonAn.TabIndex = 5;
            txtTenMonAn.TextChanged += txtTenMonAn_TextChanged;
            // 
            // txtGia
            // 
            txtGia.Location = new Point(159, 105);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(282, 26);
            txtGia.TabIndex = 6;
            txtGia.TextChanged += txtGia_TextChanged;
            // 
            // txtHinhAnh
            // 
            txtHinhAnh.Location = new Point(159, 138);
            txtHinhAnh.Name = "txtHinhAnh";
            txtHinhAnh.Size = new Size(241, 26);
            txtHinhAnh.TabIndex = 7;
            txtHinhAnh.TextChanged += txtHinhAnh_TextChanged;
            // 
            // richTxtMoTa
            // 
            richTxtMoTa.Location = new Point(158, 170);
            richTxtMoTa.Name = "richTxtMoTa";
            richTxtMoTa.Size = new Size(283, 106);
            richTxtMoTa.TabIndex = 8;
            richTxtMoTa.Text = "";
            richTxtMoTa.TextChanged += richTxtMoTa_TextChanged;
            // 
            // btnLinkAnh
            // 
            btnLinkAnh.BackColor = Color.DarkSeaGreen;
            btnLinkAnh.FlatAppearance.BorderSize = 0;
            btnLinkAnh.FlatStyle = FlatStyle.Flat;
            btnLinkAnh.Location = new Point(406, 138);
            btnLinkAnh.Name = "btnLinkAnh";
            btnLinkAnh.Size = new Size(35, 26);
            btnLinkAnh.TabIndex = 9;
            btnLinkAnh.Text = "...";
            btnLinkAnh.UseVisualStyleBackColor = false;
            btnLinkAnh.Click += btnLinkAnh_Click;
            // 
            // ThemMonAn
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(621, 382);
            Controls.Add(btnLinkAnh);
            Controls.Add(richTxtMoTa);
            Controls.Add(txtHinhAnh);
            Controls.Add(txtGia);
            Controls.Add(txtTenMonAn);
            Controls.Add(lblMoTa);
            Controls.Add(lblHinhAnh);
            Controls.Add(lblGia);
            Controls.Add(lblTenMonAn);
            Controls.Add(lblThemMonAn);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "ThemMonAn";
            Text = "ThemMonAn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblThemMonAn;
        private Label lblTenMonAn;
        private Label lblGia;
        private Label lblHinhAnh;
        private Label lblMoTa;
        private TextBox txtTenMonAn;
        private TextBox txtGia;
        private TextBox txtHinhAnh;
        private RichTextBox richTxtMoTa;
        private Button btnLinkAnh;
    }
}