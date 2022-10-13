using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreAPI.Models;
using OnlineBookStoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository, ILanguageRepository languageRepository, IPublisherRepository publisherRepository, IWebHostEnvironment hostEnvironment)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _languageRepository = languageRepository;
            _publisherRepository = publisherRepository;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var authors = await _bookRepository.GetAllBookAsync();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id);
                //book.BookImagePath = Path.Combine(_hostEnvironment.WebRootPath, "BookImageUploads", book.BookImagePath);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });
            }
        }

        [HttpPost("")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddBook([FromForm] BookDTO book)
        {
            try
            {
                string fileName = GenerateFileName("BookImg") + Path.GetExtension(book.BookImage.FileName);
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, "BookImageUploads", fileName);
                //string fileName = 
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await book.BookImage.CopyToAsync(fileStream);
                }
                book.BookImagePath = "BookImageUploads/" + fileName;
                int Id = await _bookRepository.AddBookAsync(book);
                book.BookId = Id;
                book.BookImage = null;
                return CreatedAtAction(nameof(GetBookById), new { id = Id, controller = "book" }, book);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });
            }
        }
        [NonAction]
        public string GenerateFileName(string context)
        {
            return context + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookDTO bookDTO)
        {
            try
            {
                var result = await _bookRepository.UpdateBookAsync(id, bookDTO);
                if (result > 0)
                {
                    bookDTO.BookId = id;
                    return Ok(bookDTO);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id);
                if (!string.IsNullOrEmpty(book.BookImagePath))
                {
                    string fullPath = Path.Combine(_hostEnvironment.WebRootPath, book.BookImagePath);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
                var result = await _bookRepository.DeleteBookAsync(id);
                if (result > 0)
                {
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });
            }
        }

        //extra
        [HttpGet("Resources")]
        public async Task<IActionResult> GetAllBookResources()
        {
            try
            {
                BookResourcesDTO bookResources = new BookResourcesDTO();
                bookResources.Authors = await _authorRepository.GetAllAuthorAsync();
                bookResources.Languages = await _languageRepository.GetAllLanguageAsync();
                bookResources.Publishers = await _publisherRepository.GetAllPublisherAsync();
                return Ok(bookResources);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Exception Occured : " + ex.Message });

            }

        }

    }
}
