using InfoShelf.Server.Domain.Interfaces.Services;
using InfoShelf.Server.Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InfoShelf.Server.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpPost]
        [Route("createBook")]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            BaseDto response = await _bookService.CreateBook(createBookDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("updateBook/{idBook}")]
        public async Task<IActionResult> UpdateBook(int idBook, BookDto bookDto)
        {
            BaseDto response = await _bookService.UpdateBook(idBook, bookDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Route("getBookById/{idBook}")]
        public async Task<IActionResult> GetBookById(int idBook)
        {
            BaseDto<BookDto> response = await _bookService.GetBookById(idBook);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Route("getListBooks")]
        public async Task<IActionResult> GetListBooks()
        {
            BaseDto<List<BookDto>> response = await _bookService.GetListBooks();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("deleteBook/{idBook}")]
        public async Task<IActionResult> DeleteBook(int idBook)
        {

            BaseDto response = await _bookService.DeleteBook(idBook);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
