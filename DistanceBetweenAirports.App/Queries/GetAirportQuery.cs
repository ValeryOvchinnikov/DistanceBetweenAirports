using DistanceBetweenAirports.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceBetweenAirports.App.Queries
{
    public class GetAirportQuery:IRequest<Airport>
    {
        public string IataCode { get; set; }

        public GetAirportQuery(string iataCode)
        {
            IataCode = iataCode;
        }
    }
}
