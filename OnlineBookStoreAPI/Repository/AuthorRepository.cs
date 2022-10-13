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
    public class AuthorRepository  : IAuthorRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;


        public AuthorRepository(BookStoreContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<AuthorDTO>> GetAllAuthorAsync()
        {
            var authors = await _dbContext.Authors.ToListAsync();

            return _mapper.Map<List<AuthorDTO>>(authors);
        }
        public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
        {
            var author = await _dbContext.Authors.Where(x => x.AuthorId == id).FirstOrDefaultAsync();

            return _mapper.Map<AuthorDTO>(author);
        }
        public async Task<int> AddAuthorAsync(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            _dbContext.Add(author);
            await _dbContext.SaveChangesAsync();
            return author.AuthorId;
        }
        public async Task<int> UpdateAuthorAsync(int authorId, AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            author.AuthorId = authorId;
            _dbContext.Authors.Update(author);
             await _dbContext.SaveChangesAsync();
            return authorId;
            //var book = await _dbContext.Books.FindAsync(bookId);
            //if (book != null)
            //{

            //    book.Description = bookModel.Description;
            //    book.Title = bookModel.Title;

            //    await _dbContext.SaveChangesAsync();
            //}
        }
        public async Task<int> DeleteAuthorAsync(int authorId)
        {
            var author = new Author()
            {
                AuthorId = authorId
            };

            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
            return authorId;
        }
    }
}
