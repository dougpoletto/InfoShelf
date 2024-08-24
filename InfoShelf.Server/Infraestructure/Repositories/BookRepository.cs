using InfoShelf.Server.Domain.Interfaces.Respositories;
using InfoShelf.Server.Domain.Models.Context;
using InfoShelf.Server.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfoShelf.Server.Infraestructure.Repositories
{
    public class BookRepository(BookContext bookContext) : IBookRepository
    {
        private readonly BookContext _bookContext = bookContext;

        public async Task CreateAsync(Book book)
        {
            _bookContext.Books.Add(book);
            await _bookContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _bookContext.Books.Remove(book);
            await _bookContext.SaveChangesAsync();
        }

        public async Task EditAsync(Book book)
        {
            _bookContext.Books.Update(book);
            await _bookContext.SaveChangesAsync();
        }

        public async Task<Book?> GetBookId(int idBook)
        {
            return await _bookContext.Books
                .FirstOrDefaultAsync(b => b.Id == idBook);
        }

        public async Task<List<Book>> ListBook()
        {
            return await _bookContext.Books
                .ToListAsync();
        }
    }
}
