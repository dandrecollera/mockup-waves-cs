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
    public partial class changePass : Form
    {

        public string username;
        mydb db = new mydb();

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

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Return to Login Menu.";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                pictureBox4.BackgroundImage = Semz.Properties.Resources.eye_openw;
            }
            else
            {
                textBox2.PasswordChar = '*';
                pictureBox4.BackgroundImage = Semz.Properties.Resources.eye_closew;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                textBox3.PasswordChar = '\0';
                pictureBox5.BackgroundImage = Semz.Properties.Resources.eye_openw;
            }
            else
            {
                textBox3.PasswordChar = '*';
                pictureBox5.BackgroundImage = Semz.Properties.Resources.eye_closew;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == textBox2.Text)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `accounts` SET `password` = @password WHERE `username` = @username", db.GetConnection);
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBox2.Text;
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show("Password Changed.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Login loginForm = new Login();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
