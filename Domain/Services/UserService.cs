using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> GetAuthorizationTokenAsync(string UserName, string Password, string key) => await _userRepository.GetAuthorizationToken(UserName, Password,key);
        public async Task<string> RegistrationAsync(User user) => await _userRepository.Registration(user);
    }
}
