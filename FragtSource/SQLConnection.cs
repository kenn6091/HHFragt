using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    public class SQLConnection
    {
        private static string connectionstring;
        MySql.Data.MySqlClient.MySqlConnection conn;

        public SQLConnection()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection();
                connectionstring = GetDatabaseInformation();
        }

        private string GetDatabaseInformation()
        {
            string connectionstring;
            //string path = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Connectionstring.txt";
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Connectionstring.txt");
            connectionstring = File.ReadAllText(path, Encoding.UTF8);
            return connectionstring;
        }

        public void InsertIntoFragt(Package package)
        {
            conn.ConnectionString = connectionstring;
            conn.Open();

            int price = 0;
            if (package.Price != "")
                price = Convert.ToInt32(package.Price);
            MySql.Data.MySqlClient.MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Fragt (`id`, `date`, `type`, `price`, `country`, `comment`) VALUES (" 
                + package.Id + ", '" 
                + package.Date.ToString("dd/MM/yyyy") + "', '" 
                + package.Type + "', " 
                + price + ", '" 
                + package.Country + "', '" 
                + package.Comment + "')";
            command.ExecuteNonQuery();

            conn.Close();
        }

        public void DeletePackageByID(int Id)
        {
            conn.ConnectionString = connectionstring;
            conn.Open();

            MySql.Data.MySqlClient.MySqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM Fragt WHERE  id=" + Id;
            command.ExecuteNonQuery();

            conn.Close();
        }

        public List<Package> Updatelist()
        {
            conn.ConnectionString = connectionstring;
            conn.Open();

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
                    conn.Close();
                    return tempList;
                }
                catch
                {
                    conn.Close();
                    return null;
                }
            }            
        }
    }
}
