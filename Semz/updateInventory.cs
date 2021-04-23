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
    public partial class updateInventory : Form
    {
        inventoryFunction invFunctions = new inventoryFunction();
        public updateInventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                string item = textBox2.Text;
                int stock = Convert.ToInt32(textBox3.Text);
                double price = double.Parse(textBox4.Text);
                string type = "";
                foreach(Control foo in panel1.Controls)
                {
                    if(foo is RadioButton choice)
                    {
                        if (choice.Checked)
                        {
                            type = choice.Tag.ToString();
                        }
                    }
                }

                if (verif())
                {
                    if (invFunctions.updateInventory(id, item, stock, price, type))
                    {
                        MessageBox.Show("Item Updated.", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields.", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input.", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        public bool verif()
        {
            if(textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
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
