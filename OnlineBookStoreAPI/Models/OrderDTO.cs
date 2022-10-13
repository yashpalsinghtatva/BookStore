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
        public UserDTO User { get; set; }
        public int UserId { get; set; }

    }
}
