using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Semz
{
    class accountsFunctions
    {
        readonly mydb db = new mydb();

        public bool deleteUser(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `accounts` WHERE `id_accounts` = @id", db.GetConnection);
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
    }

}
