using BooksStoreAPI.Controllers;
using BooksStoreAPI.Core.Interfaces;
using BooksStoreAPI.Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksShop.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;

        public BooksController(IBookService bookService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksOrderedByTitle()
        {
            var books = await _bookService.GetBooksOrderedByTitleAsync();
            return Ok(books);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksOrderedDescByTitle()
        {
            var books = await _bookService.GetBooksOrderedDescByTitleAsync();
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult> PostBook(BookDto bookDto)
        {
            await _bookService.AddBookAsync(bookDto);
            return CreatedAtAction(nameof(GetBook), new { id = bookDto.Id }, bookDto);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBook(int id, BookDto bookDto)
        {
            if (id != bookDto.Id)
            {
                return BadRequest("Book ID mismatch.");
            }

            try
            {
                await _bookService.UpdateBookAsync(bookDto);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }


}
