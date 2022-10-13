using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressTitle { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }

    }
}
