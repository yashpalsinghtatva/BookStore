using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface ICountryRepository
    {
        Task<List<CountryDTO>> GetAllCountriesAsync();
        Task<CountryDTO> GetCountryByIdAsync(int id);
        Task<int> AddCountryAsync(CountryDTO countryDTO);
        Task<int> UpdateCountryAsync(int countryId, CountryDTO countryDTO);
        Task<int> DeleteCountryAsync(int countryId);
    }
}
