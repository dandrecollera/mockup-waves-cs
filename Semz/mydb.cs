using System.Data;
using MySql.Data.MySqlClient;


namespace Semz
{
    class mydb
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; username = root; password = password; database = waves_schema");


        public MySqlConnection GetConnection
        {
            get
            {
                return con;
            }
        }

        public void openConnection()
        {
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}