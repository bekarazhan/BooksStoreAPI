using AutoMapper;
using BooksStoreAPI.Core.Interfaces;
using BooksStoreAPI.Core.Models.DTOs;
using BooksStoreAPI.Core.Models.Entities;

namespace BooksStoreAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<PublisherDto>> GetAllPublishers()
        {
            var publishers = await _publisherRepository.ListAllAsync();
            return _mapper.Map<List<PublisherDto>>(publishers);
        }

        public async Task<PublisherDto> GetPublisherById(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            return _mapper.Map<PublisherDto>(publisher);
        }

        public async Task<PublisherDto> AddPublisher(PublisherDto publisherDTO)
        {
            var publisher = _mapper.Map<Publisher>(publisherDTO);
            var addedPublisher = await _publisherRepository.AddAsync(publisher);
            return _mapper.Map<PublisherDto>(addedPublisher);
        }

        public async Task UpdatePublisher(PublisherDto publisherDTO)
        {
            var publisher = _mapper.Map<Publisher>(publisherDTO);
            await _publisherRepository.UpdateAsync(publisher);
        }

        public async Task DeletePublisher(int id)
        {
            await _publisherRepository.DeleteAsync(id);
        }
    }
}
