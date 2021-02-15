using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Order
    {
        List<Product> products;
        DateTime date;
        
        public List<Product> Products { get => products; set => products = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
