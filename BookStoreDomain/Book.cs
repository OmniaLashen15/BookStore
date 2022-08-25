using System.Text.Json.Serialization;

namespace BookStoreDomain
{
    public class Book
    {
        public Book()
        {
            Book_Authors = new List<AuthorBook>();
            BookId = Guid.NewGuid();
        }

        public Guid BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public string Keywords { get; set; }
        public BookGenre Genre { get; set; }
        [JsonIgnore]
        public List<AuthorBook>? Book_Authors { get; set; }

    }
}
