using InfoShelf.Server.Domain.Models.DTO;

namespace InfoShelf.Server.Domain.Interfaces.Services
{
    public interface IBookService
    {
        public Task<BaseDto> CreateBook(CreateBookDto createBookDto);
        public Task<BaseDto> UpdateBook(int idBook, BookDto createBookDto);
        public Task<BaseDto<BookDto>> GetBookById(int idBook);
        public Task<BaseDto<List<BookDto>>> GetListBooks();
        public Task<BaseDto> DeleteBook(int idBook);
    }
}
