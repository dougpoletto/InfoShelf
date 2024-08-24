using InfoShelf.Server.Domain.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace InfoShelf.Server.Infraestructure.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InfoShelfDatabase");
        }
    }
}
