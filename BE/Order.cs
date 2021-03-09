using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        int id = Configuration.THIS_KEY_DID_NOT_INITALIZED_YET;
        List<int> productsIds = new List<int>();
        DateTime date= DateTime.MinValue;

        public int Id { get => id; set => id = value; }

        //list of the products ids, the whole products are in the config class (catalog)
        public List<int> ProductsIds { get => productsIds; set => productsIds = value; }
        public DateTime Date { get => date; set => date = value; }

        public Order(List<int> productsIds, DateTime date)
        {
            ProductsIds = productsIds;
            Date = date;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&                   
                   Id == order.Id;
        }
    }
}
