using MyAppService.Domain.Entities;

namespace MyAppService.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserDetailsByIdAsync(string id);
    }
}
