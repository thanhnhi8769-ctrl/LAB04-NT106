namespace Lab04_Bai07_Server
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblHOMNAYANGI = new Label();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // lblHOMNAYANGI
            // 
            lblHOMNAYANGI.AutoSize = true;
            lblHOMNAYANGI.BackColor = Color.Transparent;
            lblHOMNAYANGI.Font = new Font("Times New Roman", 20F, FontStyle.Bold);
            lblHOMNAYANGI.ForeColor = Color.Maroon;
            lblHOMNAYANGI.Location = new Point(104, 118);
            lblHOMNAYANGI.Name = "lblHOMNAYANGI";
            lblHOMNAYANGI.Size = new Size(242, 31);
            lblHOMNAYANGI.TabIndex = 0;
            lblHOMNAYANGI.Text = "HÔM NAY ĂN GÌ?";
            lblHOMNAYANGI.TextAlign = ContentAlignment.MiddleCenter;
            lblHOMNAYANGI.Click += lblHOMNAYANGI_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(114, 176);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(215, 23);
            progressBar.TabIndex = 1;
            progressBar.Click += progressBar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(755, 462);
            Controls.Add(progressBar);
            Controls.Add(lblHOMNAYANGI);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHOMNAYANGI;
        private ProgressBar progressBar;
    }
}
