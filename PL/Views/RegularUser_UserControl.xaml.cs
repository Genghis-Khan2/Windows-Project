﻿using BE;
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
    public partial class RegularUser_UserControl : UserControl
    {
        VM vm;
        public RegularUser_UserControl()
        {
            vm = MainWindow.vm;
            InitializeComponent();           
            DataContext = vm;
        }
        
    }
}
