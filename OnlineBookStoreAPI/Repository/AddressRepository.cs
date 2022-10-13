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
    public class AddressRepository : IAddressRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public AddressRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddAddressAsync(AddressDTO addressDTO)
        {
            var address = _mapper.Map<AddressDTO>(addressDTO);
            _dbContext.Add(address);
            await _dbContext.SaveChangesAsync();
            return addressDTO.AddressId;
        }

        public async Task<int> DeleteAddressAsync(int addressID)
        {
            var address = new Address()
            {
                AddressId = addressID
            };

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
            return addressID;
        }

        public async Task<AddressDTO> GetAddressByIdAsync(int AddressId)
        {
            var address = await _dbContext.Addresses.Where(x => x.AddressId == AddressId).FirstOrDefaultAsync();
            return _mapper.Map<AddressDTO>(address);

        }

        public async Task<List<AddressDTO>> GetAllAddressesAsync()
        {
            var addresses = await _dbContext.Addresses.ToListAsync();
            return _mapper.Map<List<AddressDTO>>(addresses);

        }

        public async Task<int> UpdateAddressAsync(int addressID, AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            address.AddressId = addressID;
            _dbContext.Addresses.Update(address);
            await _dbContext.SaveChangesAsync();
            return addressID;
        }
    }
}
