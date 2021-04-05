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
        VM vm;
        bool flag = true;
        Product Product=new Product();
        public ICommand AddProductCommand { get; private set; }
        public AddProductUserControl()
        {
            vm = MainWindow.vm;           
            InitializeComponent();
            CategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));         
        }
       

        public void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (extractDetails())
            {
                vm.IBL.CreateNewProduct(Product);
                reset();
            }

        }

        bool extractDetails()
        {
            bool flag = true;
            Product.Name =Checks.NameCheck(insertName, ref flag);
            Product.Price = Checks.DoubleCheck(insertPrice, "Price", ref flag);
            Product.Weight= Checks.DoubleCheck(insertWeight, "Weight", ref flag);
            Product.Cat = Checks.CategoryCheck(CategoryComboBox, ref flag);
            Product.Description = insertDescription.Text;
            Product.Image_path =Checks.ImagePathCheck(insertImage_path, ref flag);
            return flag;
        }
        void reset()
        {
            insertName.Text = "";
            insertPrice.Text = "";
            insertWeight.Text = "";
            CategoryComboBox.SelectedIndex = -1;
            insertDescription.Text = "";
            insertImage_path.Text = "";            
        }

       
    }
}
