using Microsoft.EntityFrameworkCore;
using Heliondata.Data;
using Heliondata.Models;

namespace Heliondata.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {

        private readonly HelionDBContext _dbContext;
        protected DbSet<T> _dbSet;

        public GenericRepository(HelionDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<int> Add(T entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.ID;
        }
        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task Update(T entity)
        {
            var existingEntity = _dbSet.Local.FirstOrDefault(e => e.ID == entity.ID);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).State = EntityState.Detached;
            }
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}