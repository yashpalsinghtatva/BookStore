using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface ICartRepository
    {
        Task<List<CartDTO>> GetAllCartBooksByUserIdAsync(int UserId);
        Task<int> AddBookToCartAsync(CartDTO cart);
       
    }
}
