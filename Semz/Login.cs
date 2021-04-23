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
            mydb db = new mydb();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `accounts` WHERE `username` = @username", db.GetConnection);
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = textBox1.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                this.Hide();
                changePass passForm = new changePass();
                passForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mydb db = new mydb();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `accounts` WHERE `username` = @username AND `password` = @password", db.GetConnection);
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox2.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                this.Hide();
                main mainForm = new main();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
