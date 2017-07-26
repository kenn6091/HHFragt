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
            
            packageList = sqlcon.Updatelist();
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
            
            sqlcon.InsertIntoFragt(package);
        }

        public void DeletePackageById(int Id)
        {
            foreach (var package in packageList.ToList())
            {
                if (package.Id == Id){
                    packageList.Remove(package);
                    break;
                }
            }
            sqlcon.DeletePackageByID(Id);
        }

        public void DeletePackage(Package package){
            DeletePackageById(package.Id);
        }
    }
}
