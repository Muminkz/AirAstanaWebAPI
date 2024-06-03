using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class RolesService:IRolesService
    {
        private readonly Domain.Services.RolesService _rolesRepository;
        private readonly IMapper _mapper;
        public RolesService(Domain.Services.RolesService rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Role>> GetRoleList()
        {
            var role=await _rolesRepository.GetRoleListAsync();
            return _mapper.Map<IEnumerable<Role>>(role);
        }
        public async Task<bool> CheckRoleAccess(string UserName) => await _rolesRepository.CheckRoleAccessAsync(UserName);
    }
}