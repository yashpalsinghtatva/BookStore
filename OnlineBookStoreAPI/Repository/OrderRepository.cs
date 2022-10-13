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
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddOrderAsync(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync();
            return orderDTO.OrderId;
        }

       public async Task<int> DeleteOrderAsync(int orderId)
        {
            var order = new Order()
            {
                OrderId= orderId
            };
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return orderId;
        }

        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _dbContext.Orders.Where(x => x.OrderId == id).FirstOrDefaultAsync();
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<int> UpdateOrderAsync(int orderId, OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order.OrderId = orderId;
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
            return orderId;

        }
    }
}
