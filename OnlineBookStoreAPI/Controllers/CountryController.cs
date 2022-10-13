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

    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById([FromRoute] int id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost("")]
        public async Task<IActionResult> Addcountry([FromBody] CountryDTO countryDTO)
        {
            try
            {
                int Id = await _countryRepository.AddCountryAsync(countryDTO);
                countryDTO.CountryId = Id;
                return CreatedAtAction(nameof(GetCountryById), new { id = Id, controller = "Country" }, countryDTO);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry([FromRoute] int id, [FromBody] CountryDTO countryDTO)
        {
            var result = await _countryRepository.UpdateCountryAsync(id, countryDTO);
            if (result > 0)
            {
                countryDTO.CountryId= id;
                return Ok(countryDTO);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            var result = await _countryRepository.DeleteCountryAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
