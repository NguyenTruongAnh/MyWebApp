using Microsoft.EntityFrameworkCore;
using MyAppService.Domain.Interfaces.Repositories;
using MyAppService.Domain.Common;
using MyAppService.Infrastructure.Data;
using System.Linq.Expressions;

namespace MyAppService.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ServiceContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ServiceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> FirstOrDefaultAsync(
            Expression<Func<T, bool>> condition,
            bool trackChanges = false)
        {
            IQueryable<T> query = _dbSet;

            if (!trackChanges)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(condition);
        }

        public async Task<List<T>> FindByConditionAsync(
            Expression<Func<T, bool>> condition,
            bool trackChanges = false)
        {
            IQueryable<T> query = _dbSet.Where(condition);

            if (!trackChanges)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task CreateAsync(T entity, bool complete = false)
        {
            entity.CreatedDate = DateTime.UtcNow;

            await _dbSet.AddAsync(entity);

            if (complete)
                await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities, bool complete = false)
        {
            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.UtcNow;
            }

            await _dbSet.AddRangeAsync(entities);

            if (complete)
                await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, bool complete = false)
        {
            entity.LastModifiedDate = DateTime.UtcNow;

            _dbSet.Update(entity);

            if (complete)
                await _context.SaveChangesAsync();
        }
    }
}
