
using System;
using System.Drawing;
using System.Windows.Forms;
using Bai01;

namespace DashBoard
{
    public partial class FormDashBoard : Form
    {
        public FormDashBoard()
        {
            InitializeComponent();
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            Bai01Form formBai1 = new Bai01Form();
            formBai1.ShowDialog();
        }
    }
}
