using Microsoft.AspNetCore.Mvc;
using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Managers.Interface;

namespace OnlineVotingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserSignupRequest request)
        {
            var result = await _userManager.Signup(request);
            return StatusCode(result.status_code, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var result = await _userManager.Login(request);
            return StatusCode(result.status_code, result);
        }
    }
}
