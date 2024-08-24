namespace InfoShelf.Server.Domain.Models.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Ano { get; set; }
    }
}
