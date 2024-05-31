using AutoMapper;
using BooksStoreAPI.Core.Interfaces;
using BooksStoreAPI.Core.Models;
using BooksStoreAPI.Core.Models.DTOs;
using BooksStoreAPI.Core.Models.Entities;
using BooksStoreAPI.Core.Interfaces;

namespace BooksStoreAPI.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository,
            IMapper mapper
            )
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<Book> AddBook(Book bookDto)
        {
            var book = _bookRepository.AddBook(bookDto).Result;

            //BookDto BookDto = new BookDto() { //mapping
            //    Id = book.Id,
            //    Title = book.Title,
            //    PublisherName = book.Publisher.Name
            //};
            return bookDto;
        }

        public async Task DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            var BookDtoList = _mapper.Map<List<BookDto>>(books);
            return BookDtoList;
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            var BookDto = _mapper.Map<BookDto>(book);
            return BookDto;
        }

        public async Task UpdateBook(BookDto bookDTO)
        {
            var book = await _bookRepository.GetBookById(bookDTO.Id);
            book.Title = bookDTO.Title;
            await _bookRepository.UpdateBook(book);
            //book.Publisher.Name = bookDTO.PublisherName;
            return;
        }
    }
}
