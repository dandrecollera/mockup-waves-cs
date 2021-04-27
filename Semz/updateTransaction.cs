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
        public List<int> rowcount;
        public List<int> carted;
        public List<int> defVal = new List<int>();
        public List<int> newVal = new List<int>();
        public List<int> stockCount= new List<int>();
        public List<int> newStock = new List<int>();
        public List<int> ids = new List<int>();
        public string carts;
        public string rownum;

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
            int y = 0;
            for(int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if(rowcount.Contains(x))
                {
                    dataGridView1.Rows[x].Cells[2].Value = carted[y];
                    y++;
                }
                defVal.Add(Convert.ToInt32(dataGridView1.Rows[x].Cells[2].Value.ToString()));
                stockCount.Add(Convert.ToInt32(dataGridView1.Rows[x].Cells[3].Value.ToString()));
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
            ids.Clear();
            newVal.Clear();
            rownum = "";
            carts = "";
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                ids.Add(int.Parse(dataGridView1.Rows[x].Cells[4].Value.ToString()));
                int val = int.Parse(dataGridView1.Rows[x].Cells[2].Value.ToString());
                if(val >= 1)
                {
                    rownum += x + " ";
                    carts += dataGridView1.Rows[x].Cells[2].Value.ToString() + " ";
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[1].Value) * Convert.ToDouble(dataGridView1.Rows[x].Cells[2].Value);
                    text += dataGridView1.Rows[x].Cells[0].Value.ToString() + " [" + dataGridView1.Rows[x].Cells[2].Value.ToString() + "]" + "\n";
                    
                }
                newVal.Add(Convert.ToInt32(dataGridView1.Rows[x].Cells[2].Value));
            }
            addOrDeduct();
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

        private void addOrDeduct()
        {
            int result;
            newStock.Clear();
            for(int x = 0; x < defVal.Count; x++)
            {
                //new val greater than first val then deduct more stocks
                if (newVal[x] > defVal[x])
                {
                    result = newVal[x] - defVal[x];

                    if (newVal[x] > stockCount[x])
                    {
                        dataGridView1.Rows[x].Cells[2].Value = defVal[x];
                    }
                    else
                    {
                        newStock.Add(stockCount[x] - result);
                    }
                }
                else
                {
                    result = defVal[x] - newVal[x];
                    newStock.Add(stockCount[x] + result);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                int id = Convert.ToInt32(textBox1.Text);
                double amount = Convert.ToDouble(textBox2.Text);
                double amountPaid = Convert.ToDouble(textBox3.Text);
                string items = richTextBox1.Text;

                if(amountPaid >= amount)
                {
                    if (verif())
                    {
                        if (transFunction.updateTransaction(id, amount, amountPaid, items, rownum, carts))
                        {
                            MessageBox.Show("Transaction Updated", "Update Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            transFunction.updateStocks(ids, newStock);
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

    }
}

