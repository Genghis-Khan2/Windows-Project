using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace PL
{
    public class HarvestPasswordEventArgs : EventArgs
    {
        public string Password;
    }

    public class SelectUserEventArgs : EventArgs
    {
        public User user;
    }
}
