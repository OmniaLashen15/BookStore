using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreDomain
{
    public class Book
    {
     
        public int BookId { get; set; }
        public string ISBN { get; set; }
        //[Column("BookTitle")]
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public string Keywords { get; set; }
        public BookGenre Genre { get; set; }
        public int AuthorId{ get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }

    }
}
