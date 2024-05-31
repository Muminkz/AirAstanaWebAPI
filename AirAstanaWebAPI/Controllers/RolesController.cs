
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirAstanaWebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        [HttpGet("GetRolesList")]
        public async Task<IEnumerable<Role>> GetRolesList()=>await _rolesService.GetRoleList();
        [HttpGet("CheckRoleAccess")]
        public async Task<bool> CheckRoleAccess() => await _rolesService.CheckRoleAccess(User.Identity?.Name);
    }
}
