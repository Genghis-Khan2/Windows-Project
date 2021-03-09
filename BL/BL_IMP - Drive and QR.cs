using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using System.Net;
using System.Net.Http;
using BE;
using DAL;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BL
{
    public partial class BL_IMP
    {

        //static string[] Scopes = { DriveService.Scope.Drive };
        //static string ApplicationName = "does it matter";

        static string  fpath = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\Windows-Project\BL\Drive Photos";
        public static int GetProductId(string QRCodeAdress)
        {
            int resultId = -1;
            try
            {
                BarcodeReader<Bitmap> reader = new BarcodeReader
                {
                    AutoRotate = true,
                    TryInverted = true,
                    Options = new DecodingOptions { TryHarder = true }
                };
                Bitmap temp = new Bitmap(QRCodeAdress);
                Bitmap barcodeBitmap = new Bitmap(temp);
                temp.Dispose();
                //File.SetAttributes(photoAdress, FileAttributes.Normal);
                //File.Delete(photoAdress);
                Result result = reader.Decode(barcodeBitmap);
                if (result == null)
                    throw new NoQRExceptoin(@"the current picture has no QR code inside, please snap again");
                string decoded = result.ToString().Trim();
                resultId = int.Parse(decoded);
            }
            catch (NoQRExceptoin e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return resultId;
        }
        public static string CreateQRCode(int id)
        {
            string path = Configuration.QRCode_file_path + @"\QR product " + id + ".jpeg";
            if (File.Exists(path))
                return path;
            var myFile = File.Create(path);
            BarcodeWriter writer = new ZXing.BarcodeWriter
            {
                Options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 100,
                    Height = 100,
                },
                Format = ZXing.BarcodeFormat.QR_CODE
            };
            var result = new Bitmap(writer.Write(id.ToString()));
            //PictureBox pictureBox = new PictureBox();
            //pictureBox.Image = result;

            result.Save(myFile, ImageFormat.Jpeg);
            //pictureBox.Image.Save(myFile, ImageFormat.Jpeg);
            myFile.Dispose();
            myFile.Close();
            return path;
        }
        public static List<string> DownloadPhotosFromDrive()
        {           
            UserCredential credential = GetCredentials();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "",
            });
            string projectFileId = FindTheProjectFileID(service);
            return PhotosDealer(service, projectFileId);
        }
        static string FindTheProjectFileID(DriveService service)
        {
            FilesResource.ListRequest fileRequest = service.Files.List();
            // Define parameters of request.
            fileRequest.PageSize = 100;
            fileRequest.Fields = "files(mimeType, id, name, parents)";
            fileRequest.Q = @"name contains 'project photos'
            and mimeType = 'application/vnd.google-apps.folder' and trashed = false";
            IList<Google.Apis.Drive.v3.Data.File> files = fileRequest.Execute().Files;
            if (files != null && files.Count == 1)
                return files.First().Id;
            else
                return null;
        }
        static List<string> PhotosDealer(DriveService service, string fileId)
        {
            List<string> photosAdresses = new List<string>();
            FilesResource.ListRequest photoRequest = service.Files.List();
            // Define parameters of request.
            photoRequest.PageSize = 1000;
            photoRequest.Fields = "files(mimeType, id, name, parents)";
            photoRequest.Q = string.Format("('{0}' in parents) and mimeType='image/jpeg' and trashed = false", fileId);
            IList<Google.Apis.Drive.v3.Data.File> photos = photoRequest.Execute().Files;
            int counter = 0;
            string photoPath;
            foreach (var photo in photos)
            {
                counter++;
                Console.WriteLine("{0}: {1} \n", photo.Name, photo.Id);
                FileStream fstream = File.Create(photoPath = fpath + @"\product" + counter + ".jpeg");
                service.Files.Get(photo.Id).Download(fstream);
                photosAdresses.Add(photoPath);
                service.Files.Delete(photo.Id).Execute();
                fstream.Dispose();
                fstream.Close();
            }
            return photosAdresses;
            //return null;
        }
       
       private static UserCredential GetCredentials()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentialsDrive.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string[] Scopes = { DriveService.Scope.Drive };
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }
    }
}
