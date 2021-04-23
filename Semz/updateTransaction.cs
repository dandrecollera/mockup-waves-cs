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
    public partial class updateTransaction : Form
    {
        transactionFunction transFunction = new transactionFunction();
        public updateTransaction()
        {
            InitializeComponent();
        }

        private void updateTransaction_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'waves_schemaDataSet.inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.waves_schemaDataSet.inventory);
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                dataGridView1.Rows[x].Cells[2].Value = "0";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addToCart addToCartForm = new addToCart();
            addToCartForm.textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            addToCartForm.stock = 999999;
            if(addToCartForm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.CurrentRow.Cells[2].Value = addToCartForm.textBox1.Text;
                refresh();
            }
        }

        private void refresh()
        {
            string text = "";
            double amount = 0;
            for(int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                int val = int.Parse(dataGridView1.Rows[x].Cells[2].Value.ToString());
                if(val >= 1)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[x].Cells[2].Value);
                    text += dataGridView1.Rows[x].Cells[0].Value.ToString() + " [" + dataGridView1.Rows[x].Cells[2].Value.ToString() + "]" + "\n";
                }
            }
            richTextBox1.Text = text;
            textBox2.Text = string.Format("{0:###,###.00}", amount);
        }

        public bool verif()
        {
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || richTextBox1.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                double amount = Convert.ToDouble(textBox2.Text);
                double amountPaid = Convert.ToDouble(textBox3.Text);
                string items = richTextBox1.Text;

                if(amountPaid >= amount)
                {
                    if (verif())
                    {
                        if (transFunction.updateTransaction(id, amount, amountPaid, items))
                        {
                            MessageBox.Show("Transaction Updated", "Update Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                             MessageBox.Show("Error!", "Update Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields", "Update Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Amount in Amound Paid", "Update Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input", "Update Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
