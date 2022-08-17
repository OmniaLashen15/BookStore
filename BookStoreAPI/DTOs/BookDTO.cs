namespace BookStoreAPI.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public string Keywords { get; set; }
        public int AuthorId { get; set; }
    }
}
