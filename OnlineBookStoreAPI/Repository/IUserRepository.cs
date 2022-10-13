using OnlineBookStoreAPI.Helpers;
using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface IUserRepository
    {
        //Task<List<UserDTO>> GetAllAsync();
        //Task<AuthorDTO> GetAuthorByIdAsync(int id);
        //Task<int> UpdateAuthorAsync(int authorId, AuthorDTO author);
        //Task<int> DeleteAuthorAsync(int authorId);
        Task<int> AddAuthorAsync(UserDTO user);
        Task<Tokens> Authenticate(UserDTO user);
        Task<bool> CheckUserEmailExist(UserDTO user);
    }
}
