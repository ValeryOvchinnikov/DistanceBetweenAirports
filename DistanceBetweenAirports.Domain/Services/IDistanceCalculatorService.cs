using DistanceBetweenAirports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceBetweenAirports.Domain.Services
{
    public interface IDistanceCalculatorService
    {
        double CalculateDistance(Airport airport1, Airport airport2);
    }
}
