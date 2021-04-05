using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using BE;
namespace PL
{
    /// <summary>
    /// Interaction logic for AddOrderUserControl.xaml
    /// </summary>
    /// 
    public partial class AddNewOrder : UserControl
    {
        VM vm;

        public AddNewOrder()
        {
            vm = MainWindow.vm;
            InitializeComponent();
            loadGrid.Visibility = Visibility.Collapsed;
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {

            contentDock.Visibility = Visibility.Collapsed;
            loadGrid.Visibility = Visibility.Visible;

            Task.Run(() =>
            {
                vm.LoadNewOrder();
            }).ContinueWith((Task task) =>
            {
                Dispatcher.Invoke(() =>
                {
                    contentDock.Visibility = Visibility.Visible;
                    loadGrid.Visibility = Visibility.Collapsed;
                    LoadOrder();
                    if (vm.NewOrderProducts.Count == 0)
                        MessageBox.Show("There are no photos in the file");
                });
            });
            
        }
        private void LoadOrder()
        {
            if (vm.NewOrderProducts.Count != 0)
            {
                listView.ItemsSource = vm.NewOrderProducts.Distinct() ;
                loadButton.Click += addButton_Click;
                loadButton.Content = "Add the new order ";
            }            
            
            if (vm.Counter != 0)
                missProductText.Text = "There are " + vm.Counter + " products missing";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AddNewOrder();
        }
    }
}
