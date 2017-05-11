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
        PackageListController PLC;

        public MainWindow()
        {
            PLC = new PackageListController();
            List<Package> packageList = new List<Package>();
            packageList = FetchPackageListFromController();

            InitializeComponent();

            packageDatagrid.ItemsSource = packageList;
        }

        private void Btn_gem(object sender, RoutedEventArgs e)
        {
            
        }

        private List<Package> FetchPackageListFromController()
        {
            return PLC.ReturnPackageList();
        }
    }
}
