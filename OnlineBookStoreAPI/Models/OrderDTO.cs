using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public AddressDTO Address { get; set; }
        public ShippingMethodDTO ShippingMethod { get; set; }
        public int ShippingMethodId { get; set; }
        public string OrderStatus { get; set; }
        public List<int> BookIds { get; set; }

        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public string PhoneNumber { get; set; }
        public int Quantity { get; set; }
        public List<OrderBookDTO> orderBooks { get; set; }

    }
}
