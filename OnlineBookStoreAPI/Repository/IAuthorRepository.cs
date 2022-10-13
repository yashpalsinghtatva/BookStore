using OnlineBookStoreAPI.Data;
using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface IAuthorRepository 
    {
        Task<List<AuthorDTO>> GetAllAuthorAsync();
        Task<AuthorDTO> GetAuthorByIdAsync(int id);
        Task<int> AddAuthorAsync(AuthorDTO author);
        Task<int> UpdateAuthorAsync(int authorId, AuthorDTO author);
        Task<int> DeleteAuthorAsync(int authorId);
    }
}
