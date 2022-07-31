using FluentValidation;
using MediatR;
using ValidationException = CleanArchitecture.Application.Common.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Common.Behaviours;

//this behaviour if any operation occur on Command that that validator attach to like CreateTodoItemCommandValidator that attach to CreateTodoItemCommand
//we are using fluent Validation for each command class and hit when this command make saveChagnes 
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        //this call the fluent validation which execute the valiation rules for the Command class attach to ,if validation occur it create new instance called ValidationException
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);
        }
        return await next();
    }
}
