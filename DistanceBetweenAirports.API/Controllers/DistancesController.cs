using DistanceBetweenAirports.App.Models;
using DistanceBetweenAirports.App.Commands;
using DistanceBetweenAirports.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidation;

namespace DistanceBetweenAirports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistancesController : ControllerBase
    {
        private readonly IMediator _mediator;


        public DistancesController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet("{iataCode1}/{iataCode2}")]
        public async Task<ActionResult<DistanceResult>> GetDistance(string iataCode1, string iataCode2)
        {
            var airport1 = await _mediator.Send(new GetAirportQuery(iataCode1));
            var airport2 = await _mediator.Send(new GetAirportQuery(iataCode2));

            if(airport1 == null || airport2 == null)
            {
                return NotFound("One or both airports not found");
            }


            var command = new CalculateDistanceCommand
            {
                Airport1 = airport1,
                Airport2 = airport2,
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
