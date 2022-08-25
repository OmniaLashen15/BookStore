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
        public DateTime PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public string Keywords { get; set; } 

        [JsonConverter(typeof(StringEnumConverter))]
        public BookGenre Genre { get; set; }
    }
}
