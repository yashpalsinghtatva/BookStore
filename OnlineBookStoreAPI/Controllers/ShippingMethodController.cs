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

    public class ShippingMethodController : ControllerBase
    {
        private readonly IShippingMethodRepository _shippingMethodRepository;

        public ShippingMethodController(IShippingMethodRepository shippingMethodRepository)
        {
            _shippingMethodRepository = shippingMethodRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShippingMethods()
        {
            var ShippingMethods = await _shippingMethodRepository.GetAllShippingMethodsAsync();
            return Ok(ShippingMethods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippingMethodById([FromRoute] int id)
        {
            var ShippingMethod = await _shippingMethodRepository.GetShippingMethodByIdAsync(id);
            if (ShippingMethod == null)
            {
                return NotFound();
            }
            return Ok(ShippingMethod);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddShippingMethod([FromBody] ShippingMethodDTO shippingMethodDTO)
        {
            try
            {
                int Id = await _shippingMethodRepository.AddShippingMethodAsync(shippingMethodDTO);
                shippingMethodDTO.ShippingMethodId = Id;
                return CreatedAtAction(nameof(GetShippingMethodById), new { id = Id, controller = "ShippingMethod" }, shippingMethodDTO);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShippingMethod([FromRoute] int id, [FromBody] ShippingMethodDTO shippingMethodDTO)
        {
            var result = await _shippingMethodRepository.UpdateShippingMethodAsync(id, shippingMethodDTO);
            if (result > 0)
            {
                shippingMethodDTO.ShippingMethodId = id;
                return Ok(shippingMethodDTO);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingMethod([FromRoute] int id)
        {
            var result = await _shippingMethodRepository.DeleteShippingMethodAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
