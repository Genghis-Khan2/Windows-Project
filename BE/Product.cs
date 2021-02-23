using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BE
{
    public enum Category
    {
        Food,Clothes,Comm,Weapons
    }
    public class Product
    {
        string name;
        double price;
        double weight;
        string description;
        int id;
        Category cat;
        Image image;
        Image qr_code;
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Id { get => id; set => id = value; }
        public Category Cat { get => cat; set => cat = value; }
        public Image Image { get => image; set => image = value; }
        public Image Qr_code { get => qr_code; set => qr_code = value; }
        public string Description { get => description; set => description = value; }

        public static Product GetProductFromId(int id)
        {
            foreach (Product prod in Configuration.GlobalProducts)
            {
                if (prod.Id == id)
                    return prod;
            }
            return null;
        }
    }
}
