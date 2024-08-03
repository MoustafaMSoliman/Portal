using FluentValidation;

namespace Portal.Application.Services.Authentication.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        //RuleFor(c=>c.Profile.FirstName).NotEmpty().MaximumLength(20);
        //RuleFor(c=>c.Profile.LastName).NotEmpty().MaximumLength(20);
        //RuleFor(c=>c.Email).NotEmpty().EmailAddress();
        //RuleFor(c=>c.Password).NotEmpty().MinimumLength(8);
    }
    
}
