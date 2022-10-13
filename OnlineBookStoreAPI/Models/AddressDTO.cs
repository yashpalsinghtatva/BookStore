using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public string AddressTitle { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public CountryDTO Country { get; set; }
        public int CountryId { get; set; }
    }
}
