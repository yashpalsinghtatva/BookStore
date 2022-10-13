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
    public class CountryRepository : ICountryRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public CountryRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddCountryAsync(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            _dbContext.Add(country);
            await _dbContext.SaveChangesAsync();
            return country.CountryId;
        }

        public async Task<int> DeleteCountryAsync(int countryID)
        {
            var country = new Country()
            {
                CountryId = countryID
            };

            _dbContext.Countries.Remove(country);
            await _dbContext.SaveChangesAsync();
            return countryID;
        }

        public async Task<CountryDTO> GetCountryByIdAsync(int CountryId)
        {
            var country = await _dbContext.Countries.Where(x => x.CountryId == CountryId).FirstOrDefaultAsync();
            return _mapper.Map<CountryDTO>(country);

        }

        public async Task<List<CountryDTO>> GetAllCountriesAsync()
        {
            var countryes = await _dbContext.Countries.ToListAsync();
            return _mapper.Map<List<CountryDTO>>(countryes);

        }

        public async Task<int> UpdateCountryAsync(int countryID, CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            country.CountryId = countryID;
            _dbContext.Countries.Update(country);
            await _dbContext.SaveChangesAsync();
            return countryID;
        }
        
    }
}
