using Microsoft.Extensions.DependencyInjection;
using MyAppService.Application.Services;
using MyAppService.Domain.Interfaces.Services;

namespace MyAppService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
