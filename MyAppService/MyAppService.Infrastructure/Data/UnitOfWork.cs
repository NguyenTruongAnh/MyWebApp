using MyAppService.Application.Interfaces.Repositories;
using MyAppService.Infrastructure.Data;

namespace MyAppService.Domain.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceContext _context;

        public UnitOfWork(ServiceContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
