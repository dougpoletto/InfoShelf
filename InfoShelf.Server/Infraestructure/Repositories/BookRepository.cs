using InfoShelf.Server.Domain.Interfaces.Respositories;
using InfoShelf.Server.Domain.Models.Context;
using InfoShelf.Server.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfoShelf.Server.Infraestructure.Repositories
{
    public class BookRepository(BookContext bookContext) : IBookRepository
    {
        private readonly BookContext _bookContext = bookContext;

        public async Task<bool> CreateAsync(Book book)
        {
            _bookContext.Books.Add(book);
            return await _bookContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Book book)
        {
            _bookContext.Books.Remove(book);
            return await _bookContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditAsync(Book book)
        {
            _bookContext.Books.Update(book);
            return await _bookContext.SaveChangesAsync() > 0;
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
