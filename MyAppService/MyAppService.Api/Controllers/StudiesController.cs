using Microsoft.AspNetCore.Mvc;

namespace MyAppService.Api.Controllers
{
    public class StudiesController : BaseController
    {
        [HttpGet]
        public IActionResult GetUserList()
        {
            return Ok(new { name = "Anh", age = 25 });
        }
    }
}
