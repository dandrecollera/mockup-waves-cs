using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Semz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            changePass passForm = new changePass();
            passForm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Login into your account.";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Quit.";
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your username.";
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter your password.";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Confirm.";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Forget Password. Change your password.";
        }
    }
}
