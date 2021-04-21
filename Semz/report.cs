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
    public partial class report : Form
    {
        reportsFunctions repFunctions = new reportsFunctions();
        mydb db = new mydb();
        public report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            main mainForm = new main();
            mainForm.ShowDialog();
            this.Close();
        }

        private void mANAGEACCOUNTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            accounts accountsForm = new accounts();
            accountsForm.ShowDialog();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'waves_schemaDataSet.reports' table. You can move, or remove it, as needed.
            this.reportsTableAdapter.Fill(this.waves_schemaDataSet.reports);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox2.Text);

                if (MessageBox.Show("Do you want to delete the report?", "Delete Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (repFunctions.deleteReports(id))
                    {
                        MessageBox.Show("Successfully Deleted!", "Delete Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        richTextBox1.Text = "";
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("Report not deleted", "Delete Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch
            {
                MessageBox.Show("Please enter a valid ID!", "Delete Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void refresh()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";
            MySqlCommand command = new MySqlCommand("SELECT * FROM `reports` ");
            DataTable table = repFunctions.getReport(command);
            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Return to Admin Menu.";
        }

        private void report_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Manage Accounts.";
        }

        private void aCCOUNTSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Go to Accounts.";
        }

        private void mANAGEACCOUNTSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage User Accounts.";
        }

        private void lOGOUTToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Logout.";
        }

        private void toolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Inventory.";
        }

        private void toolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Transactions.";
        }

        private void toolStripMenuItem3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Reports.";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Quit.";
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click a cell to expand info. Double click a cell to edit.";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Find specific user report.";
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to add user report.";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to update the selected user report.";
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to delete the user report.";
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to refresh the datas. Clear the information window.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addReport addReportForm = new addReport();
            if(addReportForm.ShowDialog() == DialogResult.OK)
            {
                refresh();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            updateReport updateReportForm = new updateReport();
            updateReportForm.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateReportForm.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateReportForm.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            updateReportForm.richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if(updateReportForm.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox1.Text.Trim();
                bool numeric = int.TryParse(input, out int num);
                MySqlCommand command;
                if (numeric)
                {
                    command = new MySqlCommand("SELECT * FROM `reports` WHERE `id_reports` =" + num);
                }
                else
                {
                    command = new MySqlCommand("SELECT * FROM `reports` WHERE `report_title` LIKE @input OR `author` LIKE @input", db.GetConnection);
                    command.Parameters.AddWithValue("@input", "%" + input + "%");

                }

                DataTable table = repFunctions.getReport(command);
                dataGridView1.DataSource = table;

                textBox2.Text = table.Rows[0]["id_reports"].ToString();
                textBox3.Text = table.Rows[0]["report_title"].ToString();
                textBox4.Text = table.Rows[0]["date"].ToString();
                textBox5.Text = table.Rows[0]["author"].ToString();
                richTextBox1.Text = table.Rows[0]["report"].ToString();
            }
            catch
            {
                MessageBox.Show("Enter a Valid Input.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }


}
