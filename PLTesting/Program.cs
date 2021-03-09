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
            const string  path= @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\Windows-Project\Photos";
            // IBL.CreateNewProduct("Banana", 0.5, 1, "fruit", Category.Food, null);
            //User ozi = IBL.AddUser(new User("ozi", "123"));
            //User yoni = IBL.AddUser(new User("yoni", "456"));
            // IBL.AddOrder(ozi, new Order(new List<int>() { 1001 }, DateTime.MinValue));
            // User ozi1 = IBL.GetUser(1001);
            //IBL.CreateNewProduct("Banana", 0.5, 1, "fruit", Category.Food, path+ @"\Banana.JPG");
            IBL.CreateNewProduct("Meat", 10, 1, "Non vegeterian", Category.Food);
            //IBL.RemoveOrder(ozi,IBL.GetOrder(ozi,1003));
            //IBL.AddOrder(ozi, new Order()
            //{
            //    Date = DateTime.MinValue,


            //});

            //List <Product> products = IBL.GetAllProducts(ozi,(o)=>o.Date== DateTime.MinValue);

            //IBL.CreateNewProduct("Banana",0.5,1,"fruit",Category.Food,null);
            List<Product> products = IBL.GetGlobalProducts();



            /** drive and qr tests
            try
            {
                //BL_IMP.CreateQRCode(7889);
                //string fpath = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\Windows-Project\BL\photos";
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
