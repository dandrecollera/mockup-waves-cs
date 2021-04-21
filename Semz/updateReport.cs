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
    public partial class updateReport : Form
    {

        reportsFunctions repFunctions = new reportsFunctions();
        public updateReport()
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
                int id = Convert.ToInt32(textBox1.Text);
                string title = textBox2.Text;
                string author = textBox3.Text;
                string report = richTextBox1.Text;

                if (verif())
                {
                    if(repFunctions.updateReport(id, title, author, report))
                    {
                        MessageBox.Show("Report Updated.", "Update Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error.", "Update Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields.", "Update Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Please enter a Valid Report ID.", "Update Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool verif()
        {
            if(textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || richTextBox1.Text.Trim() == "")
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
