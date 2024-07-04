using DistanceBetweenAirports.Domain.Entities;
using DistanceBetweenAirports.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DistanceBetweenAirports.Domain.Exceptions;

namespace DistanceBetweenAirports.App.Queries
{
    public class GetAirportQueryHandler:IRequestHandler<GetAirportQuery,Airport>
    {
        private readonly IAirportService _airportService;

        public GetAirportQueryHandler(IAirportService airportService)
        {
            _airportService = airportService;
        }

        public async Task<Airport> Handle(GetAirportQuery request, CancellationToken cancellationToken)
        {
            var airport = await _airportService.GetAirportAsync(request.IataCode);

            if (airport == null)
            {
                throw new AirportNotFoundException(request.IataCode);
            }

            return airport;
        }
    }
}
