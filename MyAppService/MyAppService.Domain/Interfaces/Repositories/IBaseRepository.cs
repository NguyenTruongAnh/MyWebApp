using MyAppService.Domain.Common;
using System.Linq.Expressions;

namespace MyAppService.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> condition,
        bool trackChanges = false);

        Task<List<T>> FindByConditionAsync(
            Expression<Func<T, bool>> condition,
            bool trackChanges = false);

        Task CreateAsync(T entity, bool complete = false);
        Task CreateRangeAsync(IEnumerable<T> entities, bool complete = false);
        Task UpdateAsync(T entity, bool complete = false);
    }
}
