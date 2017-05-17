using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FragtSource;
using HHFragtUI.Assets;
using System.Data;

namespace HHFragtUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        public List<Package> packageList = new List<Package>();
        public PackageListController PLC = new PackageListController();
        FragtUIDependencies totalsData = new FragtUIDependencies();

        public int GLSCalculated, MOmdelingCalculated, UOmdelingCalculated;


        public MainWindow()
        {
            packageList = FetchPackageListFromController();

            InitializeComponent();

            packageDatagrid.ItemsSource = packageList;

            this.DataContext = totalsData;
            CalculateTotals();
        }

        private void Btn_gem(object sender, RoutedEventArgs e)
        {
            try
            {
                Package tempPackage = new Package();
                tempPackage.Date = Convert.ToDateTime(DatoInput.Text);
                tempPackage.Type = UdkastType.Text;
                tempPackage.Country = UdkastCountry.Text;
                tempPackage.Price = UdkastPrice.Text;
                tempPackage.Comment = UdkastComment.Text;

                PLC.AddPackageToList(tempPackage);
                CalculateTotals();
                packageDatagrid.Items.Refresh();
            }
            catch(Exception exception)
            {
                MessageBoxResult result = MessageBox.Show("Der opstod et problem med at gemme filen. \n\n" + exception, "Error!");
            }
        }

        private void Btn_delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Package selectedPackage = (Package)packageDatagrid.SelectedItems[0];
                PLC.DeletePackageById(selectedPackage.Id);
                CalculateTotals();
                packageDatagrid.Items.Refresh();
            }
            catch(Exception exception)
            {
                MessageBoxResult result = MessageBox.Show("Der opstod et problem med at slette pakken. \n\n" + exception, "Error!");
            }
        }

        private List<Package> FetchPackageListFromController()
        {
            return PLC.ReturnPackageList();
        }

        private void Btn_print(object sender, RoutedEventArgs e)
        {
            try
            {
                Print print = new Print();
                print.Printall(packageList);
                MessageBoxResult result = MessageBox.Show("Listen af pakker blev gemt i filen Print.csv på dit skrivebord.", "Print");
            }
            catch(Exception exception)
            {
                MessageBoxResult result = MessageBox.Show("Der opstod et problem ved oprettelse af filen. \n\n" + exception, "Error!");
            }
        }

        private void Btn_search(object sender, RoutedEventArgs e)
        {
            try
            {
                packageList = FetchPackageListFromController().FindAll(
                    delegate (Package pc)
                    {
                        return pc.Date > Convert.ToDateTime(startDate.Text);
                    }
                );
                packageList = packageList.FindAll(
                    delegate (Package pc)
                    {
                        return pc.Date < Convert.ToDateTime(endDate.Text);
                    }
                );
                packageDatagrid.ItemsSource = packageList;
                CalculateTotals();
                packageDatagrid.Items.Refresh();
            }
            catch(Exception exception)
            {
                MessageBoxResult result = MessageBox.Show("Kunne ikke søge inden for de givene datoer. \n\n" + exception, "Error!");
            }
        }

        private void CalculateTotals()
        {
            GLSCalculated = 0;
            UOmdelingCalculated = 0;
            MOmdelingCalculated = 0;

            foreach (var package in packageList)
            {
                if (package.Type == "GLS")
                {
                    GLSCalculated++;
                }
                else if (package.Type == "U/Omdeling PostDanmark")
                {
                    UOmdelingCalculated++;
                }
                else if (package.Type == "M/Omdeling PostDanmark")
                {
                    MOmdelingCalculated++;
                }
            }

            totalsData.GLS = GLSCalculated;
            totalsData.UOmdeling = UOmdelingCalculated;
            totalsData.MOmdeling = MOmdelingCalculated;
        }
    }
}