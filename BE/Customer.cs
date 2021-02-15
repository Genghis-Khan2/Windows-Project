using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Customer
    {
        string name;
        string password;
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
    }
}
