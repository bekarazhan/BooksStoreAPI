using BooksStoreAPI.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Infrastructure.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bookstore.db");
        }
    }

}
