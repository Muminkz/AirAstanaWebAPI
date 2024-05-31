using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DataDbContext;

namespace Infrastructure.Repositories
{
    public class RolesRepository: IRolesService
    {
        private DataContext  _dataContext;
        public RolesRepository(DataContext dataContext) {  _dataContext = dataContext; }
        public async Task<IEnumerable<Role>> GetRoleList()
        {
            var roleList = _dataContext.Role.ToList();
            if (roleList.Count == 0)
            {
                roleList.AddRange(new List<Role>
                        {
                            new Role
                            {
                                Code = "Role_View",
                                Description = "Роль для просмотра"
                            },
                            new Role
                            {
                                Code = "Role_Edited",
                                Description = "Роль для просмотра и редактирования"
                            }
                        });
                await _dataContext.Role.AddRangeAsync(roleList);
                await _dataContext.SaveChangesAsync();
            }
            return roleList;
        }
        public async Task<bool> CheckRoleAccess(string UserName)
        {
                var user = _dataContext.Users.FirstOrDefault(x => x.UserName == UserName);
                if (user is not null)
                    return user.RoleId == "Role_Edited";
                return false;
        }
    }
}
