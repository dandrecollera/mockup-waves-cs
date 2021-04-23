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
    public partial class addToCart : Form
    {
        public int stock;

        public addToCart()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int addToC = Convert.ToInt32(textBox1.Text);
                if (addToC <= stock)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Invalid Amount.", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Invalid Input", "Add to Cart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
