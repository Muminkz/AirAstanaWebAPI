using Application.Dtos;
using AutoMapper;

namespace Application.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Entities.Flight, FlightDto>();
            CreateMap<Domain.Entities.User, UserDto>();
        }
    }
}
