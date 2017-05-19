using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FragtSource;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Run();
        }

        private void Run()
        {
            SQLConnection sqlcon = new SQLConnection();

            while (true)
            {
                string input = System.Console.ReadLine();

                switch (input)
                {
                    case "login":
                        sqlcon.LogIn();
                        break;
                    case "logout":
                        sqlcon.LogOut();
                        break;
                    case "loggedin":
                        if(sqlcon.LoggedIn())
                            System.Console.WriteLine("You are logged in");
                        else
                            System.Console.WriteLine("you are logged out");
                        break;
                    case "insert":
                        Package package = new Package();
                        PackageListController PLC = new PackageListController();
                        package = PLC.GenerateRandomPackage();
                        sqlcon.InsertIntoFragt(package);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
