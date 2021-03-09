using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Configuration
    {
        private static int productSerialKey = THIS_KEY_DID_NOT_INITALIZED_YET;//serial key of a product
        private static int userSerialKey = THIS_KEY_DID_NOT_INITALIZED_YET;//serial key of a user
        private static int orderSerialKey = THIS_KEY_DID_NOT_INITALIZED_YET;//serial key of an order       
        //public static float GlobalCommission = (float)0.1;//the commission of the website owner
        

        private static List<Product> globalProducts = new List<Product>();

        public const int THIS_KEY_DID_NOT_INITALIZED_YET = 1000;//the Initial value of the serial keys
        public const string Photos_file_path = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\Windows-Project\Photos";
        public const string QRCode_file_path = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\Windows-Project\QR Codes";
        public static int ProductSerialKey { get => productSerialKey; set => productSerialKey = value; }
        public static int UserSerialKey { get => userSerialKey; set => userSerialKey = value; }
        public static int OrderSerialKey { get => orderSerialKey; set => orderSerialKey = value; }
        public static List<Product> GlobalProducts { get => globalProducts; set => globalProducts = value; }
        //gets and sets functions of the class variables       
    }
}
