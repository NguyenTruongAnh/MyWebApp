using MyAppService.Application.Interfaces.Repositories;
using MyAppService.Domain.Entities;
using MyAppService.Infrastructure.Data;

namespace MyAppService.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ServiceContext context) : base(context)
        {
        }
    }
}
