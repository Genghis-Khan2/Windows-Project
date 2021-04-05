using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace PLTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            BL_IMP IBL = new BL_IMP();
            const string  path= @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\WindowsProject\Photos";


            //int id1= IBL.CreateNewProduct("Banana", 0.5, 1, "fruit", Category.Food, path + @"\Banana.JPG").Id;
            // int id2 = IBL.CreateNewProduct("Apple", 0.9, 1.5, "fruit", Category.Food, path + @"\Apple.JPG").Id;
            // int id3 = IBL.CreateNewProduct("Meat", 10, 1, "Non vegeterian", Category.Food).Id;
            // User ozi = IBL.AddUser(new User("ozi", "123"));
            //User yoni = IBL.AddUser(new User("yoni", "456"));
            //IBL.AddOrder(ozi, new Order(new List<int>() { id1,id2,id3 }, DateTime.Today));
            // User ozi1 = IBL.GetUser(1001);
            //IBL.CreateNewProduct("Banana", 0.5, 1, "fruit", Category.Food, path+ @"\Banana.JPG");
            //IBL.CreateNewProduct("Meat", 10, 1, "Non vegeterian", Category.Food);
            //IBL.RemoveOrder(ozi,IBL.GetOrder(ozi,1003));
            IBL.AddOrder(IBL.ConfirmUser("eitan","123"), new Order()
            {
                Date = DateTime.Today,
               ProductsIds= new List<int>() {1001,1002,1003 }

            });
            IBL.AddOrder(IBL.ConfirmUser("eitan", "123"), new Order()
            {
                Date = DateTime.Today,
                ProductsIds = new List<int>() { 1001, 1002 }

            });
            IBL.AddOrder(IBL.ConfirmUser("eitan", "123"), new Order()
            {
                Date = DateTime.Today,
                ProductsIds = new List<int>() { 1001, 1003 }

            });

            //List <Product> products = IBL.GetAllProducts(ozi,(o)=>o.Date== DateTime.MinValue);

            //IBL.CreateNewProduct("Banana",0.5,1,"fruit",Category.Food,null);
            List<Product> products = IBL.GetGlobalProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            IBL.SaveToPdf(products, DateTime.Now);

            /** drive and qr tests
            try
            {
                //BL_IMP.CreateQRCode(7889);
                //string fpath = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\WindowsProject\BL\photos";
                //fpath += @"\QR product " + 7889 + ".jpeg";
                //Console.WriteLine(BL_IMP.GetProductId(fpath));


                List<string> photosAdresses = BL_IMP.DownloadPhotosFromDrive();

                foreach (var photoAdress in photosAdresses)
                {
                    Console.WriteLine(BL_IMP.GetProductId(photoAdress));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            **/

            Console.ReadKey();
        }
    }
}
