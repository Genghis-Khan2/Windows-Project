using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        string name;
        string password;
        List<Order> orders;
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        internal List<Order> Orders { get => orders; set => orders = value; }
    }
}
