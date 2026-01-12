using Microsoft.AspNetCore.Mvc;
using MyAppService.Domain.Interfaces.Services;

namespace MyAppService.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(string id)
        {
            return Ok(await _userService.GetUserDetailsByIdAsync(id));
        }
    }
}
