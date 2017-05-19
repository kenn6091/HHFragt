using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource {
    public class DBcon {

        //har prøvet * server=web80.meebox.net,3306 * & * server=web80.meebox.net:3306 * & * server=web80.meebox.net; port=3306; *
        //det er den første der burde virke...  den kommer til catch når man undlader at tilføje * ,3306 * alt andet crasher afik... QQ
        private static string connectioString = "server=tcp:77.66.117.80;Database=dalumblk_Blaekpriser;User Id=dalumblk_kennethdorn;Password=123456;";

        public void DatabaseUpdate(List<Package>Packages) {

            //?? Data Source = tcp:<host name>,<TCP/IP port number>  https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring(v=vs.110).aspx
            // prøvede den her stringbuilder da det var forslået * DataSource = @"web80.meebox.net,3306 * 
            //virker ikke selvom det er sådan det er skrevet alle steder.

            var stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.IntegratedSecurity = false;
            stringBuilder.InitialCatalog = "dalumblk_Blaekpriser";
            stringBuilder.DataSource = "tcp:77.66.117.80,3306";//@"web80.meebox.net,3306";
            // web80.meebox.net = 77.66.117.80 testet med heidisql virker!  http://whatmyip.co/view/hosts/9117/meebox_net.html
            stringBuilder.Password = "123456";
            stringBuilder.UserID = "dalumblk_kennethdorn";

            using (SqlConnection con = new SqlConnection(connectioString /*stringBuilder.ToString()*/)) {
                try {
                    // SÆT BREAKPOINT AND GET PAST THIS POINT PLZ ved ik om resten virker men string sp som ik er udkommenteret har jeg testet direkte i Heidisql og det virker
                    con.Open();



                    //SqlTransaction trans = con.BeginTransaction();

                    //foreach (Package package in Packages) {
                        string sp = "INSERT INTO Fragt (`id`, `date`) VALUES(10, 'test')"; //"INSERT INTO Fragt (`id`, `date`, `type`, `price`, `country`, `comment`) VALUES (10, `05-10-2016`, `GLS`, 30, `NO`, ``)"
                        using (SqlCommand command = new SqlCommand(sp))

                        try {
                            command.ExecuteNonQuery();
                        } catch (Exception e) {
                            Console.WriteLine("Exception: " + e.Message);
                            Console.WriteLine();
                        }
                    //}
                    //trans.Commit();
                    con.Close();

                } catch (SqlException e) {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}
