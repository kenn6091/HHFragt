using System;
using System.Collections.Generic;
using System.Linq;

namespace FragtSource {
    public class PackageListController
    {
        public Random rnd = new Random();
        private List<Package> packageList;
        SQLConnection sqlcon = new SQLConnection();

        public PackageListController()
        {
            packageList = new List<Package>();

            sqlcon.LogIn();
            packageList = sqlcon.updatelist();
            sqlcon.LogOut();

            //GenerateExamplePackages(50);
        }

        public List<Package> ReturnPackageList()
        {
            return packageList;
        }

        public void AddPackageToList(Package package)
        {
            Package largestId = new Package();
            if (packageList != null && packageList.Count > 0)
            {
                largestId = packageList.OrderByDescending(item => item.Id).First();
            }
            package.Id = largestId.Id + 1;
            packageList.Add(package);

            sqlcon.LogIn();
            sqlcon.InsertIntoFragt(package);
            sqlcon.LogOut();
        }

        public void DeletePackageById(int Id)
        {
            foreach (var package in packageList.ToList())
            {
                if (package.Id == Id)
                {
                    packageList.Remove(package);
                    break;
                }
            }

            sqlcon.LogIn();
            sqlcon.DeletePackageByID(Id);
            sqlcon.LogOut();
        }

        public void DeletePackage(Package package)
        {
            DeletePackageById(package.Id);
        }

        public void GenerateExamplePackages(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AddPackageToList(GenerateRandomPackage());
            }
        }

        public Package GenerateRandomPackage()
        {
            Package randompackage = new Package()
            {
                Date = new DateTime(rnd.Next(2000, 2017), rnd.Next(1, 12), rnd.Next(1, 29), 0, 0, 0),
                Type = GenerateRandomType(rnd.Next(1, 4)),
                Country = GenerateRandomCountry(rnd.Next(1, 5)),
                Price = rnd.Next(1, 99).ToString()
            };
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
                    country = "";
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
                case 4:
                    type = "Brev";
                    break;
                default:
                    type = "Failed to generate random type";
                    break;
            }
            return type;
        }
    }
}
