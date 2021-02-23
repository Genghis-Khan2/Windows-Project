using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BL
{
    public partial class BL_IMP 
    {
        DAL_IMP IDAL = new DAL_IMP();
        //public static List<Order> GetOrders(User user)
        //{           
        //    return user.Orders;
        //}

        public static List<User> GetUsers()
        {
            return DAL_IMP.GetUserList();
        }
        public static List<Product> GetAllProducts(User user,Predicate<Order> predicate)
        {
            List<Order> orders = user.Orders;
            List<Product> products = new List<Product>();
            foreach (var order in orders)
            {
                if (predicate(order))
                {
                    foreach (var product in order.Products)
                    {
                        if (!products.Contains(product))
                            products.Add(product);
                    }
                }               
            }
            return products;
        }
        public static List<Category> GetAllCategories(User user, Predicate<Order> predicate)
        {
            List<Category> categories = new List<Category>();
            foreach (var product in GetAllProducts(user, predicate))
            {
                categories.Add(product.Cat);                 
            }
            return categories;
        }
        public static double GetTotalPrice(User user, Predicate<Order> predicate)
        {
            double price = 0;
            foreach (var product in GetAllProducts(user, predicate))
            {
                price+= product.Price;
            }
            return price;
        }

        public void AddUser(User user)
        {
            //IDAL.AddUser(user);
            throw new NotImplementedException();
        }
        public void AddOrder(User user,Order order)
        {
            foreach(var product in order.Products)
            {
                if (!Configuration.GlobalProducts.Contains(product))
                    Configuration.GlobalProducts.Add(product);
            }
            throw new NotImplementedException();
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }
        public bool RemoveOrder(User user, Order order)
        {
            throw new NotImplementedException();
        }

        // add update?

    }
}
