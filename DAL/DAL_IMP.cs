using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using BE;

namespace DAL
{
    public class DAL_IMP
    {
        static readonly string user_path = @".\Users";
        static readonly string product_path = @".\Products";

        public static List<User> GetUserList()
        {
            using (StreamReader file = File.OpenText(user_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<User>)serializer.Deserialize(file, typeof(List<User>));
            }
        }

        public static void AddUser(User user)
        {
            List<User> users = GetUserList();
            users.Add(user);
            using (StreamWriter file = File.CreateText(user_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, users);
            }
        }

        public static void RemoveUser(User user)
        {
            List<User> users = GetUserList();
            users.Remove(user);
            using (StreamWriter file = File.CreateText(user_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, users);
            }
        }

        public static List<Product> GetProductList()
        {
            using (StreamReader file = File.OpenText(user_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<Product>)serializer.Deserialize(file, typeof(List<Product>));
            }
        }
    }
}
