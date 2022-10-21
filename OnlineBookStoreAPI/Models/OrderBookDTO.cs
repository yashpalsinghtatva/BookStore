using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class OrderBookDTO
    {
        public int OrderBookId { get; set; }
        public int BookId { get; set; }
        public BookDTO Book { get; set; }
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public int Quantity { get; set; }

    }
}
