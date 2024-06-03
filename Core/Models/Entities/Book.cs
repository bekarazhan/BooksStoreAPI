namespace BooksStoreAPI.Core.Models.Entities
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }


}
