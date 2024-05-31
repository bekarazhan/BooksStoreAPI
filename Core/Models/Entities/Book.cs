namespace BooksStoreAPI.Core.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }


}
