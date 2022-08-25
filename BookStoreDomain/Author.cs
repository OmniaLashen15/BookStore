using System.Text.Json.Serialization;

namespace BookStoreDomain
{
    public class Author
    {
        public Author()
        {
            Book_Authors = new List<AuthorBook>();
            AuthorId = Guid.NewGuid();
        }
        public Guid  AuthorId { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AboutTheAuthor { get; set; }
        public string ImageURL { get; set; }
        [JsonIgnore]
        public List<AuthorBook> Book_Authors { get; set; }

    }
}