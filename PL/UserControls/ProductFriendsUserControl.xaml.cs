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
using BE;
namespace PL
{
    /// <summary>
    /// Interaction logic for RecommendedListUserControl.xaml
    /// </summary>
    /// 
   
    public partial class ProductFriendsUserControl : UserControl
    {
        VM vm;
        public ProductFriendsUserControl()
        {
            vm = MainWindow.vm;
            InitializeComponent();
            Cbox.ItemsSource = Configuration.GlobalProducts.FindAll((p)=>p.Available).Select((p)=>p.Name);
        }

        private void Bton_Click(object sender, RoutedEventArgs e)
        {          
                string productName = Cbox.Text;
                listView.ItemsSource = vm.GetProductFriends(productName);            
        }
    }
}
