using InfoShelf.Server.Domain.Interfaces.Respositories;
using InfoShelf.Server.Domain.Interfaces.Services;
using InfoShelf.Server.Domain.Services;
using InfoShelf.Server.Infraestructure.Contexts;
using InfoShelf.Server.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("https://localhost:4200") // Substitua pela URL do seu frontend
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar o DbContext
builder.Services.AddDbContext<BookContext>(options =>
    options.UseInMemoryDatabase("InfoShelfDatabase"));

// Registrar o repositório como Scoped ou Transient
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.MapFallbackToFile("/index.html");

app.Run();
