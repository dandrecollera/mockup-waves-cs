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
    public partial class accounts : Form
    {
        accountsFunctions accFunctions = new accountsFunctions();
        public accounts()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mainForm = new main();
            mainForm.ShowDialog();
            this.Close();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            inventory inventoryForm = new inventory();
            inventoryForm.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            transaction transactionForm = new transaction();
            transactionForm.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            report reportForm = new report();
            reportForm.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accounts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'waves_schemaDataSet.accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.waves_schemaDataSet.accounts);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox2.Text);

                if (MessageBox.Show("Do you want to delete the user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (accFunctions.deleteUser(id))
                    {
                        MessageBox.Show("Successfully Deleted", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        refresh();

                    }
                    else
                    {
                        MessageBox.Show("User not deleted", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Please enter a valid ID!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void refresh()
        {
            this.accountsTableAdapter.Fill(this.waves_schemaDataSet.accounts);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
