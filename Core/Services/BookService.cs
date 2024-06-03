using AutoMapper;
using BooksStoreAPI.Core.Interfaces;
using BooksStoreAPI.Core.Models.DTOs;
using BooksStoreAPI.Core.Models.Entities;

namespace BooksStoreAPI.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetBooksOrderedByTitleAsync()
        {
            var books = await _bookRepository.GetBooksOrderedByTitleAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetBooksOrderedDescByTitleAsync()
        {
            var books = await _bookRepository.GetBooksOrderedDescByTitleAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return null;

            return _mapper.Map<BookDto>(book);
        }

        public async Task AddBookAsync(BookDto BookDto)
        {
            var book = _mapper.Map<Book>(BookDto);
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateBookAsync(BookDto BookDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(BookDto.Id);
            if (existingBook == null)
            {
                throw new ArgumentException("Book not found.");
            }

            // Map changes from BookDto to existing Book entity
            _mapper.Map(BookDto, existingBook);

            await _bookRepository.UpdateAsync(existingBook);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);

        }
    }
}
