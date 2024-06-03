using BooksStoreAPI.Core.Interfaces;
using BooksStoreAPI.Core.Models.Entities;
using BookStoreAPI.Infrastructure.Data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class PublisherRepository:GenericRepository<Publisher>, IPublisherRepository
    {
        private readonly BookContext _context;

        public PublisherRepository(BookContext context):base(context) 
        {
            _context = context;
        }
    }
}
