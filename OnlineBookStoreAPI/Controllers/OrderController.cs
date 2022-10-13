using Microsoft.AspNetCore.Authorization;
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
    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                int Id = await _orderRepository.AddOrderAsync(orderDTO);
                orderDTO.OrderId = Id;
                return CreatedAtAction(nameof(GetOrderById), new { id = Id, controller = "order" }, orderDTO);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] OrderDTO order)
        {
            var result = await _orderRepository.UpdateOrderAsync(id, order);
            if (result > 0)
            {
                order.OrderId = id;
                return Ok(order);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var result = await _orderRepository.DeleteOrderAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
