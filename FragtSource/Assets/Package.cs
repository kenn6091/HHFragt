using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    public class Package
    {
        private int Id { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Price { get; set; }
        public string Comment { get; set; }

        public Package()
        {
            Country = "";
            Price = "";
            Comment = "";
        }
    }
}
