using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using DistanceBetweenAirports.Domain.Services;
using DistanceBetweenAirports.Domain.Entities;
using DistanceBetweenAirports.App.Commands;
using DistanceBetweenAirports.App.Queries;
using DistanceBetweenAirports.Domain.Exceptions;
namespace DistanceBetweenAirports.Tests.Commands
{
    public class CalculateDistanceCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsCorrectDistance()
        {
            // Arrange
            var mockAirportService = new Mock<IAirportService>();
            var mockDistanceCalculatorService = new Mock<IDistanceCalculatorService>();

            mockAirportService.Setup(s => s.GetAirportAsync(It.IsAny<string>())).ReturnsAsync(new Airport
            {
                Location = new Location
                {
                    Latitude = 52.308601,
                    Longitude = 4.76389
                }

            });

            mockDistanceCalculatorService.Setup(s => s.CalculateDistance(It.IsAny<Airport>(), It.IsAny<Airport>())).Returns(3636.15);

            var handler = new CalculateDistanceCommandHandler(mockAirportService.Object, mockDistanceCalculatorService.Object);
            var airport1 = new Airport { Iata = "AMS" };
            var airport2 = new Airport { Iata = "JFK" };
            var command = new CalculateDistanceCommand { Airport1 = airport1, Airport2 = airport2 };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(3636.15, result.Distance);
        }

        [Fact]
        public async Task Handle_ThrowsException_WhenAirportNotFound()
        {
            // Arrange
            var mockAirportService = new Mock<IAirportService>();
            var mockDistanceCalculatorService = new Mock<IDistanceCalculatorService>();

            mockAirportService.Setup(s => s.GetAirportAsync(It.IsAny<string>())).ReturnsAsync((Airport)null);

            var handler = new GetAirportQueryHandler(mockAirportService.Object);
            var query = new GetAirportQuery("XYZ");

            // Act & Assert
            await Assert.ThrowsAsync<AirportNotFoundException>(async () => await handler.Handle(query, CancellationToken.None));
        }
    }
}
