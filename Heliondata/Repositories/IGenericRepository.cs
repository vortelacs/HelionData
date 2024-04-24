using Heliondata.Models;

namespace Heliondata.Repositories
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int id);
        Task Delete(int id);
        Task Update(T entity);
        Task<int> Add(T entity);

    }
}