using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Models
{
    public class BookResourcesDTO
    {
        public List<AuthorDTO> Authors { get; set; }
        public List<LanguageDTO> Languages { get; set; }
        public List<PublisherDTO> Publishers { get; set; }
    }
}
