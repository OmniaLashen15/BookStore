using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
            AuthorId = Guid.NewGuid();
        }
        public Guid AuthorId { get; set; }
        [MinLength(2, ErrorMessage = "Lastname is invalid")]
        [MaxLength(10, ErrorMessage = "Lastname has to be than 10 characters long.")]
        public string FirstName { get; set; }
        [MinLength(2, ErrorMessage = "Lastname is invalid")]
        [MaxLength(10, ErrorMessage = "Lastname has to be than 10 characters long.")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string AboutTheAuthor { get; set; }
        public string ImageURL { get; set; }
    }
}
