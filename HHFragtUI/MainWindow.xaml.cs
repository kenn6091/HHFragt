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
        Totals totalsData = new Totals();

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

        private void Btn_delete(object sender, RoutedEventArgs e)
        {
            Package selectedPackage = (Package)packageDatagrid.SelectedItems[0];
            PLC.DeletePackageById(selectedPackage.Id);
            CalculateTotals();
            packageDatagrid.Items.Refresh();
        }

        private List<Package> FetchPackageListFromController()
        {
            return PLC.ReturnPackageList();
        }

        private void Btn_search(object sender, RoutedEventArgs e) {
            packageList = FetchPackageListFromController().FindAll(
                delegate(Package pc) {
                    return pc.Date > Convert.ToDateTime(startDate.Text);
                }
            );
            packageList = packageList.FindAll(
                delegate (Package pc) {
                    return pc.Date < Convert.ToDateTime(endDate.Text);
                }
            );
            packageDatagrid.ItemsSource = packageList;
            CalculateTotals();
            packageDatagrid.Items.Refresh();
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

    public class Totals : DependencyObject
    {
        public static DependencyProperty
            GLSTotalsChangedProperty = DependencyProperty.
                Register("GLS", typeof(int), typeof(Totals),
                    new PropertyMetadata(0, GLSTotalsChanged));

        private static void GLSTotalsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ok");
        }

        public int GLS
        {
            get
            {
                return (int)GetValue(Totals.GLSTotalsChangedProperty);
            }
            set
            {
                SetValue(Totals.GLSTotalsChangedProperty, value);
            }
        }

        public static DependencyProperty
            UOmdelingChangedProperty = DependencyProperty
            .Register("UOmdeling", typeof(int), typeof(Totals),
            new PropertyMetadata(0, UOmdelingChanged));

        private static void UOmdelingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ok");
        }

        public int UOmdeling
        {
            get
            {
                return (int)GetValue(Totals.UOmdelingChangedProperty);
            }
            set
            {
                SetValue(Totals.UOmdelingChangedProperty, value);
            }
        }

        public static DependencyProperty
            MOmdelingChangedProperty = DependencyProperty
            .Register("MOmdeling", typeof(int), typeof(Totals),
                new PropertyMetadata(0, MOmdelingChanged));

        private static void MOmdelingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ok");
        }

        public int MOmdeling
        {
            get
            {
                return (int)GetValue(Totals.MOmdelingChangedProperty);
            }
            set
            {
                SetValue(Totals.MOmdelingChangedProperty, value);
            }
        }
    }
}