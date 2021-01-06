using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace DAL
{
    public interface IDAL
    {
        public static void AddProduct(Product prod) { }
        public static void AddCustomer(Customer cust) { }

        public static void AddStore(Store store) { }

        public static string getValue()
        {
            return "dal send this value";
        }
    }
}
