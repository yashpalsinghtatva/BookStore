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
    //[Authorize]
    //[Authorize(Roles = "Admin")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAllAuthorAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            try
            {
                int Id = await _authorRepository.AddAuthorAsync(authorDTO);
                authorDTO.AuthorId = Id;
                return CreatedAtAction(nameof(GetAuthorById), new { id = Id, controller = "author" }, authorDTO);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromRoute] int id, [FromBody] AuthorDTO author)
        {
            var result = await _authorRepository.UpdateAuthorAsync(id, author);
            if (result > 0)
            {
                author.AuthorId = id;
                return Ok(author);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            var result = await _authorRepository.DeleteAuthorAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
