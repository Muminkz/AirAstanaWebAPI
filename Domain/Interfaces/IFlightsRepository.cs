using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFlightsRepository
    {
        Task<IEnumerable<Flight>> GetFlightsList();
        Task<string> AddFlightsData(Flight flight, string UserCode);
        Task<string> EditedFlightsData(Flight flight, string UserCode);
    }
}
