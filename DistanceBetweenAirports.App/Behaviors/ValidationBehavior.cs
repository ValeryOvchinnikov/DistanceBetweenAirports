using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace DistanceBetweenAirports.App.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    { 
        private IEnumerable<IValidator<TRequest>> _validators;


        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

                var failures = validationResults
                    .Where(r => r.Errors.Count > 0)
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Count > 0)
                    throw new FluentValidation.ValidationException(failures);
            }
            return await next();
        }
    }
}
