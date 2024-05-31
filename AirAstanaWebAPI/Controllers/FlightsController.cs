using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirAstanaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        [HttpGet("GetFlightsList")]
        public async Task<IEnumerable<Flight>> GetFlightsList()=> await _flightService.GetFlightsListAsync();
        [Authorize]
        [HttpPost("AddFlightsData")]
        public async Task<string> AddFlightsData(Flight flight) => await _flightService.AddFlightsDataAsync(flight, User.Identity?.Name);
        [Authorize]
        [HttpPost("EditedFlightsData")]
        public async Task<string> EditedFlightsData(Flight flight) => await _flightService.EditedFlightsDataAsync(flight, User.Identity?.Name);


    }
}
