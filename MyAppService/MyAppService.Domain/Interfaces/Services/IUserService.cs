using MyAppService.Domain.Entities;

namespace MyAppService.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserDetailsByIdAsync(string id);
    }
}
