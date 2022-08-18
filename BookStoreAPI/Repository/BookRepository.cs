using BookStoreDomain;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace BookStoreAPI.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private IDbConnection db;
        public BookRepository(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("BookStoreConnection"));
        }

        public async Task<List<Book>> GetAll()
        {
            var sql = "SELECT * FROM BOOKS";
            return db.Query<Book>(sql).ToList();
        }

        public async Task<Book> GetById(int id)
        {
            var sql = "SELECT * FROM Books WHERE BookId = @Id";
            return db.Query<Book>(sql, new { @Id = id }).Single();
        }

        public async Task<Book> Insert(Book book)
        {
            var sql = "INSERT INTO Books (ISBN, Title, PublishDate, BasePrice, Keywords, Genre, AuthorId) VALUES(@ISBN, @Title, @PublishDate, @BasePrice, @Keywords, @Genre, @AuthorId);"
            + "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql, book).Single();
            book.BookId = id;
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            var sql = "UPDATE Books SET ISBN = @ISBN, Title = @Title," +
                " PublishDate = @PublishDate, BasePrice = @BasePrice, Keywords = @Keywords, Genre=@Genre, AuthorId=@AuthorId" +
                " WHERE BookId = @BookId";
            db.Execute(sql, book);
            return book;
        }
        public async Task<Book> Delete(int id)
        {
            var sql = "DELETE FROM Books WHERE BookId = @Id";
            var book = db.Query(sql, new { id }).Single();
            return book;
        }

        public async Task<Book> Search(string word)
        {
            var sql = "SELECT top(1)* FROM Books WHERE CONTAINS (Keywords, @word);";
            var book = db.Query<Book>(sql, new { word }).FirstOrDefault();
            
            return book;
        }
    }
}
