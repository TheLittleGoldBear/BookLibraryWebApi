using BookLibraryWebApi.Dto;
using BookLibraryWebApi.Interfaces;
using BookLibraryWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var book = await _bookService.GetBook(bookId);
        
            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();

            if(books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBook = await _bookService.CreateBookAsync(book);
        
            if(!createdBook)
            {
                return BadRequest(ModelState);
            }

            return Ok("Created Book");
        }
    }
}
