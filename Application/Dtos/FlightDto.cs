using Domain.Enums;
namespace Application.Dtos
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public Status Status { get; set; }
    }
}
