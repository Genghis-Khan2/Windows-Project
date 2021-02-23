using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Configuration
    {
        private static long productSerialKey = THIS_KEY_DID_NOT_INITALIZED_YET;//serial key of a product
        private static long userSerialKey = THIS_KEY_DID_NOT_INITALIZED_YET;//serial key of a user
        private static long orderSerialKey = THIS_KEY_DID_NOT_INITALIZED_YET;//serial key of an order       
        //public static float GlobalCommission = (float)0.1;//the commission of the website owner

        private static List<Product> globalProducts = new List<Product>();

        public const long THIS_KEY_DID_NOT_INITALIZED_YET = 1000;//the Initial value of the serial keys

        public static long ProductSerialKey { get => productSerialKey; set => productSerialKey = value; }
        public static long UserSerialKey { get => userSerialKey; set => userSerialKey = value; }
        public static long OrderSerialKey { get => orderSerialKey; set => orderSerialKey = value; }
        public static List<Product> GlobalProducts { get => globalProducts; set => globalProducts = value; }
        //gets and sets functions of the class variables       
    }
}
