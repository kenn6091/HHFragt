using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    class PackageListContainer
    {
        List<Package> packageList = new List<Package>();

        public PackageListContainer()
        {
            CreateExamplePackages();
        }

        private void CreateExamplePackages()
        {
            Package package1 = new Package();
            package1.dato = "01/01/2017";
        }
    }
}
