using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoShelf.Server.Domain.Models.Context
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genereo { get; set; } = string.Empty;
        public int Ano { get; set; }
    }
}
