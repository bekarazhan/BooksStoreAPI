using BooksStoreAPI.Core.Models.Entities;

namespace BooksStoreAPI.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }

}
