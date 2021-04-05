using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for RegularUser_UserControl.xaml
    /// </summary>
    public partial class Manager_UserControl : UserControl
    {
        VM vm;
        public Manager_UserControl()
        {
            vm = MainWindow.vm;
            InitializeComponent();            
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("are you sure you want to exit?", "exit",
         MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (result != MessageBoxResult.Yes)
                return;
            MessageBox.Show("Goodbye!", "exit",
         MessageBoxButton.OK, MessageBoxImage.Information);
            System.Windows.Application.Current.Shutdown();
        }
        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl && (e.Source as TabControl).SelectedIndex == 0)
            {
                 ObservableCollection<Product> Products = new ObservableCollection<Product>(Configuration.GlobalProducts);
                foreach (var product in Products)
                {
                    if (!vm.Products.Contains(product))
                    {
                        vm.Products.Add(product);
                    }
                }
            }
        }
    }
}
