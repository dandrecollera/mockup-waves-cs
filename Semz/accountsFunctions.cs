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

        public bool insertUser(string name, string username, string password, string sex)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `accounts`(`name`, `username`, `password`, `sex`) VALUE (@name, @username, @password, @sex)", db.GetConnection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@sex", MySqlDbType.VarChar).Value = sex;

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

        public bool updateUser(int id,string name, string username, string password, string sex)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `accounts` SET `name` = @name, `username` = @username, `password` = @password, `sex` = @sex WHERE `id_accounts` = @id", db.GetConnection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@sex", MySqlDbType.VarChar).Value = sex;
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
