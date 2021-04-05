using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using BE;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class DAL_IMP
    {

        static readonly string users_path = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\WindowsProject\Users.txt";       
        static readonly string products_path = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\WindowsProject\Products.txt";
        static readonly string configs_path = @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\WindowsProject\Configs.txt";
        //static readonly string users_path = @"..\..\.\..\..\..\..\Users";
        //static readonly string users_path = @".\Users";
        private static List<User> users;

        public DAL_IMP()
        {
            users = Load<List<User>>(users_path);
            Configuration.GlobalProducts = Load<List<Product>>(products_path);           
            List<int> configs = StartUp(Load<List<int>>(configs_path));
            Configuration.UserSerialKey = configs[0];
            Configuration.OrderSerialKey = configs[1];
            Configuration.ProductSerialKey = configs[2];
        }

        ~DAL_IMP()
        {
            Save(users_path, users);
            Save(products_path, Configuration.GlobalProducts);
            Save(configs_path, MakeConfigList(Configuration.UserSerialKey,
                Configuration.OrderSerialKey, Configuration.ProductSerialKey));
        }

        private static T Load<T>(string path)
        {
            if (!File.Exists(path))
                return default;
            try
            {
                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (T)serializer.Deserialize(file, typeof(T));
                }
            }
            catch (Exception)
            {
                return default;
            }            
        }

        private static void Save<T>(string path, T toSave)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                file.Write(JsonConvert.SerializeObject(toSave, Formatting.Indented));
                //serializer.Serialize(file, JsonConvert.SerializeObject(toSave, Formatting.Indented));
            }
        }

        //accures only in the first run of the program
        private static List<int> StartUp(List<int> configs)
        {
            if (users==null)
                users= new List<User>();
            if (Configuration.GlobalProducts == null)
                Configuration.GlobalProducts = new List<Product>();
            if (configs==null)
            {
                configs = new List<int>() {
                Configuration.THIS_KEY_DID_NOT_INITALIZED_YET,
                Configuration.THIS_KEY_DID_NOT_INITALIZED_YET,
                Configuration.THIS_KEY_DID_NOT_INITALIZED_YET
                };
                 
            }
            return configs;
        }
        
        private static List<int> MakeConfigList(params int[] configs)
        {
            List<int> configList = new List<int>();
            foreach (int config in configs)
            {
                configList.Add(config);
            }
            return configList;
        }

        public User GetUser(int id)
        {
            return users.Find((u) => u.Id == id);
        }
        public Order GetOrder(User user, int id)
        {
            return user.Orders.Find((o) => o.Id == id);
        }
        public List<User> GetUserList()
        {
            return users;
        }

        public void AddUser(User user)
        {          
            if (!users.Contains(user))
                users.Add(user);
            else
                throw new ArgumentException("user already exist");
        }
        public void RemoveUser(User user)
        {
            if (!users.Remove(user))
                throw new ArgumentException("user not exist");

        }
        public void UpdateUser(User user)
        {
            if (!users.Contains(user))
                throw new ArgumentException("user not exist");
            else
            {
                RemoveUser(GetUser(user.Id));
                AddUser(user);
            }
        }

        public void AddOrder(User user, Order order)
        {
            if (!users.Contains(user))
                throw new ArgumentException("user not exist");
            else
            {
                user.Orders.Add(order);
                UpdateUser(user);
            }
        }
        public void RemoveOrder(User user, Order order)
        {
            if (!users.Contains(user))
                throw new ArgumentException("user not exist");
            if (!user.Orders.Contains(order))
                throw new ArgumentException("order not exist");
            user.Orders.Remove(order);
            UpdateUser(user);
        }
        public void UpdateOrder(User user, Order order)
        {
            if (!users.Contains(user))
                throw new ArgumentException("user not exist");
            if (!user.Orders.Contains(order))
                throw new ArgumentException("order not exist");
            user.Orders.Remove(GetOrder(user, order.Id));
            user.Orders.Add(order);
            UpdateUser(user);
        }


        public static List<User> LoadUserList()
        {
            using (StreamReader file = File.OpenText(users_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<User>)serializer.Deserialize(file, typeof(List<User>));
            }
        }
        public static void SaveUserList()
        {
            using (StreamWriter file = File.CreateText(users_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, users);
            }
        }
        public static List<Product> GetProductList()
        {
            using (StreamReader file = File.OpenText(users_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<Product>)serializer.Deserialize(file, typeof(List<Product>));
            }
        }
    }
}
