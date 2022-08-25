using BookStoreDomain;

namespace BookStoreAPI.DTOs
{
    public class AuthorBookDTO
    {
        public AuthorBookDTO()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }


    }
}
