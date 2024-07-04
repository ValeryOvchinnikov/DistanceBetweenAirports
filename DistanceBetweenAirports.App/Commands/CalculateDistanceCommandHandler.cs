using DistanceBetweenAirports.App.Models;
using DistanceBetweenAirports.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceBetweenAirports.App.Commands
{
    public class CalculateDistanceCommandHandler : IRequestHandler<CalculateDistanceCommand, DistanceResult>
    {
        private readonly IDistanceCalculatorService _distanceCalculatorService;

        public CalculateDistanceCommandHandler(IAirportService airportService, IDistanceCalculatorService distanceCalculatorService)
        {
            _distanceCalculatorService = distanceCalculatorService ?? throw new ArgumentNullException(nameof(distanceCalculatorService));
        }

        public Task<DistanceResult> Handle(CalculateDistanceCommand request, CancellationToken cancellationToken)
        {
            var distance = _distanceCalculatorService.CalculateDistance(request.Airport1, request.Airport2);

            return Task.FromResult(new DistanceResult { Distance = distance });
        }
    }
}
