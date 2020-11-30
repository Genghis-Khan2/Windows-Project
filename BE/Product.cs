using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BE
{

    public class Product
    {
        private Enums.Category category;

        private Store store;

        private int price;

        public Enums.Category Category  { get; set; }

        public Store Store { get; set; }  

        public int Price { get; set ; }
    }
    public class Store
    {
        
    }
    public class Costumer
    {
        string name;
        string password;
        public string Name { get; set; }
        public string Password { get ; set; }      
    }
}
