using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace Semz
{
    
    class reportsFunctions
    {
        mydb db = new mydb();

        public bool deleteReports(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `reports` WHERE `id_reports` = @id", db.GetConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
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

        public DataTable getReport(MySqlCommand command)
        {
            command.Connection = db.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
           
        }

        public bool insertReport(string title, string author, string report)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `reports`(`report_title`, `author`, `report`) VALUE(@title, @author, @report)", db.GetConnection);
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            command.Parameters.Add("@author", MySqlDbType.VarChar).Value = author;
            command.Parameters.Add("@report", MySqlDbType.LongText).Value = report;
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

        public bool updateReport(int id, string title , string author, string report)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `reports` SET `report_title` = @title, `author` = @author, `report` = @report WHERE `id_reports` = @id", db.GetConnection);
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            command.Parameters.Add("@author", MySqlDbType.VarChar).Value = author;
            command.Parameters.Add("@report", MySqlDbType.LongText).Value = report;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
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
