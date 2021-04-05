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
        Food,Clothes,Electrics,Weapons
    }
    public class Product
    {
        string name = "";
        double price = 0;
        double weight = 0;
        string description = "";
        int id= Configuration.THIS_KEY_DID_NOT_INITALIZED_YET;
        Category cat;
        string image_path = "";
        string qr_code_path = "";
        bool available = true;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public double Weight { get => weight; set => weight = value; }        
        public Category Cat { get => cat; set => cat = value; }
        public string Description { get => description; set => description = value; }
        public string Image_path { get => image_path; set => image_path = value; }
        public string Qr_code_path { get => qr_code_path; set => qr_code_path = value; }
        public bool Available { get => available; set => available = value; }

        public static Product GetProductFromId(int id)
        {           
            return Configuration.GlobalProducts.Find((p)=>p.Id==id);
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&                   
                   Id == product.Id;
        }

        public override string ToString()
        {
            string name = "Product name: " + Name;
            string price = " , price: " + Price;
            string weight = " , weight: " + Weight;
            string category = " , from category: " + Cat.ToString();
            string description = " , product description: " + Description+".\n";
            string isAvailable="";
            if (available)
                isAvailable = "The product is currently available in the store";
            else
                isAvailable = "The product is currently not available";
            return name+price+weight+category+description+isAvailable;
        }
    }
}
