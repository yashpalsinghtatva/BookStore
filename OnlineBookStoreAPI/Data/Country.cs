using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public  List<Address> Addresses { get; set; }
    }

}
