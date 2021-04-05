﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    /// Interaction logic for AddOrderUserControl.xaml
    /// </summary>
    /// 
    public partial class ProductCatalogUserControl : UserControl
    {
        VM vm;
        public ObservableCollection<Product> Products;
        public ProductCatalogUserControl()
        {
            vm = MainWindow.vm;
            InitializeComponent();
            listView.ItemsSource =vm.Products;
        }       
    }
}