using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FragtSource;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FragtSourceUnitTests
    {
        PackageListController _PackageListController;
        List<Package> packageList;
        Package examplePackage;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _PackageListController = new PackageListController();
            packageList = new List<Package>();
            examplePackage = new Package();

            _PackageListController.GenerateExamplePackages(20);
            examplePackage = _PackageListController.GenerateRandomPackage();
            _PackageListController.AddPackageToList(examplePackage);
            packageList = _PackageListController.ReturnPackageList();
        }

        [Test]
        public void AllPackagesHasUniqueIds()
        {
            bool duplicateIds = false;

            for (int package1IndexNumber = 0; package1IndexNumber < packageList.Count; package1IndexNumber++)
            {
                for (int package2IndexNumber = package1IndexNumber+1; package2IndexNumber < packageList.Count; package2IndexNumber++)
                {
                    if(packageList[package1IndexNumber].Id == packageList[package2IndexNumber].Id)
                    {
                        duplicateIds = true;
                        break;
                    }
                }
                if (duplicateIds)
                    break;
            }

            Assert.IsFalse(duplicateIds);
        }

        [Test]
        public void CanAddPackagesToList()
        {
            bool packageAddedToList = false;
            foreach (Package package in packageList)
            {
                if(examplePackage.Equals(package))
                {
                    packageAddedToList = true;
                    break;
                }
            }

            Assert.IsTrue(packageAddedToList);
        }

        [Test]
        public void CanDeletePackagesById()
        {
            //Since we know the list only contains 21 packages, and all Ids are unique, we know that all Ids are numbers from 1-21
            Random rnd = new Random();
            int randomId = rnd.Next(1, 21);
            bool packageExists = false;

            _PackageListController.DeletePackageById(randomId);
            packageList = _PackageListController.ReturnPackageList();

            foreach (Package package in packageList)
            {
                if (Convert.ToInt32(package.Id) == randomId)
                    packageExists = true;
            }

            Assert.IsFalse(packageExists);
        }

        [Test]
        public void CanDletePackagesByPackage()
        {
            //Since we know the list only contains 21 packages, and all Ids are unique, we know that all Ids are numbers from 1-21
            Random rnd = new Random();
            int randomId = rnd.Next(1, 21);
            bool packageExists = false;
            Package expectedPackageToBeDeleted = new Package();

            foreach (Package package in packageList)
            {
                if (Convert.ToInt32(package.Id) == randomId)
                    expectedPackageToBeDeleted = package;
            }

            _PackageListController.DeletePackage(expectedPackageToBeDeleted);
            packageList = _PackageListController.ReturnPackageList();

            foreach (Package package in packageList)
            {
                if (expectedPackageToBeDeleted.Equals(package))
                    packageExists = true;
            }

            Assert.IsFalse(packageExists);
        }
    }
}
