using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AirAstanaWebAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AccountController : ControllerBase
    {
        readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost("GetAuthorizationToken")]
        public async Task<string> GetAuthorizationToken(string UserName, string Password)=> await _userService.GetAuthorizationToken(UserName, Password, _configuration["ApplicationSettings:SecretKey"]);
        [HttpPost("Registration")]
        public async Task<string> Registration(User user) => await _userService.Registration(user);
    }
}
