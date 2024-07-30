using ErrorOr;
using MediatR;
using Portal.Application.Services.Authentication.Common;

namespace Portal.Application.Services.Authentication.Commands;

public record RegisterCommand
(
    string FirstName,
    string LastName,
    string UserName,
    DateTime DateOfBirth,
    string ContactNumber,
    string Email,
    string Password, 
    Address Address
):IRequest<ErrorOr<AuthResult>>;

public record Address
(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country

);