using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookDTO>> GetAllBookAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookDTO author);
        Task<int> UpdateBookAsync(int authorId, BookDTO author);
        Task<int> DeleteBookAsync(int authorId);
    }
}
