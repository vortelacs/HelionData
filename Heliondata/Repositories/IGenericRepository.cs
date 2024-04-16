using Heliondata.Models;

namespace Heliondata.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Delete(int id);
        void Update(T entity);
        Task<T> Add(T entity);

    }
}