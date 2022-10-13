using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Data
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public List<Book> Books { get; set; }

    }
}
