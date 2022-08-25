namespace BookStoreAPI
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(Guid id);

    }
}
