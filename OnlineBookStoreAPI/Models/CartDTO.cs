using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public DateTime CartDate { get; set; }
        public bool IsCartActive { get; set; }
      
        public decimal CartTotal { get; set; }
        //public List<CartItem> CartItems { get; set; }
    }
}
