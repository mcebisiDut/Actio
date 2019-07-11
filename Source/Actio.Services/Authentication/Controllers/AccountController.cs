using System.Threading.Tasks;
using Actio.Common.Commands;
using Authentication.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
                    => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}