using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    
    public  class FactoryBl
    {
        

        protected static IBL instance = null;
        public static IBL GetInstance()
        {
            //if (instance == null)
            //    instance = new JSONDAL();
            return instance;
        }
    }
}
