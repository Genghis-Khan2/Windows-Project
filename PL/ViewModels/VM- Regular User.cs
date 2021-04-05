using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL
{
    public partial class VM 
    {
        private string header;
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                if (value != header)
                {
                    header = value;
                    OnPropertyChanged(() => Header);
                }
            }
        }

        private User _selectedUser;
        public User SelectedUser { get => _selectedUser; set => _selectedUser = value; }
        public Order orderToAdd { get; set; }

        public ICommand LoadOrder;

        public ObservableCollection<Order> Orders;
        public ObservableCollection<Product> NewOrderProducts= new ObservableCollection<Product>();
        public int Counter = 0;
        public void UserVMEntry()
        {
            Orders = new ObservableCollection<Order>(SelectedUser.Orders);
            orderToAdd = new Order();
            LoadOrder = CreateActionCommand(LoadNewOrder);
            Header ="Welcome "+ SelectedUser.Name+"!";
        }

        public void LoadNewOrder()
        {
            //orderToAdd.ProductsIds = IBL.LoadProducts();
            foreach (var id in IBL.LoadProducts())
            {
                if (id != -1 && !NewOrderProducts.Contains(Product.GetProductFromId(id)))
                    NewOrderProducts.Add(Product.GetProductFromId(id));
                else
                    Counter++;
            }
        }
        public void AddNewOrder()
        {
            foreach (var product in NewOrderProducts)
            {
                orderToAdd.ProductsIds.Add(product.Id);
            }
            orderToAdd.Date = DateTime.Now;
            IBL.AddOrder(SelectedUser, orderToAdd);
        }

        public List<Product> GetRecommendedList(DayOfWeek dayOfWeek)
        {           
             return IBL.GetRecommendedList(SelectedUser, (o) => o.Date.DayOfWeek == dayOfWeek);                  
        }
        public List<Product> GetProductFriends(string productName)
        {
            return IBL.GetProductFriends(Configuration.GlobalProducts.Find((p)=>p.Name== productName),SelectedUser);
        }




    }
}
