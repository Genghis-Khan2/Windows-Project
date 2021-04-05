using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PL
{
    public partial class VM:BindableObject
    {
        
        public AddCommand<VM> AddProduct { get; set; }
        public RemoveCommand<VM> RemoveProduct { get; set; }
        public ObservableCollection<Product> Products = new ObservableCollection<Product>(Configuration.GlobalProducts);
        public ICommand ExitCommand { get; private set; }
        public void ManagerVMEntry()
        {
            //Products =  new ObservableCollection<Product>(Configuration.GlobalProducts);
            Products.CollectionChanged += Products_CollectionChanged;
            AddProduct = new AddCommand<VM>(this);
            RemoveProduct = new RemoveCommand<VM>(this);
            
            ExitCommand = CreateActionCommand(exit);
        }
       
        public static ICommand CreateActionCommand( Action action)
        {           
            return new RelayCommand
              (
                () => action()                
              ) ;
        }
        private void Products_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newData = e.NewItems[0] as Product;
                Configuration.GlobalProducts.Add(newData);
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var oldData = e.OldItems[0] as Product;
                Configuration.GlobalProducts.Remove(oldData);
            }

        }
        private void exit()
        {
            MessageBoxResult result = MessageBox.Show("are you sure you want to exit?", "exit",
         MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (result != MessageBoxResult.Yes)
                return;
            MessageBox.Show("Goodbye!", "exit",
         MessageBoxButton.OK, MessageBoxImage.Information);
            System.Windows.Application.Current.Shutdown();
        }

    }
}
