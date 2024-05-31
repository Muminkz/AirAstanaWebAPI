using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsListAsync();
        Task<string> AddFlightsDataAsync(Flight flight, string UserCode);
        Task<string> EditedFlightsDataAsync(Flight flight, string UserCode);
    }
}
