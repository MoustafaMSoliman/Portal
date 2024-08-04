using ErrorOr;
using MediatR;
using Portal.Application.Services.Authentication.Common;
using Portal.Domain.Common.Enums;
namespace Portal.Application.Services.Authentication.Commands;

public record RegisterCommand
(
    int? Code,
    string FirstName,
    string MiddleName,
    string LastName,
    string ArabicName,
    string Nationality,
    long NationalId,
    Gender Gender,
    DateTime DateOfBirth,
    string ContactNumber,
    AddressCommand Address,
    RoleEnum Role,
    string Email,
    string Password
  
):IRequest<ErrorOr<AuthResult>>;
public record AddressCommand
(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country

);
