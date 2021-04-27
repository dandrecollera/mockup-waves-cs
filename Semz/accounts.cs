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
    public partial class accounts : Form
    {
        accountsFunctions accFunctions = new accountsFunctions();
        mydb db = new mydb();
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
            // TODO: This line of code loads data into the 'waves_schemaDataSet1.accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.waves_schemaDataSet1.accounts);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
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
                        textBox7.Text = "";
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            MySqlCommand command = new MySqlCommand("SELECT * FROM `accounts`");
            DataTable table = accFunctions.getUser(command);

            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(textBox7.PasswordChar == '*')
            {
                textBox7.PasswordChar = '\0';
                pictureBox3.BackgroundImage = Semz.Properties.Resources.eye_openw;
            }
            else
            {
                textBox7.PasswordChar = '*';
                pictureBox3.BackgroundImage = Semz.Properties.Resources.eye_closew;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addAccounts addAccountForm = new addAccounts();
            if(addAccountForm.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Return to Admin Menu.";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Manage Accounts.";
        }

        private void aCCOUNTSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Go to Accounts.";
        }

        private void accounts_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Manage Accounts.";
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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Quit.";
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click a cell to expand info. Double click a cell to edit.";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Find specific user account.";
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Show/Hide Password.";
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to add user account.";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to update the selected user.";
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to delete the user account.";
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to refresh the datas. Clear the information window.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();
        }

        public void update()
        {
            updateAccounts updateAccountsForm = new updateAccounts();
            updateAccountsForm.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateAccountsForm.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateAccountsForm.textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateAccountsForm.textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "M")
            {
                updateAccountsForm.radioButton1.Checked = true;
            }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "F")
            {
                updateAccountsForm.radioButton2.Checked = true;
            }

            if (updateAccountsForm.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            update();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }


        private void search()
        {
            try
            {
                string input = textBox1.Text.Trim();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `accounts` WHERE `name` LIKE @input OR `username` LIKE @input OR `id_accounts` LIKE @input", db.GetConnection);
                command.Parameters.AddWithValue("@input", "%" + input + "%");
                DataTable table = accFunctions.getUser(command);

                dataGridView1.DataSource = table;

                textBox2.Text = table.Rows[0]["id_accounts"].ToString();
                textBox3.Text = table.Rows[0]["name"].ToString();
                textBox4.Text = table.Rows[0]["username"].ToString();
                textBox5.Text = table.Rows[0]["sex"].ToString();
                textBox6.Text = table.Rows[0]["date"].ToString();
                textBox7.Text = table.Rows[0]["password"].ToString();
            }
            catch
            {
                return;
            }
        }
    }
}
