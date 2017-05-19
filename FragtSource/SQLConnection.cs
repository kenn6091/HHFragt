using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    public class SQLConnection
    {
        private static string connectionstring = "server=web80.meebox.net; Database=dalumblk_Blaekpriser; User Id=dalumblk_kennethdorn; Password=123456;";
        MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();

        public void LogIn()
        {
            try
            {
                conn.ConnectionString = connectionstring;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException errormessage)
            {
                Console.WriteLine("Error when logging in: " + errormessage);
            }
        }

        public void LogOut()
        {
            try
            {
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException errormessage)
            {
                Console.WriteLine("Error when logging out: " + errormessage);
            }
        }

        public bool LoggedIn()
        {
            if (conn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertIntoFragt()
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO Fragt (`id`, `date`) VALUES(10, 'test')";
                command.ExecuteNonQuery();
            }
            catch(MySql.Data.MySqlClient.MySqlException errormessage)
            {
                Console.WriteLine("Exception: " + errormessage.Message);
            }
        }
    }
}
