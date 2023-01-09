using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreAPI.Models;
using OnlineBookStoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCartItemsByUser()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var cartItems = await _cartRepository.GetAllCartBooksByUserIdAsync(userId);
                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });
            }
        }
        [HttpPost("")]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItemDTO cartItemDTO)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                int Id = await _cartRepository.AddBookToCartAsync(userId, cartItemDTO);
                cartItemDTO.CartId = Id;
                return Ok(cartItemDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });
            }
        }
    }
}
