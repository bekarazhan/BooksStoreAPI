using BooksStoreAPI.Core.Models.DTOs;
using BooksStoreAPI.Core.Models.Entities;

namespace BooksStoreAPI.Core.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks();
        Task<BookDto> GetBookById(int id);
        Task<BookDto> AddBook(Book bookDTO);
        Task UpdateBook(BookDto bookDTO);
        Task DeleteBook(int id);
    }

}
