using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface IAddressRepository
    {
        Task<List<AddressDTO>> GetAllAddressesAsync();
        Task<AddressDTO> GetAddressByIdAsync(int id);
        Task<int> AddAddressAsync(AddressDTO addressDTO);
        Task<int> UpdateAddressAsync(int addressID, AddressDTO addressDTO);
        Task<int> DeleteAddressAsync(int addressID);
    }
}
