using BooksStoreAPI.Core.Models.Entities;
using Core.Interfaces;

namespace BooksStoreAPI.Core.Interfaces
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        Task<IReadOnlyList<Book>> GetBooksOrderedByTitleAsync();
        Task<IReadOnlyList<Book>> GetBooksOrderedDescByTitleAsync();
    }

}
