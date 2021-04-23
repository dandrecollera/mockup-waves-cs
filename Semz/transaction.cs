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
    public partial class transaction : Form
    {
        transactionFunction transFunction = new transactionFunction();
        public transaction()
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

        private void mANAGEACCOUNTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            accounts accountForm = new accounts();
            accountForm.ShowDialog();
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

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            report reportForm = new report();
            reportForm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addTransaction addTransactionForm = new addTransaction();
            if(addTransactionForm.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        public void refresh()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox1.Text = "";
            MySqlCommand command = new MySqlCommand("SELECT * FROM `transaction`");
            DataTable table = transFunction.getTransaction(command);
            dataGridView1.DataSource = table;
        }

        private void transaction_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'waves_schemaDataSet.transaction' table. You can move, or remove it, as needed.
            this.transactionTableAdapter.Fill(this.waves_schemaDataSet.transaction);
            refresh();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox2.Text);

                if(MessageBox.Show("Do you want to delete the transaction?", "Delete Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (transFunction.deleteTransaction(id))
                    {
                        MessageBox.Show("Successfully Deleted!", "Delete Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        richTextBox1.Text = "";
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("Transaction not Deleted.", "Delete Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            update();
        }

        private void update()
        {
            updateTransaction updateTransactionForm = new updateTransaction();
            updateTransactionForm.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateTransactionForm.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateTransactionForm.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateTransactionForm.richTextBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (updateTransactionForm.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text.Trim());
                MySqlCommand command = new MySqlCommand("SELECT * FROM `transaction` WHERE `id_transaction` =" + id);
                DataTable table = transFunction.getTransaction(command);
                dataGridView1.DataSource = table;

                textBox2.Text = table.Rows[0]["id_transaction"].ToString();
                textBox3.Text = table.Rows[0]["amount"].ToString();
                textBox4.Text = table.Rows[0]["amount_paid"].ToString();
                textBox5.Text = table.Rows[0]["change"].ToString();
                textBox6.Text = table.Rows[0]["date"].ToString();
                richTextBox1.Text = table.Rows[0]["items"].ToString();
            }
            catch
            {
                MessageBox.Show("Enter a Valid Transaction ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void transaction_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Transaction.";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Go to Admin Menu.";
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
            toolStripStatusLabel1.Text = "Logout to Admin Menu.";
        }

        private void toolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Inventory.";
        }

        private void toolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Transaction.";
        }

        private void toolStripMenuItem3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Reports.";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Quit.";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Find specific user transaction.";
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to add new user transaction.";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to update the user transaction.";
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to delete the user transaction.";
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to refresh the datas. Clear the information window";
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click a cell to expand info. Double click a cell to edit.";
        }
    }
}
