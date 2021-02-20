using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PLTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            BL_IMP IBL = new BL_IMP();

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
            
            Console.ReadKey();
        }
    }
}
