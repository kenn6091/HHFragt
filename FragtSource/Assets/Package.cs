using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    public class Package
    {
        public string date { get; set; }
        public string type { get; set; }
        public string country { get; set; }
        public string price { get; set; }
        public string comment { get; set; }
        private int Id { get; set; }

        public Package()
        {
            country = "";
            price = "";
            comment = "";
        }
    }
}
