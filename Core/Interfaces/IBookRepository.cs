using BooksStoreAPI.Core.Models.Entities;
using Core.Interfaces;

namespace BooksStoreAPI.Core.Interfaces
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        //Task<List<Book>> GetAllBooks();
        //Task<Book> GetBookById(int id);
        //Task<Book> AddBook(Book book);
        //Task UpdateBook(Book book);
        //Task DeleteBook(int id);

    }

}
