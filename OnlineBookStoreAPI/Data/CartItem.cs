using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public DateTime AddedDate { get; set; }
        public int BookQuanitity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal BookPrice { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal BookTotal { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
