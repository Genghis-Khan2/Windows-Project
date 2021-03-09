using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL
{
    public class ManagerVM:BindableObject
    {
        ViewModel viewModel;
        public AddCommand<ManagerVM> AddProduct { get; set; }
        public RemoveCommand<ManagerVM> RemoveProduct { get; set; }
        public  ObservableCollection<Product>  Products { get; set; }
        public Product productToAdd { get; set; }
        public ICommand DisconnectCommand { get; private set; }
        public ManagerVM(ViewModel _viewModel)
        {
            viewModel = _viewModel;
            Products =new ObservableCollection<Product>(Configuration.GlobalProducts);
            Products.CollectionChanged += Products_CollectionChanged;
            AddProduct = new AddCommand<ManagerVM>(this);
            RemoveProduct = new RemoveCommand<ManagerVM>(this);
            DisconnectCommand = viewModel.StateMachine.CreateCommand(Triggers.Disconnect);
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

    }
}
