using ErrorOr;
using FluentValidation;
using MediatR;
using Portal.Application.Services.Authentication.Commands;
using Portal.Application.Services.Authentication.Common;

namespace Portal.Application.Common.Behaviours;

public class ValidateBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidateBehaviour(IValidator<TRequest>? validator=null)
    {
        _validator = validator;
    }
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        //Before Validate
        if (_validator is null) { return await next(); }
        var validateResult = await _validator.ValidateAsync(request,cancellationToken);
        if (validateResult.IsValid)
        {
            return await next();
            
        }
        var errors = validateResult.Errors
            .ConvertAll(
              validationFailure => Error.Validation(
                validationFailure.PropertyName, validationFailure.ErrorMessage
                )
            );
        //After Validate
        return (dynamic) errors;
    }
}
