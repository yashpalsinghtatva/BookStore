using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class OrderHistoryDTO
    {
        public int OrderId { get; set; }
        public List<BookDTO> Books { get; set; }
        //public string BookName{ get; set; }
        //public string BookISBN{ get; set; }
        public string OrderStatus { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public int BookQuantity { get; set; }
    }
}
