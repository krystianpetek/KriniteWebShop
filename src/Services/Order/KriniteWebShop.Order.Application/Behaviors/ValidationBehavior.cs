using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace KriniteWebShop.Order.Application.Behaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
	{
		_validators = validators ?? throw new ArgumentNullException(nameof(validators));
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		if (_validators.Any())
		{
			ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);

			ICollection<ValidationResult> validationRequests = await Task.WhenAll(
				_validators.Select(validate => validate.ValidateAsync(context, cancellationToken)));

			ICollection<ValidationFailure> failures = validationRequests.SelectMany(error => error.Errors).Where(error => error != null).ToList();

			if (failures.Count != 0)
				throw new ValidationException(failures);
		}

		return await next();
	}
}
