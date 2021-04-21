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
    public partial class addAccounts : Form
    {
        accountsFunctions accFunction = new accountsFunctions();
        public addAccounts()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            string sex = "";
            if(radioButton1.Checked)
            {
                sex = "M";
            }
            else if (radioButton2.Checked)
            {
                sex = "F";
            }

            if (verif())
            {
                if(accFunction.insertUser(name, username, password, sex))
                {
                    MessageBox.Show("New User Added.", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error.", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields.", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool verif()
        {
            if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                textBox3.PasswordChar = '\0';
                pictureBox1.BackgroundImage = Semz.Properties.Resources.eye_openw;
            }
            else
            {
                textBox3.PasswordChar = '*';
                pictureBox1.BackgroundImage = Semz.Properties.Resources.eye_closew;
            }
        }
    }
}
