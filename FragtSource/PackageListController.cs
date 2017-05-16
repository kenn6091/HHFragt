using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragtSource
{
    public class PackageListController
    {
        public Random rnd = new Random();
        public List<Package> packageList;

        public PackageListController()
        {
            packageList = new List<Package>();

            GenerateExamplePackages(50);
        }

        public List<Package> ReturnPackageList()
        {
            return packageList;
        }

        public void AddPackageToList(Package package)
        {
            Package largestId = new Package();
            if (packageList.Count > 0)
            {
                largestId = packageList.OrderByDescending(item => item.Id).First();
            }
            package.Id = largestId.Id + 1;
            packageList.Add(package);
        }

        public void DeletePackageById(int Id)
        {
            foreach (var package in packageList.ToList())
            {
                if (package.Id == Id)
                {
                    packageList.Remove(package);
                }
            }
        }

        public void DeletePackage(Package package)
        {
            DeletePackageById(package.Id);
        }

        private void GenerateExamplePackages(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AddPackageToList(GenerateRandomPackage());
            }
        }

        public Package GenerateRandomPackage()
        {
            Package randompackage = new Package();
            randompackage.Date = new DateTime(rnd.Next(1000, 9999), rnd.Next(1, 12), rnd.Next(1, 29),0,0,0);
            randompackage.Type = GenerateRandomType(rnd.Next(1, 4));
            randompackage.Country = GenerateRandomCountry(rnd.Next(1, 3));
            randompackage.Price = rnd.Next(1, 99).ToString();
            randompackage.Comment = "No comment";

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
