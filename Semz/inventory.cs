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
    public partial class inventory : Form
    {
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
    }
}
