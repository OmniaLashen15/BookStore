using BookStoreDomain;

namespace BookStoreAPI
{
    public interface IBookRepository:IRepository<Book>
    {
        Task<Book> GetBookByISBN(string isbn);
        Task<List<Book>> SearchByKeyword(string word);
    }
}
