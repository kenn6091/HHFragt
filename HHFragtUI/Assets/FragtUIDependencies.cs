using System;
using System.Windows;

namespace HHFragtUI.Assets {
    public class FragtUIDependencies : DependencyObject
    {
        public static DependencyProperty
            GLSTotalsChangedProperty = DependencyProperty.
                Register("GLS", typeof(int), typeof(FragtUIDependencies),
                    new PropertyMetadata(0, GLSTotalsChanged));

        private static void GLSTotalsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ok");
        }

        public int GLS
        {
            get
            {
                return (int)GetValue(FragtUIDependencies.GLSTotalsChangedProperty);
            }
            set
            {
                SetValue(FragtUIDependencies.GLSTotalsChangedProperty, value);
            }
        }

        public static DependencyProperty
            UOmdelingChangedProperty = DependencyProperty
            .Register("UOmdeling", typeof(int), typeof(FragtUIDependencies),
            new PropertyMetadata(0, UOmdelingChanged));

        private static void UOmdelingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ok");
        }

        public int UOmdeling
        {
            get
            {
                return (int)GetValue(FragtUIDependencies.UOmdelingChangedProperty);
            }
            set
            {
                SetValue(FragtUIDependencies.UOmdelingChangedProperty, value);
            }
        }

        public static DependencyProperty
            MOmdelingChangedProperty = DependencyProperty
            .Register("MOmdeling", typeof(int), typeof(FragtUIDependencies),
                new PropertyMetadata(0, MOmdelingChanged));

        private static void MOmdelingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("ok");
        }

        public int MOmdeling
        {
            get
            {
                return (int)GetValue(FragtUIDependencies.MOmdelingChangedProperty);
            }
            set
            {
                SetValue(FragtUIDependencies.MOmdelingChangedProperty, value);
            }
        }

        public static DependencyProperty
            BrevChangedProperty = DependencyProperty
            .Register("Brev", typeof(int), typeof(FragtUIDependencies),
                new PropertyMetadata(0, BrevChanged));

        private static void BrevChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public int Brev
        {
            get
            {
                return (int)GetValue(FragtUIDependencies.BrevChangedProperty);
            }
            set
            {
                SetValue(FragtUIDependencies.BrevChangedProperty, value);
            }
        }
    }
}
