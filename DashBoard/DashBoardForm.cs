
using System;
using System.Drawing;
using System.Windows.Forms;
using Lab04_Bai07;
using LAB03;
using Bai01;
using Bai02;
using Bai03;

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

        private void btnBai2_Click(object sender, EventArgs e)
        {
            Bai02Form formBai02 = new Bai02Form();
            formBai02.ShowDialog();
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            Bai03Form formBai03 = new Bai03Form();
            formBai03.ShowDialog();
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            Lab04_Bai04 form = new Lab04_Bai04();
            form.Show();
        }

        private void btnBai7_Click(object sender, EventArgs e)
        {
            HomNayAnGi form = new HomNayAnGi();
            form.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
