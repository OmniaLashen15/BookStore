using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreDomain
{
    public class AuthorBook
    {
        public AuthorBook()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }
        [JsonIgnore]
        public Book? Book { get; set; }
    }
}
