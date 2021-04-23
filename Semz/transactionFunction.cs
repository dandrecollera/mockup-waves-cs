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
    class transactionFunction
    {
        mydb db = new mydb();
        public bool insertTransaction(double amount, double amountPaid, string items)
        {
            double change = amountPaid - amount;
            MySqlCommand command = new MySqlCommand("INSERT INTO `transaction`(`amount`,`amount_paid`,`change`, `items`) VALUE (@amount, @amountpaid, @change ,@items)", db.GetConnection);

            command.Parameters.Add("@amount", MySqlDbType.Decimal).Value = amount;
            command.Parameters.Add("@amountpaid", MySqlDbType.Decimal).Value = amountPaid;
            command.Parameters.Add("@change", MySqlDbType.Decimal).Value = change;
            command.Parameters.Add("@items", MySqlDbType.LongText).Value = items;

            db.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }
        
        public void updateStocks(List<int> id, List<int> stock, List<int> addc)
        {
            for(int x = 0; x < id.Count; x++)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `inventory` SET `stock` = @stock WHERE `id_inventory` = @id", db.GetConnection);
                int fstock = stock[x] - addc[x];
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id[x];
                command.Parameters.Add("@stock", MySqlDbType.Int32).Value = fstock;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
            }
        }

        public bool deleteTransaction(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `transaction` WHERE `id_transaction` = @id", db.GetConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public DataTable getTransaction(MySqlCommand command)
        {
            command.Connection = db.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateTransaction(int id, double amount, double amountPaid, string items)
        {
            double change = amountPaid - amount;
            MySqlCommand command = new MySqlCommand("UPDATE `transaction` SET `amount` = @amount, `amount_paid` = @amountpaid, `change` = @change,`items` = @items WHERE `id_transaction` = @id", db.GetConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@amount", MySqlDbType.Decimal).Value = amount;
            command.Parameters.Add("@amountpaid", MySqlDbType.Decimal).Value = amountPaid;
            command.Parameters.Add("@change", MySqlDbType.Decimal).Value = change;
            command.Parameters.Add("@items", MySqlDbType.LongText).Value = items;

            db.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
