using DistanceBetweenAirports.Domain.Entities;
using DistanceBetweenAirports.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceBetweenAirports.Infrastructure.Services
{
    public class DistanceCalculatorService : IDistanceCalculatorService
    {
        public double CalculateDistance(Airport airport1, Airport airport2)
        {
            double R = 3958.8;

            double dLat = ToRadians(airport2.Location.Latitude - airport1.Location.Latitude);
            double dLon = ToRadians(airport2.Location.Longitude - airport1.Location.Longitude);

            double lat1 = ToRadians(airport1.Location.Latitude);
            double lat2 = ToRadians(airport2.Location.Latitude);

            double a = Math.Sin(dLat/2)*Math.Sin(dLat/2)+
                Math.Sin(dLon/2) * Math.Sin(dLon/2) * Math.Cos(lat1) * Math.Cos(lat2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
        private double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
