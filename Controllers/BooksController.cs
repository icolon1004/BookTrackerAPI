using Microsoft.AspNetCore.Mvc; //provides controller functionality from MVC library
using BookTrackerAPI.Models;
using BookTrackerAPI.Services;
using BookTrackerAPI.DTOs;

namespace BookTrackerAPI.Controllers
{
    [ApiController] //Tells ASP.Net "this is an API controller"
    [Route("api/[controller]")] //Routes token from each controller into api
    public class BooksController : ControllerBase //Handles HTTP request/response
    {
        //used to call and read data from other class without accidental modification, only happens internally in this file
        private readonly IBookService _bookService;

        //constructor for referance of information for this file from IBookService
        public BooksController(IBookService bookservice)
        {
            _bookService = bookservice;
        }

        //Retrieves data of all books to store into controller
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks(
                [FromQuery] ReadingStatus? status = null,
                [FromQuery] int? minRating = null)
        {
            var books = await _bookService.GetAllBooksAsync(status, minRating);
            return Ok(books); //Ok() is used because HTTP needs to specify status code and formats as JSON which Ok() does automatically
        }

        //Retrieves data but routes with parameter {id},  returns single book instead of full list of books
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound(new { message = $"Book with ID {id} not found" });
            }
            return Ok(book);
        }

        //creates new resource of data in controllers
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] CreateBookDto bookDto) //[FromBody] gets data from Http request 
        {
            //All books require a Title and Author name, this is an identifier of each book
            if (string.IsNullOrWhiteSpace(bookDto.Title))
            {
                return BadRequest(new { message = "Title is required" });
            }

            if (string.IsNullOrWhiteSpace(bookDto.Author))
            {
                return BadRequest(new { message = "Author is required" });
            }

            //passes bookDto information into variable book
            var book = await _bookService.CreateBookAsync(bookDto);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book); //CreatedAtAction() necessary for ControllerBase and returns created response action time
        }


        //updates exsisting resource
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] UpdateBookDto updateDto)
        {
            //book needs to have a rating and book rating needs to be between 1 and 5
            if (updateDto.Rating.HasValue && (updateDto.Rating < 1 || updateDto.Rating > 5))
            {
                return BadRequest(new { message = "Rating must be between 1 and 5" });
            }

            var book = await _bookService.UpdateBookAsync(id, updateDto);
            if (book == null) //Error handling
            {
                return NotFound(new { message = $"Book with ID {id} no found" });
            }

            return Ok(book);
        }

        //deletes books information with parameter
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result) //bool
            {
                return NotFound(new { message = $"Book withID {id} not found" });
            }

            return NoContent(); //standard for successful delete with no response body
        }

        //retrieves books information with parameter
        [HttpGet("search")]
        public async Task<ActionResult<List<Book>>> SearchBooks([FromQuery] string query) //FromQuery searches already retrieved data body
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest(new { message = "Search query is required" });
            }

            var books = await _bookService.SearchBooksAsync(query);
            return Ok(books);
        }

    }

}
