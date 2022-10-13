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
    public class ShippingMethodRepository : IShippingMethodRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;


        public ShippingMethodRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddShippingMethodAsync(ShippingMethodDTO shippingMethodDTO)
        {
            var shippingMethod = _mapper.Map<ShippingMethod>(shippingMethodDTO);
            _dbContext.Add(shippingMethod);
            await _dbContext.SaveChangesAsync();
            return shippingMethodDTO.ShippingMethodId;

        }

        public async Task<int> DeleteShippingMethodAsync(int shippingMethodId)
        {
            var shippingMethod = new ShippingMethod()
            {
                ShippingMethodId = shippingMethodId
            };

            _dbContext.ShippingMethods.Remove(shippingMethod);
            await _dbContext.SaveChangesAsync();
            return shippingMethodId;
        }

        public async Task<List<ShippingMethodDTO>> GetAllShippingMethodsAsync()
        {
            var shippingMethods = await _dbContext.ShippingMethods.ToListAsync();
            return _mapper.Map<List<ShippingMethodDTO>>(shippingMethods);

        }

        public async Task<ShippingMethodDTO> GetShippingMethodByIdAsync(int id)
        {
            var shippingMethod = await _dbContext.ShippingMethods.Where(x => x.ShippingMethodId== id).FirstOrDefaultAsync();
            return _mapper.Map<ShippingMethodDTO>(shippingMethod);

        }

        public async Task<int> UpdateShippingMethodAsync(int shippingMethodId, ShippingMethodDTO shippingMethodDTO)
        {
            var shippingMethod = _mapper.Map<ShippingMethod>(shippingMethodDTO);
            shippingMethod.ShippingMethodId = shippingMethodId;
            _dbContext.ShippingMethods.Update(shippingMethod);
            await _dbContext.SaveChangesAsync();
            return shippingMethodId;

        }
    }
}
