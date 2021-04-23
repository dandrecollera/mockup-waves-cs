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
    public partial class addInventory : Form
    {
        inventoryFunction invFunction = new inventoryFunction();
        public addInventory()
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
                string item = textBox1.Text;
                int stock = Convert.ToInt32(textBox2.Text);
                double price = double.Parse(textBox3.Text);
                string type = "";
                foreach (Control foo in panel1.Controls)
                {
                    if (foo is RadioButton choice)
                    {
                        if (choice.Checked)
                        {
                            type = choice.Tag.ToString();
                        }
                    }
                }

                if (verif())
                {
                    if (invFunction.insertInventory(item, stock, price, type))
                    {
                        MessageBox.Show("New Item Added.", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error.", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields.", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input.", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public bool verif()
        {
            if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
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
