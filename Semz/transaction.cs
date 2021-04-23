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
    public partial class transaction : Form
    {
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

        }

        private void transaction_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'waves_schemaDataSet.transaction' table. You can move, or remove it, as needed.
            this.transactionTableAdapter.Fill(this.waves_schemaDataSet.transaction);

        }
    }
}
