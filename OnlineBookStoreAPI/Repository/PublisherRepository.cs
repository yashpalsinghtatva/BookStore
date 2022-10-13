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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;


        public PublisherRepository(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> AddPublisherAsync(PublisherDTO publisherDTO)
        {
            var publisher = _mapper.Map<Publisher>(publisherDTO);
            _dbContext.Add(publisher);
            await _dbContext.SaveChangesAsync();
            return publisher.PublisherId;

        }

        public async Task<int> DeletePublisherAsync(int publisherId)
        {
            var publisher = new Publisher()
            {
                PublisherId = publisherId
            };

            _dbContext.Publishers.Remove(publisher);
            await _dbContext.SaveChangesAsync();
            return publisherId;
        }

        public async Task<List<PublisherDTO>> GetAllPublisherAsync()
        {
            var publisher = await _dbContext.Publishers.ToListAsync();
            return _mapper.Map<List<PublisherDTO>>(publisher);

        }

        public async Task<PublisherDTO> GetPublisherByIdAsync(int id)
        {
            var publisher = await _dbContext.Publishers.Where(x => x.PublisherId == id).FirstOrDefaultAsync();
            return _mapper.Map<PublisherDTO>(publisher);
        }

        public async Task<int> UpdatePublisherAsync(int publisherId, PublisherDTO publisherDTO)
        {
            var publisher = _mapper.Map<Publisher>(publisherDTO);
            publisher.PublisherId = publisherId;
            _dbContext.Publishers.Update(publisher);
            await _dbContext.SaveChangesAsync();
            return publisherId;
        }
    }
}
