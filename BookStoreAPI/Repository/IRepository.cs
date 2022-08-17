namespace BookStoreAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(int id);
    }
}
