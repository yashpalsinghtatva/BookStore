using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookStoreAPI.Data
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Book> authorBooks { get; set; }
    }
}
