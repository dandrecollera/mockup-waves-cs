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
    public partial class updateAccounts : Form
    {
        accountsFunctions accFunctions = new accountsFunctions();

        public updateAccounts()
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
            try
            {
                int id = Convert.ToInt32(textBox4.Text);
                string name = textBox1.Text;
                string username = textBox2.Text;
                string password = textBox3.Text;
                string sex = "";
                if (radioButton1.Checked)
                {
                    sex = "M";
                }
                else if (radioButton2.Checked)
                {
                    sex = "F";
                }
                if (verif())
                {
                    if(accFunctions.updateUser(id, name, username, password, sex))
                    {
                        MessageBox.Show("User Updated.", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error.", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields.", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Please enter a Valid User ID", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verif()
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
