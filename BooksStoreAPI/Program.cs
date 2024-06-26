using API.Helpers;
using AutoMapper;
using BooksShop.Repositories;
using BooksStoreAPI.Core.Interfaces;
using BooksStoreAPI.Core.Services;
using BooksStoreAPI.Middlewares;
using BooksStoreAPI.Services;
using BookStoreAPI.Infrastructure;
using BookStoreAPI.Infrastructure.Data;
using Core.Interfaces;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<BookContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();
app.UseMiddleware<FakeAuthenticationMiddleware>();
app.UseMiddleware<AuthorizationMiddleware>();
app.UseCustomMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
