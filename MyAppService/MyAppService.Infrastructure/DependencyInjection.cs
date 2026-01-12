using Microsoft.Extensions.DependencyInjection;
using MyAppService.Domain.Common;
using MyAppService.Domain.Interfaces.Repositories;
using MyAppService.Infrastructure.Repositories;

namespace MyAppService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
