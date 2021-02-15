using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Product
    {
        string name;
        double price;
        double weight;
        int id;

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Id { get => id; set => id = value; }
    }
}
