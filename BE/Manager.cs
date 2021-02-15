using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Manager: User
    {
        string password;

        public string Password { get => password; set => password = value; }
    }
}
