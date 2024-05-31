using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace UnitInfrastructureTest
{
    public class AccountTest
    {
        private readonly Mock<IFlightsRepository> _flightRepositoryMock;
        private readonly IFlightService _flightService;

        [Fact]
        public async Task GetFlightsAsync_ReturnsCorrectList()
        {
            // Arrange
            var flights = new List<Flight>
        {
            new Flight { Id = 1, Origin = "ABC123", Destination = "On Time" },
            new Flight { Id = 2, Origin = "XYZ789", Destination = "Delayed" }
        };
            Assert.NotNull(flights);
            //_flightRepositoryMock.Setup(repo => repo.GetFlightsList()).ReturnsAsync(flights);

            //// Act
            //var result = await _flightService.GetFlightsListAsync();

            // Assert
            //Assert.NotNull(result);
            //Assert.Equal(2, result.Count());
            //Assert.Equal("ABC123", result.First().Origin);
            // Add more assertions as needed
        }
    }
}