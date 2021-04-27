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
    public partial class main : Form
    {
     
        public main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mANAGEACCOUNTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateBar();
            this.Hide();
            accounts accountForm = new accounts();
            accountForm.ShowDialog();
            this.Close();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateBar();
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateBar();
            this.Hide();
            inventory inventoryForm = new inventory();
            inventoryForm.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            updateBar();
            this.Hide();
            transaction transactionForm = new transaction();
            transactionForm.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            updateBar();
            this.Hide();
            report reportForm = new report();
            reportForm.ShowDialog();
            this.Close();
        }

        private void aCCOUNTSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Go to Accounts.";
        }

        private void aCCOUNTSToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Admin Menu.";
        }

        private void mANAGEACCOUNTSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage User Accounts.";
        }

        private void mANAGEACCOUNTSToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Admin Menu.";
        }

        private void lOGOUTToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Logout to Admin Menu.";
        }

        private void lOGOUTToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Admin Menu.";
        }

        private void menuStrip2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Inventory.";
        }

        private void menuStrip2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Admin Menu.";
        }

        private void menuStrip3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Transaction.";
        }

        private void menuStrip3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Admin Menu.";
        }

        private void menuStrip4_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Manage Reports.";
        }

        private void menuStrip4_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Admin Menu.";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Quit.";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Welcome to the Admin Menu.";
        }

        public void updateBar()
        {
            toolStripProgressBar1.Visible = true;
            for(int x = 0; x <= 100; x++)
            {
                toolStripProgressBar1.Value = x;
                Task.Delay(10).Wait();
            }

        }
    }
}
