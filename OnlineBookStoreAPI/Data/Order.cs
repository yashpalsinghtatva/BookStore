using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int ShippingMethodId { get; set; }

        public User User { get; set; }
        public List<OrderBook> OrderBooks { get; set; }
        public string OrderStatus { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }

    }
}
