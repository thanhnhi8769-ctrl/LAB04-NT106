namespace Lab04_Bai07
{
    partial class HomNayAnGi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomNayAnGi));
            lblHomNayAnGi = new Label();
            btnAnGiGio = new Button();
            btnThemMonAn = new Button();
            tabControl = new TabControl();
            tabAll = new TabPage();
            flpAll = new FlowLayoutPanel();
            tabToiDongGop = new TabPage();
            flpMine = new FlowLayoutPanel();
            lblPage = new Label();
            lblPageSize = new Label();
            cboPageSize = new ComboBox();
            cboPage = new ComboBox();
            lblAuthStatus = new Label();
            lnkAuthAction = new LinkLabel();
            progressBar = new ProgressBar();
            tabControl.SuspendLayout();
            tabAll.SuspendLayout();
            tabToiDongGop.SuspendLayout();
            SuspendLayout();
            // 
            // lblHomNayAnGi
            // 
            lblHomNayAnGi.AutoSize = true;
            lblHomNayAnGi.BackColor = Color.Transparent;
            lblHomNayAnGi.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lblHomNayAnGi.ForeColor = Color.Sienna;
            lblHomNayAnGi.Location = new Point(130, 135);
            lblHomNayAnGi.Name = "lblHomNayAnGi";
            lblHomNayAnGi.Size = new Size(195, 25);
            lblHomNayAnGi.TabIndex = 0;
            lblHomNayAnGi.Text = "HÔM NAY ĂN GÌ?";
            lblHomNayAnGi.Click += lblHomNayAnGi_Click;
            // 
            // btnAnGiGio
            // 
            btnAnGiGio.BackColor = Color.Tan;
            btnAnGiGio.Cursor = Cursors.Hand;
            btnAnGiGio.FlatAppearance.BorderColor = Color.FromArgb(128, 64, 0);
            btnAnGiGio.FlatStyle = FlatStyle.Flat;
            btnAnGiGio.ForeColor = Color.LightYellow;
            btnAnGiGio.Location = new Point(331, 130);
            btnAnGiGio.Name = "btnAnGiGio";
            btnAnGiGio.Size = new Size(112, 36);
            btnAnGiGio.TabIndex = 1;
            btnAnGiGio.Text = "Ăn gì giờ?";
            btnAnGiGio.UseVisualStyleBackColor = false;
            btnAnGiGio.Click += btnAnGiGio_Click;
            // 
            // btnThemMonAn
            // 
            btnThemMonAn.BackColor = Color.PaleGoldenrod;
            btnThemMonAn.Cursor = Cursors.Hand;
            btnThemMonAn.FlatStyle = FlatStyle.Flat;
            btnThemMonAn.ForeColor = Color.Maroon;
            btnThemMonAn.Location = new Point(449, 130);
            btnThemMonAn.Name = "btnThemMonAn";
            btnThemMonAn.Size = new Size(112, 36);
            btnThemMonAn.TabIndex = 2;
            btnThemMonAn.Text = "Thêm món ăn";
            btnThemMonAn.UseVisualStyleBackColor = false;
            btnThemMonAn.Click += btnThemMonAn_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabAll);
            tabControl.Controls.Add(tabToiDongGop);
            tabControl.Location = new Point(91, 172);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(497, 455);
            tabControl.TabIndex = 3;
            // 
            // tabAll
            // 
            tabAll.AutoScroll = true;
            tabAll.Controls.Add(flpAll);
            tabAll.Location = new Point(4, 28);
            tabAll.Name = "tabAll";
            tabAll.Padding = new Padding(3);
            tabAll.Size = new Size(489, 423);
            tabAll.TabIndex = 0;
            tabAll.Text = "All";
            tabAll.UseVisualStyleBackColor = true;
            // 
            // flpAll
            // 
            flpAll.AutoScroll = true;
            flpAll.BackColor = Color.White;
            flpAll.Dock = DockStyle.Fill;
            flpAll.FlowDirection = FlowDirection.TopDown;
            flpAll.Location = new Point(3, 3);
            flpAll.Name = "flpAll";
            flpAll.Size = new Size(483, 417);
            flpAll.TabIndex = 1;
            flpAll.WrapContents = false;
            flpAll.Paint += flpAll_Paint;
            // 
            // tabToiDongGop
            // 
            tabToiDongGop.AutoScroll = true;
            tabToiDongGop.Controls.Add(flpMine);
            tabToiDongGop.Location = new Point(4, 24);
            tabToiDongGop.Name = "tabToiDongGop";
            tabToiDongGop.Padding = new Padding(3);
            tabToiDongGop.Size = new Size(489, 427);
            tabToiDongGop.TabIndex = 1;
            tabToiDongGop.Text = "Tôi đóng góp";
            tabToiDongGop.UseVisualStyleBackColor = true;
            // 
            // flpMine
            // 
            flpMine.AutoScroll = true;
            flpMine.BackColor = Color.White;
            flpMine.Dock = DockStyle.Fill;
            flpMine.FlowDirection = FlowDirection.TopDown;
            flpMine.Location = new Point(3, 3);
            flpMine.Name = "flpMine";
            flpMine.Size = new Size(483, 421);
            flpMine.TabIndex = 0;
            flpMine.WrapContents = false;
            flpMine.Paint += flpMine_Paint;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.BackColor = Color.Ivory;
            lblPage.ForeColor = Color.SaddleBrown;
            lblPage.Location = new Point(345, 667);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(39, 19);
            lblPage.TabIndex = 4;
            lblPage.Text = "Page";
            lblPage.Click += lblPage_Click;
            // 
            // lblPageSize
            // 
            lblPageSize.AutoSize = true;
            lblPageSize.BackColor = Color.Ivory;
            lblPageSize.ForeColor = Color.SaddleBrown;
            lblPageSize.Location = new Point(460, 667);
            lblPageSize.Name = "lblPageSize";
            lblPageSize.Size = new Size(65, 19);
            lblPageSize.TabIndex = 5;
            lblPageSize.Text = "Page size";
            lblPageSize.Click += lblPageSize_Click;
            // 
            // cboPageSize
            // 
            cboPageSize.BackColor = Color.White;
            cboPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPageSize.FlatStyle = FlatStyle.Popup;
            cboPageSize.FormattingEnabled = true;
            cboPageSize.Location = new Point(527, 664);
            cboPageSize.Name = "cboPageSize";
            cboPageSize.Size = new Size(54, 27);
            cboPageSize.TabIndex = 7;
            cboPageSize.SelectedIndexChanged += cboPageSize_SelectedIndexChanged;
            // 
            // cboPage
            // 
            cboPage.BackColor = Color.White;
            cboPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPage.FlatStyle = FlatStyle.Popup;
            cboPage.FormattingEnabled = true;
            cboPage.Location = new Point(386, 664);
            cboPage.Name = "cboPage";
            cboPage.Size = new Size(54, 27);
            cboPage.TabIndex = 8;
            cboPage.SelectedIndexChanged += cboPage_SelectedIndexChanged;
            // 
            // lblAuthStatus
            // 
            lblAuthStatus.AutoSize = true;
            lblAuthStatus.BackColor = Color.White;
            lblAuthStatus.ForeColor = Color.Maroon;
            lblAuthStatus.Location = new Point(87, 667);
            lblAuthStatus.Name = "lblAuthStatus";
            lblAuthStatus.Size = new Size(106, 19);
            lblAuthStatus.TabIndex = 9;
            lblAuthStatus.Text = "Unauthenticated";
            lblAuthStatus.Click += lblAuthStatus_Click;
            // 
            // lnkAuthAction
            // 
            lnkAuthAction.AutoSize = true;
            lnkAuthAction.BackColor = Color.White;
            lnkAuthAction.Location = new Point(98, 630);
            lnkAuthAction.Name = "lnkAuthAction";
            lnkAuthAction.Size = new Size(43, 19);
            lnkAuthAction.TabIndex = 10;
            lnkAuthAction.TabStop = true;
            lnkAuthAction.Text = "Login";
            lnkAuthAction.LinkClicked += lnkAuthAction_LinkClicked;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.White;
            progressBar.Location = new Point(199, 664);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 23);
            progressBar.TabIndex = 11;
            progressBar.Click += progressBar_Click;
            // 
            // HomNayAnGi
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(666, 716);
            Controls.Add(progressBar);
            Controls.Add(lnkAuthAction);
            Controls.Add(lblAuthStatus);
            Controls.Add(cboPage);
            Controls.Add(cboPageSize);
            Controls.Add(lblPageSize);
            Controls.Add(lblPage);
            Controls.Add(tabControl);
            Controls.Add(btnThemMonAn);
            Controls.Add(btnAnGiGio);
            Controls.Add(lblHomNayAnGi);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4);
            Name = "HomNayAnGi";
            Text = "Hôm nay ăn gì ?";
            Load += HomNayAnGi_Load_1;
            tabControl.ResumeLayout(false);
            tabAll.ResumeLayout(false);
            tabToiDongGop.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHomNayAnGi;
        private Button btnAnGiGio;
        private Button btnThemMonAn;
        private TabControl tabControl;
        private TabPage tabAll;
        private TabPage tabToiDongGop;
        private FlowLayoutPanel flpAll;
        private FlowLayoutPanel flpMine;
        private Label lblPage;
        private Label lblPageSize;
        private ComboBox cboPageSize;
        private ComboBox cboPage;
        private Label lblAuthStatus;
        private LinkLabel lnkAuthAction;
        private ProgressBar progressBar;
    }
}
