using AirAstanaWebAPI.Controllers;
using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace UnitInfrastructureTest
{

public class FlightsControllerTests
{
    private readonly Mock<IFlightService> _mockFlightService;
    private readonly Mock<FlightRepository> _FlightRepository;
    private readonly Mock<IUserService> _mockUsersService;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly FlightsController _controller;
    private readonly AccountController _accountController;

    public FlightsControllerTests()
    {
        _mockFlightService = new Mock<IFlightService>();
            _FlightRepository = new Mock<FlightRepository>();
            _mockUsersService = new Mock<IUserService>();
            _mockConfiguration = new Mock<IConfiguration>();
        _controller = new FlightsController(_mockFlightService.Object);
        _accountController = new AccountController(_mockUsersService.Object, _mockConfiguration.Object);
    }

    [Fact]
    public async Task TestAccountUsers()
    {
            var flights = new List<Flight>
            {
                new Flight { Id = 1, Origin = "111", Destination = "On Time" },
                new Flight { Id = 2, Origin = "222", Destination = "Delayed" }
            };
        var res=_mockFlightService.Setup(service => service.GetFlightsListAsync()).ReturnsAsync(flights);
            _mockFlightService.Setup(service => service.AddFlightsDataAsync(flights, "111")).ReturnsAsync(flights);
            await _controller.AddFlightsData(flights);
            IEnumerable<Flight> testresult = (await _controller.GetFlightsList()).ToList();


        }

    //[Fact]
    //public async Task GetFlightById_ReturnsNotFoundResult_WhenFlightDoesNotExist()
    //{
    //    // Arrange
    //    var flightId = 1;
    //    _mockFlightService.Setup(service => service.GetFlightByIdAsync(flightId)).ReturnsAsync((FlightDto)null);

    //    // Act
    //    var result = await _controller.GetFlightById(flightId);

    //    // Assert
    //    Assert.IsType<NotFoundResult>(result.Result);
    //}
}

}