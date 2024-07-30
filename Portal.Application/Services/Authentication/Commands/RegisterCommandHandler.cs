using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Authentication;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Authentication.Common;
using Portal.Domain.User.ValueObjects;
using Portal.Domain.Common.Errors;
using Portal.Domain.User;
using Address=Portal.Domain.User.ValueObjects.Address;
using Microsoft.AspNetCore.Identity.Data;
using System.Net;
using Portal.Domain.Common.Enums;

namespace Portal.Application.Services.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJWTGenerator _jwtGenerator;
    

    public RegisterCommandHandler(IUserRepository userRepository, IJWTGenerator jwtGenerator)
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
    }
    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand registerRequest, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(registerRequest.Email) is not null)
        {
            return Errors.UserErrors.DuplicateEmail;
        }
        
        var profile = CreateNewProfile(registerRequest);

        User user = User.Create(
            registerRequest.UserName, 
            registerRequest.Email,
            registerRequest.Password, 
            Role.Employee,
            profile
         );
        _userRepository.AddUser(user);
        var Token = _jwtGenerator.GenerateToken(user);
        return new AuthResult(user, Token);
    }

    private Domain.User.ValueObjects.Address CreateNewAddress(RegisterCommand registerRequest)
    {
        return Domain.User.ValueObjects.Address.Create(
        registerRequest.Address.Street,
        registerRequest.Address.City,
        registerRequest.Address.State,
        registerRequest.Address.PostalCode,
        registerRequest.Address.Country
        );
    }
    private Profile CreateNewProfile(RegisterCommand registerRequest) {
        var address = CreateNewAddress(registerRequest);
        return Profile.Create(
                registerRequest.FirstName,
                registerRequest.LastName,
                registerRequest.DateOfBirth,
                registerRequest.ContactNumber,
                address
                );
    }
}
