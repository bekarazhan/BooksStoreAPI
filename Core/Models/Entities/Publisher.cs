﻿namespace BooksStoreAPI.Core.Models.Entities
{
    public class Publisher:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }

}
