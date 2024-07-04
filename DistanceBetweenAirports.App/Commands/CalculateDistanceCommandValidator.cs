using FluentValidation;
namespace DistanceBetweenAirports.App.Commands
{
    public class CalculateDistanceCommandValidator : AbstractValidator<CalculateDistanceCommand>
    {
        public CalculateDistanceCommandValidator() 
        {
            RuleFor(x => x.Airport1).NotNull().WithMessage("First airport is required.");
            RuleFor(x => x.Airport2).NotNull().WithMessage("Second airport is required.");
        }
    }
}
