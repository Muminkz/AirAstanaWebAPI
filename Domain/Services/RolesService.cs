using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class RolesService
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<IEnumerable<Role>> GetRoleListAsync() => await _rolesRepository.GetRoleList();
        public async Task<bool> CheckRoleAccessAsync(string UserName)=> await _rolesRepository.CheckRoleAccess(UserName);
    }
}
