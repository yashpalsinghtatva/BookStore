using OnlineBookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreAPI.Repository
{
    public interface IPublisherRepository
    {
        Task<List<PublisherDTO>> GetAllPublisherAsync();
        Task<PublisherDTO> GetPublisherByIdAsync(int id);
        Task<int> AddPublisherAsync(PublisherDTO author);
        Task<int> UpdatePublisherAsync(int authorId, PublisherDTO author);
        Task<int> DeletePublisherAsync(int authorId);
    }
}
