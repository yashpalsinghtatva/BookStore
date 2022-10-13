using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Address Address { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public User User { get; set; }
        public List<OrderBook> OrderBooks { get; set; }

    }
}
