using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.CodeAnalysis.Scripting;

namespace CrashView.Auth
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TokenService _tokenService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(DataContext context, TokenService tokenService, ILogger<LoginController> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == model.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                _logger.LogWarning("Invalid login attempt for user: {Username}", model.Username);
                return Unauthorized("Invalid login attempt");
            }

            var token = _tokenService.GenerateToken(user.Id);
            _logger.LogInformation("User logged in: {Username}", model.Username);
            return Ok(new { Token = token });
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
