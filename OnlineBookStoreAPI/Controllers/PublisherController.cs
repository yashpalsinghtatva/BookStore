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

    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _PublisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _PublisherRepository = publisherRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _PublisherRepository.GetAllPublisherAsync();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById([FromRoute] int id)
        {
            var publisher = await _PublisherRepository.GetPublisherByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddPublisher([FromBody] PublisherDTO publisherDTO)
        {
            try
            {
                int Id = await _PublisherRepository.AddPublisherAsync(publisherDTO);
                publisherDTO.PublisherId= Id;
                return CreatedAtAction(nameof(GetPublisherById), new { id = Id, controller = "Publisher" }, publisherDTO);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher([FromRoute] int id, [FromBody] PublisherDTO publisherDTO)
        {
            var result = await _PublisherRepository.UpdatePublisherAsync(id, publisherDTO);
            if (result > 0)
            {
                publisherDTO.PublisherId = id;
                return Ok(publisherDTO);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            var result = await _PublisherRepository.DeletePublisherAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
