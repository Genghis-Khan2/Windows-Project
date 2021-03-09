using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        int id = Configuration.THIS_KEY_DID_NOT_INITALIZED_YET;
        string name="";
        string password="";
        List<Order> orders=new List<Order>();
        public int Id { get => id; set => id = value; }
        public List<Order> Orders { get => orders; set => orders = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public static void Copy(User target, User source)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Password = source.Password;
            target.Orders = source.Orders;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&                  
                   Id == user.Id;
        }
    }

    
}
