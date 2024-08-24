using InfoShelf.Server.Domain.Models.Context;

namespace InfoShelf.Server.Domain.Interfaces.Respositories
{
    public interface IBookRepository
    {
        public Task CreateAsync(Book book);
        public Task DeleteAsync(Book book);
        public Task EditAsync(Book book);
        public Task<Book?> GetBookId(int idBook);
        public Task<List<Book>> ListBook();
    }
}
