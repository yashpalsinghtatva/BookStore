using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface IShippingMethodRepository
    {
        Task<List<ShippingMethodDTO>> GetAllShippingMethodsAsync();
        Task<ShippingMethodDTO> GetShippingMethodByIdAsync(int id);
        Task<int> AddShippingMethodAsync(ShippingMethodDTO shippingMethodDTO);
        Task<int> UpdateShippingMethodAsync(int shippingMethodId, ShippingMethodDTO shippingMethodDTO);
        Task<int> DeleteShippingMethodAsync(int shippingMethodId);
    }
}
