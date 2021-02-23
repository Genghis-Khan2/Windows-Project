using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using System.IO;
using BE;

namespace DAL
{
    public class DAL_IMP
    {
        static string user_path = @".\Users";
        static string product_path = @".\Products";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public static List<User> GetUserList()
        {
            using (StreamReader sr = new StreamReader(user_path))
            {
                if (sr.Peek() != -1) // If the file is not empty
                {
                    List<User> user_list = (List<User>)JsonSerializer.Deserialize(sr.ReadToEnd(), typeof(List<User>));
                    return user_list;
                }
            }

            return new List<User>();
        }
        public static List<Product> GetProductList()
        {
            using (StreamReader sr = new StreamReader(product_path))
            {
                if (sr.Peek() != -1) // If the file is not empty
                {
                    List<Product> product_list = (List<Product>)JsonSerializer.Deserialize(sr.ReadToEnd(), typeof(List<Product>));
                    return product_list;
                }
            }

            return new List<Product>();
        }
        public static List<Order> GetOrderList(User user)
        {
            return null;
        }
        public void AddUser(User user)
        {
            int i = 0;
            string json_string1 = JsonSerializer.Serialize(i, options);
            string json_string = JsonSerializer.Serialize(user, options);

            using (StreamWriter sw = new StreamWriter(user_path))
            {
                sw.WriteLine(json_string);
            }
        }
    }
}
