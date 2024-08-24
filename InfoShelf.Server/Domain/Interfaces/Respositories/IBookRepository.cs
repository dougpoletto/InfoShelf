using InfoShelf.Server.Domain.Models.Context;

namespace InfoShelf.Server.Domain.Interfaces.Respositories
{
    public interface IBookRepository
    {
        public Task<bool> CreateAsync(Book book);
        public Task<bool> DeleteAsync(Book book);
        public Task<bool> EditAsync(Book book);
        public Task<Book?> GetBookId(int idBook);
        public Task<List<Book>> ListBook();
    }
}
