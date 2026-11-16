namespace Bai01
{
    partial class Bai01Form
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
            btnGET = new Button();
            txtURL = new TextBox();
            rtbHTML = new RichTextBox();
            SuspendLayout();
            // 
            // btnGET
            // 
            btnGET.Font = new Font("Times New Roman", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGET.Location = new Point(1143, 42);
            btnGET.Name = "btnGET";
            btnGET.Size = new Size(252, 90);
            btnGET.TabIndex = 0;
            btnGET.Text = "GET";
            btnGET.UseVisualStyleBackColor = true;
            btnGET.Click += btnGET_Click;
            // 
            // txtURL
            // 
            txtURL.Font = new Font("Times New Roman", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtURL.Location = new Point(59, 42);
            txtURL.Multiline = true;
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(1044, 90);
            txtURL.TabIndex = 1;
            // 
            // rtbHTML
            // 
            rtbHTML.Location = new Point(33, 156);
            rtbHTML.Name = "rtbHTML";
            rtbHTML.ReadOnly = true;
            rtbHTML.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbHTML.Size = new Size(1378, 648);
            rtbHTML.TabIndex = 2;
            rtbHTML.Text = "";
            // 
            // Bai01Form
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ảnh_nền_Bài_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1442, 840);
            Controls.Add(rtbHTML);
            Controls.Add(txtURL);
            Controls.Add(btnGET);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Bai01Form";
            Text = "Bài 1- View HTML Source";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGET;
        private TextBox txtURL;
        private RichTextBox rtbHTML;
    }
}
