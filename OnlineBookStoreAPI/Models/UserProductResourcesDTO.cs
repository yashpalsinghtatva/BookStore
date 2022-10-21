using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class UserProductResourcesDTO
    {
        public List<LanguageDTO> Languages { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
