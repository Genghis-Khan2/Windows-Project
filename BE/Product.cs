using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BE
{

    public class Product
    {
        public Enums.Category Category  { get; set; }

        public Store Store { get; set; }

        public int Price { get; set ; }
    }
}
