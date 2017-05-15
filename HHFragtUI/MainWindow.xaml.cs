using System;
using System.Collections.Generic;
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

namespace HHFragtUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:Window
    {
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
            PLC.packageList.Add(PLC.GenerateRandomPackage());
            packageList = FetchPackageListFromController();
            packageDatagrid.ItemsSource = packageList;
            packageDatagrid.Items.Refresh();
        }

        private void Btn_delete(object sender, RoutedEventArgs e)
        {
            string firstCellValue = packageDatagrid.SelectedCells[0].Item.ToString();
        }

        private List<Package> FetchPackageListFromController()
        {
            return PLC.ReturnPackageList();
        }
    }
}
