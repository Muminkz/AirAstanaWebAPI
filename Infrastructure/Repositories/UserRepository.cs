using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DataDbContext;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository: IUserService
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) {  _dataContext = dataContext; }
        public async Task<string> GetAuthorizationToken(string UserName, string Password,string key)
        {
                var result = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == UserName && x.Password == PasswordHelper.HashPassword(Password));
                if (result is not null)
                    return GenerateNewJWTToken.GenerateJWTToken(UserName, Password, key);
                else
                    return "Неверный пароль или имя пользователя!";

        }
        public async Task<string> Registration(User user)
        {
            try
            {
            user.Password = PasswordHelper.HashPassword(user.Password);
            var result = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName);
            if (result is not null) return "Пользователь таким именем уже существует((";
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return "Успешно сохранено!";
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
