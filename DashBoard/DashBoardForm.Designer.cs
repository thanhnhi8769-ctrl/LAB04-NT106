namespace DashBoard
{
    partial class FormDashBoard
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
            lblLab = new Label();
            btnBai1 = new Button();
            btnBai2 = new Button();
            btnBai3 = new Button();
            btnBai4 = new Button();
            btnBai7 = new Button();
            label1 = new Label();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblLab
            // 
            lblLab.AutoSize = true;
            lblLab.BackColor = Color.Transparent;
            lblLab.Font = new Font("Times New Roman", 22.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLab.ForeColor = Color.White;
            lblLab.Location = new Point(287, 48);
            lblLab.Name = "lblLab";
            lblLab.Size = new Size(420, 35);
            lblLab.TabIndex = 0;
            lblLab.Text = " Working with Web Server in C#";
            // 
            // btnBai1
            // 
            btnBai1.BackColor = Color.FromArgb(20, 35, 70);
            btnBai1.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBai1.ForeColor = Color.White;
            btnBai1.Location = new Point(151, 144);
            btnBai1.Name = "btnBai1";
            btnBai1.Size = new Size(139, 65);
            btnBai1.TabIndex = 1;
            btnBai1.Text = "Bài 1";
            btnBai1.UseVisualStyleBackColor = false;
            btnBai1.Click += btnBai1_Click;
            // 
            // btnBai2
            // 
            btnBai2.BackColor = Color.FromArgb(20, 35, 70);
            btnBai2.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBai2.ForeColor = Color.White;
            btnBai2.Location = new Point(376, 144);
            btnBai2.Name = "btnBai2";
            btnBai2.Size = new Size(139, 65);
            btnBai2.TabIndex = 2;
            btnBai2.Text = "Bài 2";
            btnBai2.UseVisualStyleBackColor = false;
            btnBai2.Click += btnBai2_Click;
            // 
            // btnBai3
            // 
            btnBai3.BackColor = Color.FromArgb(20, 35, 70);
            btnBai3.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBai3.ForeColor = Color.White;
            btnBai3.Location = new Point(595, 144);
            btnBai3.Name = "btnBai3";
            btnBai3.Size = new Size(139, 65);
            btnBai3.TabIndex = 3;
            btnBai3.Text = "Bài 3";
            btnBai3.UseVisualStyleBackColor = false;
            btnBai3.Click += btnBai3_Click;
            // 
            // btnBai4
            // 
            btnBai4.BackColor = Color.FromArgb(20, 35, 70);
            btnBai4.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBai4.ForeColor = Color.White;
            btnBai4.Location = new Point(151, 242);
            btnBai4.Name = "btnBai4";
            btnBai4.Size = new Size(139, 65);
            btnBai4.TabIndex = 4;
            btnBai4.Text = "Bài 4";
            btnBai4.UseVisualStyleBackColor = false;
            btnBai4.Click += btnBai4_Click;
            // 
            // btnBai7
            // 
            btnBai7.BackColor = Color.FromArgb(20, 35, 70);
            btnBai7.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBai7.ForeColor = Color.White;
            btnBai7.Location = new Point(376, 242);
            btnBai7.Name = "btnBai7";
            btnBai7.Size = new Size(139, 65);
            btnBai7.TabIndex = 5;
            btnBai7.Text = "Bài 7";
            btnBai7.UseVisualStyleBackColor = false;
            btnBai7.Click += btnBai7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(297, 412);
            label1.Name = "label1";
            label1.Size = new Size(322, 31);
            label1.TabIndex = 6;
            label1.Text = "LAB04_NT106 - NHÓM 3";
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThoat.Location = new Point(771, 450);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 43);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // FormDashBoard
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Nền_DashBoard;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(893, 505);
            Controls.Add(btnThoat);
            Controls.Add(label1);
            Controls.Add(btnBai7);
            Controls.Add(btnBai4);
            Controls.Add(btnBai3);
            Controls.Add(btnBai2);
            Controls.Add(btnBai1);
            Controls.Add(lblLab);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.Desktop;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormDashBoard";
            Text = "LAB04";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLab;
        private Button btnBai1;
        private Button btnBai2;
        private Button btnBai3;
        private Button btnBai4;
        private Button btnBai7;
        private Label label1;
        private Button btnThoat;
    }
}
