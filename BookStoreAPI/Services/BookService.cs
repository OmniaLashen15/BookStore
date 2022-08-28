using BookStoreAPI.DTOs;
using BookStoreDomain;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace BookStoreAPI.Services
{
    public class BookService : IBookRepository
    {
        private IDbConnection db;
        public BookService(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("BookStoreConnection"));
        }

        public async Task<List<Book>> GetAll()
        {
            var sql = "SELECT * FROM BOOKS";
            return db.Query<Book>(sql).ToList();
        }

        public async Task<Book> GetById(Guid id)
        {
            var sql = "SELECT * FROM Books WHERE BookId = @Id";
            return db.Query<Book>(sql, new { @Id = id }).Single();
        }

        public async Task<Book> Insert(Book book)
        {
            var sql = "INSERT INTO Books (BookId,ISBN, Title, PublishDate, BasePrice, Keywords, Genre) VALUES(@BookId, @ISBN, @Title, @PublishDate, @BasePrice, @Keywords, @Genre);";
            //+ "SELECT CAST(SCOPE_IDENTITY() as uniqueidentifier);";
            //var id = db.Query<Guid>(sql, book).SingleOrDefault();
            var Newbook = db.Query<Book>(sql, book).SingleOrDefault();

            //book.BookId = id;
            return Newbook;
        }

        public async Task<Book> Update(Book book)
        {
            var sql = "UPDATE Books SET ISBN = @ISBN, Title = @Title," +
                " PublishDate = @PublishDate, BasePrice = @BasePrice, Keywords = @Keywords, Genre=@Genre" +
                " WHERE BookId = @BookId";
            return db.Query<Book>(sql, book).FirstOrDefault();
            
        }
        public async Task<Book> Delete(Guid id)
        {
            var sql = "DELETE FROM Books WHERE BookId = @id";
            return  db.Query<Book>(sql, new { id }).SingleOrDefault();
        }

        public async Task<List<Book>> SearchByKeyword(string word)
        {
            var sql = "SELECT * FROM Books WHERE Keywords Like '%'+@word+'%';";
            return  db.Query<Book>(sql, new { word }).ToList();

        }

        public async Task<Book> GetBookByISBN(string isbn)
        {
            var sql = "SELECT * FROM Books WHERE ISBN = @isbn";
            return db.Query<Book>(sql, new { isbn }).SingleOrDefault();
        }

        public static Book BookFromDTO(BookDTO bookDTO)
        {
            return new Book
            {
                BookId = bookDTO.BookId,
                ISBN = bookDTO.ISBN,
                Title = bookDTO.Title,
                PublishDate = bookDTO.PublishDate,
                BasePrice = bookDTO.BasePrice,
                Keywords = bookDTO.Keywords,
                Genre = bookDTO.Genre
            };
        }


        public static BookDTO BookToDTO(Book book)
        {
            return new BookDTO
            {
                BookId=book.BookId,
                ISBN=book.ISBN,
                Title=book.Title,
                PublishDate=book.PublishDate,
                BasePrice=book.BasePrice,
                Keywords = book.Keywords,
                Genre=book.Genre

            };
        }
    }
}
