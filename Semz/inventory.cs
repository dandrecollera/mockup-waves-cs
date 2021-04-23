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
    public partial class inventory : Form
    {
        inventoryFunction invFunction = new inventoryFunction();
        mydb db = new mydb();
        public inventory()
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

        private void mANAGEACCOUNTSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            accounts accountsForm = new accounts();
            accountsForm.ShowDialog();
            this.Close();
        }

        private void lOGOUTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
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

        private void inventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'waves_schemaDataSet.inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.waves_schemaDataSet.inventory);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = string.Format("{0:###,###.00}",dataGridView1.CurrentRow.Cells[3].Value);
            string type = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (type == "T-Shirt")
            {
                clearRadio();
                radioButton1.Checked = true;
            } 
            else if(type == "Hoodie")
            {
                clearRadio();
                radioButton2.Checked = true;
            }
            else if (type == "Shorts")
            {
                clearRadio();
                radioButton3.Checked = true;
            }
            else if (type == "Jeans")
            {
                clearRadio();
                radioButton4.Checked = true;
            }
            else if (type == "Cap")
            {
                clearRadio();
                radioButton5.Checked = true;
            }
            else if (type == "Socks")
            {
                clearRadio();
                radioButton6.Checked = true;
            }
            else if (type == "Jacket")
            {
                clearRadio();
                radioButton7.Checked = true;
            }
        }

        public void clearRadio()
        {
            foreach(Control foo in panel1.Controls)
            {
                if(foo is RadioButton choice)
                {
                    choice.Checked = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }
        public void refresh()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            clearRadio();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `inventory`");
            DataTable table = invFunction.getInventory(command);

            dataGridView1.DataSource = table;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox2.Text);
                if(MessageBox.Show("Do you want to delete the item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (invFunction.deleteInventory(id))
                    {
                        MessageBox.Show("Successfully Deleted", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        clearRadio();
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("Inventory is not deleted.", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addInventory addInventoryForm = new addInventory();
            if(addInventoryForm.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        public void update()
        {
            updateInventory updateInventoryForms = new updateInventory();
            updateInventoryForms.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateInventoryForms.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateInventoryForms.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            updateInventoryForms.textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            foreach(Control foo in panel1.Controls)
            {
                if(foo is RadioButton choice)
                {
                    if (choice.Checked)
                    {
                        foreach(Control control in updateInventoryForms.panel1.Controls)
                        {
                            if(control is RadioButton aChoice)
                            {
                                if(aChoice.Tag.ToString() == choice.Tag.ToString())
                                {
                                    aChoice.Checked = true;
                                }
                            }
                        }
                    }
                }
            }


            if(updateInventoryForms.ShowDialog() == DialogResult.OK)
            {
                refresh();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            update();
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
                    command = new MySqlCommand("SELECT * FROM `inventory` WHERE `id_inventory` =" + num);
                }
                else
                {
                    command = new MySqlCommand("SELECT * FROM `inventory` WHERE `item` LIKE @input OR `type` LIKE @input", db.GetConnection);
                    command.Parameters.AddWithValue("@input", "%" + input + "%");
                }
                DataTable table = invFunction.getInventory(command);

                dataGridView1.DataSource = table;
                textBox2.Text = table.Rows[0]["id_inventory"].ToString();
                textBox3.Text = table.Rows[0]["item"].ToString();
                textBox4.Text = table.Rows[0]["stock"].ToString();
                textBox5.Text = table.Rows[0]["price"].ToString();
                string type = table.Rows[0]["type"].ToString();
                foreach(Control foo in panel1.Controls)
                {
                    if(foo is RadioButton choice)
                    {
                        if(choice.Tag.ToString() == type)
                        {
                            choice.Checked = true;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter a valid input.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inventory_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Inventory.";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Go to Admin Menu.";
        }

        private void mANAGEACCOUNTSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage User Accounts.";
        }

        private void lOGOUTToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Logout to Admin Menu.";
        }

        private void toolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Transaction.";
        }

        private void toolStripMenuItem3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Reports.";
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Quit.";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Find specific user inventory.";
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to add new user inventory.";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to update the user inventory.";
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to delete the user inventory.";
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click to refresh the datas. Clear the information window";
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Click a cell to expand info. Double click a cell to edit.";
        }

        private void aCCOUNTSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Go to Accounts.";
        }

        private void toolStripMenuItem3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Report.";
        }
    }
}
