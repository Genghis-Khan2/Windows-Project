using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    class BL_IMP : IBL
    {
        IDAL DAL = FactoryDal.GetInstance();
        public string getResult()
        {
            return "hello, " + DAL.getValue();
        }
    }
}
