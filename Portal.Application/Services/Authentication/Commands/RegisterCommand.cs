using ErrorOr;
using MediatR;
using Portal.Application.Services.Authentication.Common;
using Portal.Domain.Common.Enums;
using Portal.Domain.User;
using Portal.Domain.User.ValueObjects;
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
    TypeEnum UserType,
    RoleEnum Role,
    string DepartmentName,
    string Email,
    string Password,
    //User User,
    UserId CreatedBy,
    UserId UpdatedBy
  
):IRequest<ErrorOr<AuthResult>>;
public record AddressCommand
(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country

);
