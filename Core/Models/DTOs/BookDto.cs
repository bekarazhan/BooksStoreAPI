namespace BooksStoreAPI.Core.Models.DTOs
{
    public class BookDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public string? PublisherName { get; set; }
    }
}
