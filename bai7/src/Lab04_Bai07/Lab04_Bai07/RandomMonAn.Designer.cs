namespace Lab04_Bai07
{
    partial class RandomMonAn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomMonAn));
            lblTenMon = new Label();
            picAnhMonAn = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picAnhMonAn).BeginInit();
            SuspendLayout();
            // 
            // lblTenMon
            // 
            lblTenMon.BackColor = Color.Transparent;
            lblTenMon.Font = new Font("Times New Roman", 18F);
            lblTenMon.ForeColor = Color.Maroon;
            lblTenMon.Location = new Point(71, 87);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(329, 66);
            lblTenMon.TabIndex = 0;
            lblTenMon.TextAlign = ContentAlignment.MiddleCenter;
            lblTenMon.Click += lblTenMon_Click;
            // 
            // picAnhMonAn
            // 
            picAnhMonAn.BackColor = Color.Transparent;
            picAnhMonAn.Location = new Point(121, 156);
            picAnhMonAn.Name = "picAnhMonAn";
            picAnhMonAn.Size = new Size(222, 145);
            picAnhMonAn.SizeMode = PictureBoxSizeMode.StretchImage;
            picAnhMonAn.TabIndex = 1;
            picAnhMonAn.TabStop = false;
            picAnhMonAn.Click += picAnhMonAn_Click;
            // 
            // RandomMonAn
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(453, 361);
            Controls.Add(picAnhMonAn);
            Controls.Add(lblTenMon);
            Font = new Font("Times New Roman", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "RandomMonAn";
            Text = "RandomMonAn";
            ((System.ComponentModel.ISupportInitialize)picAnhMonAn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTenMon;
        private PictureBox picAnhMonAn;
    }
}