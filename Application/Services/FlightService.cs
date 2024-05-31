
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class FlightService:IFlightService
    {
        private readonly Domain.Services.FlightService _flightService;
        private readonly IMapper _mapper;
        public FlightService(Domain.Services.FlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Flight>> GetFlightsListAsync()
        {
            var flight = await _flightService.GetFlightsListAsync();
            return _mapper.Map<IEnumerable<Flight>>(flight);
        }
        public async Task<string> AddFlightsDataAsync(Flight flight, string UserCode)
        {
            var res = _mapper.Map<Flight>(flight);
            return await _flightService.AddFlightsDataAsync(res, UserCode);
        }
        public async Task<string> EditedFlightsDataAsync(Flight flight, string UserCode)
        {
            var res = _mapper.Map<Flight>(flight);
            return await _flightService.EditedFlightsDataAsync(res, UserCode);
        }
    }
}
