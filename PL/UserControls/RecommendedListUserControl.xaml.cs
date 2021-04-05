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
using BE;
using PdfSharp.Pdf;

namespace PL
{
    /// <summary>
    /// Interaction logic for RecommendedListUserControl.xaml
    /// </summary>
    /// 
    public enum Days
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday,  Friday ,Saturday 
    }
    public partial class RecommendedListUserControl : UserControl
    {
        ObservableCollection<Product> recommandedProducts=null;
        PdfDocument pdf = new PdfDocument();
        VM vm;
        public RecommendedListUserControl()
        {
            vm = MainWindow.vm;
            InitializeComponent();
            Cbox.ItemsSource = Enum.GetValues(typeof(DayOfWeek));

        }

        private void Bton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listView.ItemsSource = null;
                if (Cbox.SelectedIndex == -1)
                    Cbox.Text = DateTime.Today.DayOfWeek.ToString();
                 DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Cbox.Text);
                recommandedProducts =new ObservableCollection<Product>(vm.GetRecommendedList(day));
                if(recommandedProducts.Count!=0)
                listView.ItemsSource = recommandedProducts;
                else
                    MessageBox.Show("There are no recommanded products");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        private void pdfBton_Click(object sender, RoutedEventArgs e)
        {
            if (!(recommandedProducts==null)&& recommandedProducts.Count!=0)
            { 
                vm.IBL.SaveToPdf(recommandedProducts.ToList(), DateTime.Now);
                recommandedProducts = null;
                listView.ItemsSource = recommandedProducts;
                Cbox.SelectedIndex = -1;
                Cbox.Text= "Choose day of the week";

            }
           
            else
                MessageBox.Show("There are no recommanded products");

        }

        
    }
}
