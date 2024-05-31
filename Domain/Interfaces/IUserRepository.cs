using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<string> GetAuthorizationToken(string UserName, string Password,string key);
        Task<string> Registration(User user);
    }
}
