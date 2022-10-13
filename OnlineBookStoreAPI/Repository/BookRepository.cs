using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreAPI.Data;
using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddBookAsync(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _dbContext.Books.Add(book);
             await _dbContext.SaveChangesAsync();
            return book.BookId;
        }

        public async Task<int> DeleteBookAsync(int bookId)
        {
            Book book = new Book()
            {
                BookId = bookId
            };
            _dbContext.Books.Remove(book);
           return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BookDTO>> GetAllBookAsync()
        {
            //var books = await _dbContext.Books.Select(x => new BookDTO()
            //{
            //    BookId = x.BookId,
            //    BookDescription = x.BookDescription,
            //    BookPrice =x.BookPrice,
            //    BookTitle= x.BookTitle,
            //    ISBN = x.ISBN,
            //    Author = x.Author
            //}).ToListAsync();
            var books = await _dbContext.Books.Include(x=>x.Author).Include(x => x.Language).Include(x => x.Publisher).ToListAsync();

            return _mapper.Map<List<BookDTO>>(books);

        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _dbContext.Books.AsNoTracking().Include(x=>x.Author).Where(x=>x.BookId == id).FirstOrDefaultAsync();
            return _mapper.Map<BookDTO>(book);

        }

        public async Task<int> UpdateBookAsync(int bookID, BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            book.BookId = bookID;
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return bookID;

        }
    }
}
