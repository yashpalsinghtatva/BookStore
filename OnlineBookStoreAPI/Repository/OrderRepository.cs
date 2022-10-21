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
            var currentTransaction = _dbContext.Database.BeginTransaction();
            try
            {
                var order = _mapper.Map<Order>(orderDTO);
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
                foreach (var orderedBookId in orderDTO.BookIds)
                {
                    OrderBook orderBook = new OrderBook();
                    orderBook.BookId = orderedBookId;
                    orderBook.OrderId = order.OrderId;
                    orderBook.Quantity = orderDTO.Quantity;
                    _dbContext.OrderBooks.Add(orderBook);

                    Book book = _dbContext.Books.FirstOrDefault(book => book.BookId == orderedBookId);
                    if (book != null)
                    {
                        book.NumberOfBooks -= book.NumberOfBooks - orderDTO.Quantity;
                    }
                }
                await _dbContext.SaveChangesAsync();
                currentTransaction.Commit();
                return order.OrderId;
            }
            catch (Exception ex)
            {
                currentTransaction.Rollback();
                throw ex;
            }
        }

        public async Task<int> CancelOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
            order.OrderStatus = "C";
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
            return orderId;
        }

        public async Task<int> DeleteOrderAsync(int orderId)
        {
            var order = new Order()
            {
                OrderId = orderId
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

        public async Task<List<OrderHistoryDTO>> GetAllOrdersByUserIdAsync(int userId)
        {
            var orders = await _dbContext.Orders.Where(x => x.UserId == userId).Include(x => x.OrderBooks).ThenInclude(x => x.Book).Include(x => x.ShippingMethod).ToListAsync();
            List<OrderHistoryDTO> previousOrders = new List<OrderHistoryDTO>();
            foreach (var order in orders)
            {
                OrderHistoryDTO orderHistory = new OrderHistoryDTO();
                orderHistory.Books = new List<BookDTO>();
                foreach (var currentOrderBooks in order.OrderBooks)
                {
                    BookDTO book = _mapper.Map<BookDTO>(currentOrderBooks.Book);
                    book.OrderedBookQuantity = currentOrderBooks.Quantity;
                    orderHistory.Books.Add(book);
                }
                orderHistory.OrderId = order.OrderId;
                orderHistory.OrderDate = order.OrderDate;
                orderHistory.OrderStatus = order.OrderStatus;
                orderHistory.Total = order.Total;

                previousOrders.Add(orderHistory);
            }
            return previousOrders;
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
