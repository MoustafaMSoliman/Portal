using FluentValidation;

namespace Portal.Application.Services.Authentication.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c=>c.FirstName).NotEmpty().MaximumLength(20);
        RuleFor(c=>c.LastName).NotEmpty().MaximumLength(20);
        RuleFor(c=>c.Email).NotEmpty();
        RuleFor(c=>c.Password).NotEmpty().MinimumLength(8);
    }
}
