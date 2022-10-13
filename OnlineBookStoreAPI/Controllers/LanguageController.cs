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

    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLanguages()
        {
            var languages = await _languageRepository.GetAllLanguageAsync();
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById([FromRoute] int id)
        {
            var language = await _languageRepository.GetLanguageByIdAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLanguage([FromBody] LanguageDTO languageDTO)
        {
            try
            {
                int Id = await _languageRepository.AddLanguageAsync(languageDTO);
                languageDTO.LanguageId = Id;
                return CreatedAtAction(nameof(GetLanguageById), new { id = Id, controller = "Language" }, languageDTO);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage([FromRoute] int id, [FromBody] LanguageDTO languageDTO)
        {
            var result = await _languageRepository.UpdateLanguageAsync(id, languageDTO);
            if (result > 0)
            {
                languageDTO.LanguageId = id;
                return Ok(languageDTO);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage([FromRoute] int id)
        {
            var result = await _languageRepository.DeleteLanguageAsync(id);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
