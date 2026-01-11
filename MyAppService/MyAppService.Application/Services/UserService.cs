using MyAppService.Application.Interfaces.Repositories;
using MyAppService.Application.Interfaces.Services;
using MyAppService.Domain.Entities;

namespace MyAppService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = null!;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserDetailsByIdAsync(string id)
        {
            var userDetails = await _userRepository.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Resource not found");
            return userDetails;
        }
    }
}
