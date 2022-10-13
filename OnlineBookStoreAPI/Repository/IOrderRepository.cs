using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task<int> AddOrderAsync(OrderDTO orderDTO);
        Task<int> UpdateOrderAsync(int orderId, OrderDTO orderDTO);
        Task<int> DeleteOrderAsync(int orderId);
    }
}
