using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Sistema_Bancario.Application
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommandBase
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context))
                );

            var errors = validationFailures.Where(validationResult => !validationResult.IsValid).
                 SelectMany(validationResult => validationResult.Errors).
                 Select(validationFailures => new ValidationError(
                     validationFailures.PropertyName,
                     validationFailures.ErrorMessage
                     )).ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            return await next();
        }
    }
}
