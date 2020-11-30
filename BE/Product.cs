using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    // gabi
    public class Product
    {
        private Enums.Category category;
        private Store store;
        private int price;

        public Enums.Category Category  { get; set; }
        public Store Store { get; set; }  
        public int Price { get; set ; }   
    }
  }
