using BooksStoreAPI.Core.Models.DTOs;

namespace BooksStoreAPI.Core.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherDto>> GetAllPublishers();
        Task<PublisherDto> GetPublisherById(int id);
        Task<PublisherDto> AddPublisher(PublisherDto publisherDTO);
        Task UpdatePublisher(PublisherDto publisherDTO);
        Task DeletePublisher(int id);
    }

}
