using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class FactoryDal
    {       
        protected static IDAL instance = null;
        public static IDAL GetInstance() 
        {
            if (instance == null) 
                instance = new JSONDAL();
            return instance;
        }
    }
}
