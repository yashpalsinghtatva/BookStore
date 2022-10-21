using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class Cart
    {
        public int CartId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime CartDate { get; set; }
        public bool IsCartActive { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal CartTotal{ get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
