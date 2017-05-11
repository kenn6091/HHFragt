using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    class PackageListController
    {
        public List<Package> packageList;

        public PackageListController()
        {
            packageList = new List<Package>();

            CreateExamplePackages(50);
        }

        public List<Package> ReturnPackageList()
        {
            return packageList;
        }

        private void CreateExamplePackages(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                packageList.Add(GenerateRandomPackage());
            }
        }

        private Package GenerateRandomPackage()
        {
            Random rnd = new Random();
            Package randompackage = new Package();

            randompackage.date = rnd.Next(10, 99) + "/" + rnd.Next(10, 99) + "/" + rnd.Next(1000, 9999);
            randompackage.type = GenerateRandomType(rnd.Next(1, 3));
            randompackage.country = GenerateRandomCountry(rnd.Next(1, 3));
            randompackage.price = rnd.Next(1, 99).ToString();
            randompackage.comment = "No comment";

            return randompackage;
        }

        private string GenerateRandomCountry(int number)
        {
            string country;
            switch (number)
            {
                case 1:
                    country = "NO";
                    break;
                case 2:
                    country = "SE";
                    break;
                case 3:
                    country = "DE";
                    break;
                default:
                    country = "DK";
                    break;
            }
            return country;
        }

        private string GenerateRandomType(int number)
        {
            string type;
            switch (number)
            {
                case 1:
                    type = "GLS";
                    break;

                case 2:
                    type = "U/Omdeling PostDanmark";
                    break;

                case 3:
                    type = "M/Omdeling PostDanmark";
                    break;
                default:
                    type = "Failed to generate random type";
                    break;
            }
            return type;
        }
    }
}
