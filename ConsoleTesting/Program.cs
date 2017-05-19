using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FragtSource;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.run();
        }

        private void run()
        {
            SQLConnection sqlcon = new SQLConnection();
            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "login":
                        sqlcon.LogIn();
                        break;
                    case "logout":
                        sqlcon.LogOut();
                        break;
                    case "loggedin":
                        if (sqlcon.LoggedIn())
                            Console.WriteLine("You are logged in.");
                        else
                            Console.WriteLine("You are not logged in.");
                        break;
                    default:
                        Console.WriteLine("login, logout, loggedin");
                        break;
                }
            }
        }
    }
}
