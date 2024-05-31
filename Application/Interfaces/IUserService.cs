using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<string> GetAuthorizationToken(string UserName, string Password, string key);
        Task<string> Registration(User user);
    }
}
