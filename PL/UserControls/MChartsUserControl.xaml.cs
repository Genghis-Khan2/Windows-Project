using BE;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Interaction logic for ChartsUserControl.xaml
    /// </summary>
    /// 
    public partial class MChartsUserControl : UserControl
    {
        public ObservableCollection<Product> Products { get; set; }
        LiveCharts.SeriesCollection series = new LiveCharts.SeriesCollection();
        public MChartsUserControl()
        {
            Products = new ObservableCollection<Product>(Configuration.GlobalProducts);
            InitializeComponent();
            series = new LiveCharts.SeriesCollection();
            var vals = new ChartValues<ObservableValue>();

            DetailcomboBox.ItemsSource = new List<string>() { "Price", "Weight", "Category" };
            //ChartcomboBox.ItemsSource = new List<string>() { "Pie", "Dounts", "Lines" };            
        }

        private void DetailcomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (DetailcomboBox.SelectedIndex)
            {
                case 0:
                    {
                        series = new SeriesCollection();
                        foreach (var product in Products)
                        {
                            series.Add(new PieSeries
                            {
                                Title = product.Name,
                                Values = new ChartValues<ObservableValue> { new ObservableValue(product.Price) },
                                DataLabels = true
                            });
                        }
                        break;
                    }
                case 1:
                    {
                        series = new SeriesCollection();
                        foreach (var product in Products)
                        {
                            series.Add(new PieSeries
                            {
                                Title = product.Name,
                                Values = new ChartValues<ObservableValue> { new ObservableValue(product.Weight) },
                                DataLabels = true
                            });
                        }
                        break;
                    }
                case 2:
                    {
                        series = new SeriesCollection();
                        series.Add(new PieSeries
                        {
                            Title = "Food",
                            Values = new ChartValues<ObservableValue> {
                                new ObservableValue(Products.ToList().FindAll((p)=>p.Cat==Category.Food).Count) },
                            DataLabels = true
                        });
                        series.Add(new PieSeries
                        {
                            Title = "Clothes",
                            Values = new ChartValues<ObservableValue> {
                                new ObservableValue(Products.ToList().FindAll((p)=>p.Cat==Category.Clothes).Count) },
                            DataLabels = true
                        });
                        series.Add(new PieSeries
                        {
                            Title = "Communication",
                            Values = new ChartValues<ObservableValue> {
                                new ObservableValue(Products.ToList().FindAll((p)=>p.Cat==Category.Electrics).Count) },
                            DataLabels = true
                        });
                        series.Add(new PieSeries
                        {
                            Title = "Weapons",
                            Values = new ChartValues<ObservableValue> {
                                new ObservableValue(Products.ToList().FindAll((p)=>p.Cat==Category.Weapons).Count) },
                            DataLabels = true
                        });

                        break;
                    }
                default:
                    return;
            }

            Chart.Series = series;
        }
    }
}
