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
    public class CartRepository : ICartRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public CartRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddBookToCartAsync(int userId, CartItemDTO cartItemDTO)
        {
            int cartId = 0;
            try
            {
                cartId = await getUserCartId(userId);
                if (cartId == 0)
                {
                    CartDTO cartDTO = new CartDTO();
                    cartDTO.CartDate = cartItemDTO.AddedDate;
                    cartDTO.CartTotal = cartItemDTO.BookTotal;
                    cartDTO.UserId = userId;
                    cartDTO.IsCartActive = true;

                    cartId = await CreateUserCart(cartDTO);
                }
                if (cartId > 0)
                {
                    cartItemDTO.CartId = cartId;
                    var cartItem = _mapper.Map<CartItem>(cartItemDTO);
                    _dbContext.CartItems.Add(cartItem);
                    await _dbContext.SaveChangesAsync();
                    return cartItemDTO.CartId;
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
        public async Task<CartDTO> GetAllCartBooksByUserIdAsync(int UserId)
        {
            try
            {
                var cart = await _dbContext.Carts.Where(x => x.UserId == UserId).Where(x=>x.IsCartActive ==true).Include(x => x.CartItems).FirstOrDefaultAsync();
                return _mapper.Map<CartDTO>(cart);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> getUserCartId(int UserId)
        {
            try
            {
                var userCart = await _dbContext.Carts.Where(x => x.UserId == UserId && x.IsCartActive == true).FirstOrDefaultAsync();
                if (userCart != null)
                {
                    return userCart.CartId;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
