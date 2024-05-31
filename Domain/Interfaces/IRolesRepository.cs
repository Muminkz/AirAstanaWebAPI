
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Role>> GetRoleList();
        Task<bool> CheckRoleAccess(string UserName);
    }
}
