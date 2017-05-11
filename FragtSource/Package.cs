using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    public class Package
    {
        public string dato { get; set; }
        public string type { get; set; }
        public string udland { get; set; }
        public string pris { get; set; }
        public string kommentar { get; set; }

        public Package()
        {
            udland = "";
            pris = "";
            kommentar = "";
        }
    }
}
