using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceBetweenAirports.Domain.Exceptions
{
    public class AirportNotFoundException:Exception
    {
        public AirportNotFoundException(string iataCode)
            : base($"Airport with IATA code '{iataCode}' was not found.")
        {
        }
    }
}
