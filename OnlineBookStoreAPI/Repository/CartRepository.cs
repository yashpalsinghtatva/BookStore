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
    public class CartRepository :ICartRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public CartRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddBookToCartAsync(CartDTO cartDTO)
        {
            try
            {
                if (! await CheckCartExist(cartDTO.UserId))
                {
                    int cartId = await CreateUserCart(cartDTO);
                    if(cartId > 0)
                    {
                        //to be continued..
                        var cart = _mapper.Map<Cart>(cartDTO);
                        _dbContext.Carts.Add(cart);
                        await _dbContext.SaveChangesAsync();
                        return cart.CartId;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> CreateUserCart(CartDTO cartDTO)
        {
            try
            {
                var cart = _mapper.Map<Cart>(cartDTO);
                _dbContext.Carts.Add(cart);
                await _dbContext.SaveChangesAsync();
                return cart.CartId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<List<CartDTO>> GetAllCartBooksByUserIdAsync(int UserId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> CheckCartExist(int UserId)
        {
            try
            {
                var userCart =  await _dbContext.Carts.Where(x => x.UserId == UserId && x.IsCartActive == true).FirstOrDefaultAsync();
                if (userCart != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
