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

        public static List<Order> GetOrders()
        {           
            return DAL_IMP.GetOrderList();
        }
        public static List<User> GetUsers()
        {
            return DAL_IMP.GetUserList();
        }
        public static List<Product> GetProducts(List<Order> orders,Predicate<Order> predicate)
        {
            List<Product> products = new List<Product>();
            foreach (var order in orders)
            {
                if (predicate(order))
                {
                    foreach (var product in order.Products)
                    {
                        products.Add(product);
                    }
                }               
            }
            return products;
        }
        public static List<Category> GetCategories(List<Order> orders, Predicate<Order> predicate)
        {
            List<Category> categories = new List<Category>();
            foreach (var product in GetProducts(orders,predicate))
            {
                categories.Add(product.Cat);                 
            }
            return categories;
        }
        public static double GetPrice(List<Order> orders, Predicate<Order> predicate)
        {
            double price = 0;
            foreach (var product in GetProducts(orders, predicate))
            {
                price+= product.Price;
            }
            return price;
        }

    }
}
