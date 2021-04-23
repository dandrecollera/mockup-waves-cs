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
    public partial class addTransaction : Form
    {
        transactionFunction transFunction = new transactionFunction();
        public List<int> idlist = new List<int>();
        public List<int> stock = new List<int>();
        public List<int> addC = new List<int>();
        public addTransaction()
        {
            InitializeComponent();
        }

        private void addTransaction_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'waves_schemaDataSet.inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter.Fill(this.waves_schemaDataSet.inventory);
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                dataGridView1.Rows[x].Cells[3].Value = "0";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void refresh()
        {
            string text = "";
            double amount = 0;
            idlist.Clear();
            stock.Clear();
            addC.Clear();
            for(int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                int val = int.Parse(dataGridView1.Rows[x].Cells[3].Value.ToString());
                if ( val >= 1)
                {
                    idlist.Add(Convert.ToInt32(dataGridView1.Rows[x].Cells[4].Value));
                    stock.Add(Convert.ToInt32(dataGridView1.Rows[x].Cells[1].Value));
                    addC.Add(Convert.ToInt32(dataGridView1.Rows[x].Cells[3].Value));
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value);
                    text += dataGridView1.Rows[x].Cells[0].Value.ToString() +" [" + dataGridView1.Rows[x].Cells[3].Value.ToString()+ "]" + "\n";
                }
            }
            richTextBox1.Text = text;
            textBox1.Text = string.Format("{0:###,###.00}", amount);
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addToCart addToCartForm = new addToCart();
            addToCartForm.textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            addToCartForm.stock = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            if(addToCartForm.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.CurrentRow.Cells[3].Value = addToCartForm.textBox1.Text;
                refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double amount = Convert.ToDouble(textBox1.Text);
                double amountPaid = Convert.ToDouble(textBox2.Text);
                string items = richTextBox1.Text;
                
                if(amountPaid >= amount)
                {
                    if (verif())
                    {
                        if(transFunction.insertTransaction(amount, amountPaid, items))
                        {
                            MessageBox.Show("Successfully Added", "Add Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            transFunction.updateStocks(idlist, stock, addC);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error!", "Add Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields", "Add Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Amount in Amount Paid", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input", "Add Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool verif()
        {
            if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || richTextBox1.Text.Trim() == "")
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
