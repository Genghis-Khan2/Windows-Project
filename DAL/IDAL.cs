using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace DAL
{
    public interface IDAL
    {
        public void AddProduct(Product prod);
        public void AddCustomer(Customer cust);

        public void AddStore(Store store);

        public string getValue();
        
    }
}
