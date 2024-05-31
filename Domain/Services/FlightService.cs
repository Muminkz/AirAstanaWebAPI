using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class FlightService
    {
        private readonly IFlightsRepository _flightsRepository;
        public FlightService(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }
        public async Task<IEnumerable<Flight>> GetFlightsListAsync() => await _flightsRepository.GetFlightsList();
        public async Task<string> AddFlightsDataAsync(Flight flight, string UserCode) => await _flightsRepository.AddFlightsData(flight, UserCode);
        public async Task<string> EditedFlightsDataAsync(Flight flight, string UserCode) => await _flightsRepository.EditedFlightsData(flight, UserCode);
    }
}
