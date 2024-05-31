using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class UserService:IUserService
    {
        private readonly Domain.Services.UserService _serService;
        private readonly IMapper _mapper;
        public UserService(Domain.Services.UserService userService, IMapper mapper)
        {
            _serService = userService;
            _mapper = mapper;
        }
        public async Task<string> GetAuthorizationToken(string UserName, string Password, string key) =>await _serService.GetAuthorizationTokenAsync(UserName, Password, key);
        public async Task<string> Registration(User user)
        {
            var res = _mapper.Map<User>(user);
            return await _serService.RegistrationAsync(res);
        }
    }
}
