using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class CartItemDTO
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public CartDTO Cart { get; set; }
        public DateTime AddedDate { get; set; }
        public int BookQuanitity { get; set; }
        public decimal BookPrice { get; set; }
        public decimal BookTotal { get; set; }
        public BookDTO Book { get; set; }
        public int BookId { get; set; }
    }
}
