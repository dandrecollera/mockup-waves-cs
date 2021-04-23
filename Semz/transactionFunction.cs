using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
        
    }
}
