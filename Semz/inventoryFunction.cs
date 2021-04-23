using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Semz
{
    class inventoryFunction
    {
        mydb db = new mydb();
        public DataTable getInventory(MySqlCommand command)
        {
            command.Connection = db.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public bool deleteInventory(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `inventory` WHERE `id_inventory` = @id", db.GetConnection);
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

        public bool insertInventory(string item, int stock, double price, string type)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `inventory`(`item`, `stock`, `price`, `type`) VALUE (@item, @stock, @price, @type)", db.GetConnection);

            command.Parameters.Add("@item", MySqlDbType.VarChar).Value = item;
            command.Parameters.Add("@stock", MySqlDbType.Int32).Value = stock;
            command.Parameters.Add("@price", MySqlDbType.Double).Value = price;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;

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

        public bool updateInventory(int id, string item, int stock, double price, string type)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `inventory` SET `item` = @item, `stock` = @stock, `price` = @price, `type` = @type WHERE `id_inventory` = @id", db.GetConnection);
            command.Parameters.Add("@item", MySqlDbType.VarChar).Value = item;
            command.Parameters.Add("@stock", MySqlDbType.Int32).Value = stock;
            command.Parameters.Add("@price", MySqlDbType.Double).Value = price;
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
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
