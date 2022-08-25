using BookStoreDomain;

namespace BookStoreAPI
{
    public interface IAuthorRepository:IRepository<Author>
    {
        Task<Author> GetAuthorByEmail(string email);
        Task<List<Author>> SearchByName(string word);

    }
}
