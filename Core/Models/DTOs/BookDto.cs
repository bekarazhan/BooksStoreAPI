﻿namespace BooksStoreAPI.Core.Models.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public string Author { get; set; } // Assuming Author property exists in Book entity
        public string PublisherName { get; set; } // Optional property to display publisher name
    }
}
