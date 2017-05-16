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
using System.Data;

namespace HHFragtUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window {
        public List<Package> packageList = new List<Package>();
        public PackageListController PLC = new PackageListController();

        public MainWindow()
        {
            packageList = FetchPackageListFromController();

            InitializeComponent();

            packageDatagrid.ItemsSource = packageList;
        }

        private void Btn_gem(object sender, RoutedEventArgs e)
        {
            Package tempPackage = new Package();
            tempPackage.Date = Convert.ToDateTime(UdkastDate.Text);
            tempPackage.Type = UdkastType.Text;
            tempPackage.Country = UdkastCountry.Text;
            tempPackage.Price = UdkastPrice.Text;
            tempPackage.Comment = UdkastComment.Text;
            
            PLC.AddPackageToList(tempPackage);
            packageDatagrid.Items.Refresh();
        }

        private void Btn_delete(object sender, RoutedEventArgs e)
        {
            Package selectedPackage = (Package)packageDatagrid.SelectedItems[0];
            PLC.DeletePackageById(selectedPackage.Id);
            packageDatagrid.Items.Refresh();
        }

        private List<Package> FetchPackageListFromController()
        {
            return PLC.ReturnPackageList();
        }

        private void Btn_search(object sender, RoutedEventArgs e) {
            packageList = packageList.FindAll(
                delegate(Package pc) {
                    return pc.Date < new DateTime(Convert.ToInt32(startDate.Text));
                }); 
            packageDatagrid.Items.Refresh();
        }
    }
}