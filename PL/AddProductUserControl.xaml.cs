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
    /// Interaction logic for AddProductUserControl.xaml
    /// </summary>
    public partial class AddProductUserControl : UserControl
    {
        Product product = new Product();
        public AddProductUserControl()
        {
            
            InitializeComponent();
            CategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
        }

        public void addButton_Click(object sender, RoutedEventArgs e)
        {
            extractDetails();
            ViewModel.IBL.CreateNewProduct(product);
        }

        void extractDetails()
        {
            product.Name = insertName.Text;
            product.Price =double.Parse(insertPrice.Text);
            product.Weight= double.Parse(insertWeight.Text);
            product.Cat= (Category)Enum.Parse(typeof(Category),CategoryComboBox.Text);
            product.Description = insertDescription.Text;
            product.Image_path = insertImage_path.Text;
        }
    }
}
