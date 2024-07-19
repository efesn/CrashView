using CrashView.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CrashView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, TokenService tokenService, ILogger<LoginController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                _logger.LogWarning("User not found: {Username}", model.Username);
                return Unauthorized("Invalid login attempt");
            }

            // Log the stored hashed password
            var storedHashedPassword = user.PasswordHash;
            _logger.LogInformation("Stored hashed password for user {Username}: {PasswordHash}", model.Username, storedHashedPassword);

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var token = _tokenService.GenerateToken(user.Id);
                _logger.LogInformation("User logged in: {Username}", model.Username);
                return Ok(new { Token = token });
            }

            _logger.LogWarning("Invalid login attempt for user: {Username}", model.Username);
            return Unauthorized("Invalid login attempt");
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
