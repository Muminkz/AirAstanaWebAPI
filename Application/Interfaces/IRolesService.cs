
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<Role>> GetRoleList();
        Task<bool> CheckRoleAccess(string UserName);
    }
}
