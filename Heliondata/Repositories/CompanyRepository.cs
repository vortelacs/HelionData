using Heliondata.Data;
using Heliondata.Models;
using Microsoft.EntityFrameworkCore;

namespace Heliondata.Repositories
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public CompanyRepository(HelionDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Company>> GetAllCompaniesOfType(string type)
        {
            return await _dbSet.OfType<Company>()
                               .Where(c => EF.Property<string>(c, "Discriminator") == type)
                               .ToListAsync();
        }
    }

}