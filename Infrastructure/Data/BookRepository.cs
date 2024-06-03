using BooksStoreAPI.Core.Interfaces;
using BooksStoreAPI.Core.Models.Entities;
using BookStoreAPI.Infrastructure.Data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Infrastructure
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context):base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Book>> GetBooksOrderedByTitleAsync()
        {
            return await _context.Books.OrderBy(x => x.Title).ToListAsync();
        }
        public async Task<IReadOnlyList<Book>> GetBooksOrderedDescByTitleAsync()
        {
            return await _context.Books.OrderByDescending(x => x.Title).ToListAsync();
        }
    }
}
