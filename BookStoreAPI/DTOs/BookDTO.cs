using BookStoreDomain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.DTOs
{
    public class BookDTO
    {
        public BookDTO()
        {
            BookId = Guid.NewGuid();
        }
        public Guid BookId { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public string Keywords { get; set; } 

        public BookGenre Genre { get; set; }
    }
}
