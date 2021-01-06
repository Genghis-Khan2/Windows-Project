using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BL
{
    public interface IBL
    {
       
        public static string getResult()
        {
            return "result is:" + IDAL.getValue();
        }
    }
}
