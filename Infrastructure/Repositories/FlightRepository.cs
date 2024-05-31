
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.DataDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FlightRepository: IFlightService
    {
        private readonly DataContext _dataContext;
        private readonly IRolesService _rolesService;
        public FlightRepository(DataContext dataContext,IRolesService rolesService) { 
            _dataContext = dataContext;
            _rolesService=rolesService;
        }
        public async Task<IEnumerable<Flight>> GetFlightsListAsync()=>await _dataContext.Flights.ToListAsync();
        public async Task<string> AddFlightsDataAsync(Flight flight, string UserCode)
        {
            try
            {
                if (!(await _rolesService.CheckRoleAccess(UserCode))) return "У вас не имеется доступ";
                var result = await _dataContext.Flights.FirstOrDefaultAsync(x => x.Origin == flight.Origin);
                if (result is not null) return "Такой рейс уже существует((";
                await _dataContext.AddAsync(flight);
                await _dataContext.SaveChangesAsync();
                return "Успешно сохранено!";
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при сохранении:" + ex.Message);
            }
        }
        public async Task<string> EditedFlightsDataAsync(Flight flight, string UserCode)
        {
            try
            {
                if (!(await _rolesService.CheckRoleAccess(UserCode))) return "У вас не имеется доступ";
                var result = await _dataContext.Flights.FirstOrDefaultAsync(x => x.Origin == flight.Origin);
                if (result is null) return "Такой рейс не существует((";
                _dataContext.Update(result);
                await _dataContext.SaveChangesAsync();
                return "Успешно редактировано!";
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при редактировании: " + ex.Message);
            }
        }
    }
}
