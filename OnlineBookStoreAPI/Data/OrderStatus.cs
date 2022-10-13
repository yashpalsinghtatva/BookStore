using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string OrderStatusValue { get; set; }
        public List<Order> Orders { get; set; }
    }
}
