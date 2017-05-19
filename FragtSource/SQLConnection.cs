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

        public void InsertIntoFragt(Package package)
        {
            try
            {
                int price = 0;
                if (package.Price != "")
                    price = Convert.ToInt32(package.Price);
                MySql.Data.MySqlClient.MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO Fragt (`id`, `date`, `type`, `price`, `country`, `comment`) VALUES (" + package.Id + ", '" + package.Date.ToString("dd/MM/yyyy") + "', '" + package.Type + "', " + price + ", '" + package.Country + "', '" + package.Comment + "')";
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException errormessage)
            {
                Console.WriteLine("Exception: " + errormessage.Message);
            }
        }

        public void DeletePackageByID(int Id)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM Fragt WHERE  id=" + Id;
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException errormessage)
            {
                Console.WriteLine("Exception: " + errormessage.Message);
            }
        }

        public List<Package> updatelist()
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM Fragt", conn))
            {
                try
                {
                    List<Package> tempList = new List<Package>();
                    using (MySql.Data.MySqlClient.MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                            if (Reader.HasRows)
                        {
                            while (Reader.Read())
                            {
                                Package tempPackage = new Package();
                                tempPackage.Id = Convert.ToInt32(Reader["Id"]);
                                tempPackage.Date = Convert.ToDateTime(Reader["Date"]);
                                tempPackage.Type = Reader["Type"].ToString();
                                tempPackage.Country = Reader["Country"].ToString();
                                tempPackage.Price = Reader["Price"].ToString();
                                tempPackage.Comment = Reader["Comment"].ToString();
                                tempList.Add(tempPackage);
                            }
                        }
                    }
                    return tempList;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
