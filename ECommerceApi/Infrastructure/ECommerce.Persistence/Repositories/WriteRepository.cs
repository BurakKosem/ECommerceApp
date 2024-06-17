using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Common;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly PostgreDbContext _dbContext;

        public WriteRepository(PostgreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table => _dbContext.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public void DeleteRange(IList<T> entities)
        {
            Table.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
