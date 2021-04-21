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
    public partial class addReport : Form
    {
        reportsFunctions repFunctions = new reportsFunctions();

        public addReport()
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
            string title = textBox1.Text;
            string author = textBox2.Text;
            string report = richTextBox1.Text;

            if (verif())
            {
                if(repFunctions.insertReport(title, author, report))
                {
                    MessageBox.Show("New Report Added!", "Add Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error!", "Add Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields.", "Add Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool verif()
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || richTextBox1.Text.Trim() == "")
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
