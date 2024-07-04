using DistanceBetweenAirports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenAirports.Domain.Services
{
    public interface IAirportService
    {
        Task<Airport> GetAirportAsync(string iataCode);
    }
}
