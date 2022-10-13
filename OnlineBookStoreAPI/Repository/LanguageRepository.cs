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
    public class LanguageRepository :ILanguageRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public LanguageRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<LanguageDTO>> GetAllLanguageAsync()
        {
            var languages = await _dbContext.Languages.ToListAsync();
            return _mapper.Map<List<LanguageDTO>>(languages);
        }
        public async Task<LanguageDTO> GetLanguageByIdAsync(int id)
        {
            var language = await _dbContext.Languages.Where(x => x.LanguageId == id).FirstOrDefaultAsync();
            return _mapper.Map<LanguageDTO>(language);
        }
        public async Task<int> AddLanguageAsync(LanguageDTO languageDTO)
        {
            var language = _mapper.Map<Language>(languageDTO);
            _dbContext.Add(language);
            await _dbContext.SaveChangesAsync();
            return language.LanguageId;
        }
        public async Task<int> UpdateLanguageAsync(int languageId, LanguageDTO languageDTO)
        {
            var language = _mapper.Map<Language>(languageDTO);
            language.LanguageId = languageId;
            _dbContext.Languages.Update(language);
            await _dbContext.SaveChangesAsync();
            return languageId;
            
        }
        public async Task<int> DeleteLanguageAsync(int languageId)
        {
            var language = new Language()
            {
                LanguageId = languageId
            };

            _dbContext.Languages.Remove(language);
            await _dbContext.SaveChangesAsync();
            return languageId;
        }
    }
}
