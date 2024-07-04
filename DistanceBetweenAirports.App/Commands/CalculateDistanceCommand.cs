using DistanceBetweenAirports.App.Models;
using DistanceBetweenAirports.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceBetweenAirports.App.Commands
{
    public class CalculateDistanceCommand:IRequest<DistanceResult>
    {
        public Airport Airport1 { get; set; }
        
        public Airport Airport2 { get; set; }
    }
}
