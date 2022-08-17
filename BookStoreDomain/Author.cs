namespace BookStoreDomain
{
    public class Author
    {

        public int  AuthorId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AboutTheAuthor { get; set; }
        public string ImageURL { get; set; }
        public Book Book { get; set; }
    }
}