using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageDTO>> GetAllLanguageAsync();
        Task<LanguageDTO> GetLanguageByIdAsync(int id);
        Task<int> AddLanguageAsync(LanguageDTO author);
        Task<int> UpdateLanguageAsync(int authorId, LanguageDTO author);
        Task<int> DeleteLanguageAsync(int authorId);
    }
}
