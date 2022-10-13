using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class ShippingMethod
    {
        public int ShippingMethodId { get; set; }
        public string ShippingMethodName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
