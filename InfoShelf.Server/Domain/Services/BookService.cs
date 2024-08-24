using InfoShelf.Server.Domain.Interfaces.Respositories;
using InfoShelf.Server.Domain.Interfaces.Services;
using InfoShelf.Server.Domain.Models.Context;
using InfoShelf.Server.Domain.Models.DTO;

namespace InfoShelf.Server.Domain.Services
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<BaseDto> CreateBook(CreateBookDto? createBookDto)
        {
            try
            {
                if (createBookDto is null)
                {
                    return new BaseDto()
                    {
                        Message = "Informe os dados para criar o livro!",
                        Success = false
                    };
                }

                Book book = new()
                {
                    Ano = createBookDto.Ano,
                    Autor = createBookDto.Autor,
                    Genereo = createBookDto.Genero,
                    Titulo = createBookDto.Titulo
                };

                await _bookRepository.CreateAsync(book);
                return new BaseDto()
                {
                    Message = "Livro criado com sucesso!",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new()
                {
                    Message = "Ocorreu um erro interno ao criar o livro!",
                    Success = false
                };
            }
        }

        public async Task<BaseDto> DeleteBook(int idBook)
        {
            try
            {
                Book? book = await _bookRepository.GetBookId(idBook);
                if (book is not null)
                {
                    await _bookRepository.DeleteAsync(book);
                    return new()
                    {
                        Message = "Livro excluído com sucesso!",
                        Success = true
                    };
                }
                else
                {
                    return new()
                    {
                        Message = "Livro não encontrado!",
                        Success = false
                    };
                }
            }
            catch (Exception)
            {
                return new()
                {
                    Message = "Ocorreu um erro interno ao criar o livro!",
                    Success = false
                };
            }
        }

        public async Task<BaseDto<BookDto>> GetBookById(int idBook)
        {
            try
            {
                Book? book = await _bookRepository.GetBookId(idBook);
                if (book is not null)
                {
                    return new()
                    {
                        Message = "Livro encontrado!",
                        Success = true,
                        Response = new BookDto()
                        {
                            Ano = book.Ano,
                            Autor = book.Autor,
                            Genero = book.Genereo,
                            Id = book.Id,
                            Titulo = book.Titulo
                        }
                    };
                }
                else
                {
                    return new()
                    {
                        Message = "Livro não encontrado!",
                        Success = false,
                    };
                }
            }
            catch (Exception)
            {
                return new()
                {
                    Message = $"Ocorreu um erro interno ao pegar o livro. Id: {idBook}",
                    Success = false
                };
            }
        }

        public async Task<BaseDto<List<BookDto>>> GetListBooks()
        {
            try
            {
                List<Book> listBooks = await _bookRepository.ListBook();
                return new()
                {
                    Message = "Lista de livros encontrados!",
                    Success = true,
                    Response = listBooks
                        .Select(b => new BookDto()
                        {
                            Ano = b.Ano,
                            Autor = b.Autor,
                            Genero = b.Genereo,
                            Id = b.Id,
                            Titulo = b.Titulo
                        })
                        .ToList()
                };
            }
            catch (Exception)
            {
                return new()
                {
                    Message = "Ocorreu um erro interno ao listar os livros!",
                    Success = false
                };
            }
        }

        public async Task<BaseDto> UpdateBook(int idBook, BookDto bookDto)
        {
            try
            {
                if (bookDto is null)
                {
                    return new BaseDto()
                    {
                        Message = "Informe os dados para atualizar o livro!",
                        Success = false
                    };
                }

                Book book = new()
                {
                    Ano = bookDto.Ano,
                    Autor = bookDto.Autor,
                    Genereo = bookDto.Genero,
                    Id = idBook,
                    Titulo = bookDto.Titulo
                };

                await _bookRepository.EditAsync(book);
                return new BaseDto()
                {
                    Message = "Livro atualizado com sucesso!",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new()
                {
                    Message = "Ocorreu um erro interno ao atualizar o livro!",
                    Success = false
                };
            }
        }
    }
}
