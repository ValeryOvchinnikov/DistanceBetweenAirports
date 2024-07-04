using FluentValidation;

namespace DistanceBetweenAirports.App.Queries
{
    public class GetAirportQueryValidator : AbstractValidator<GetAirportQuery>
    {
        public GetAirportQueryValidator()
        {
            RuleFor(x => x.IataCode)
                .NotEmpty().WithMessage("IATA code is required.")
                .Length(3).WithMessage("IATA code must be 3 characters long.");
        }
    }
}
