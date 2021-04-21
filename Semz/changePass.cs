using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semz
{
    public partial class changePass : Form
    {
        public changePass()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }

        private void changePass_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Change your password.";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Quit.";
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Current Password.";
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter new password.";
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text =  "Confirm your new password.";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Confirm.";
        }
    }
}
