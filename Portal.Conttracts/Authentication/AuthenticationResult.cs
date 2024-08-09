using Portal.Conttracts.User;

namespace Portal.Conttracts.Authentication;

public record AuthenticationResult
(
    string UserId,
    int Code,
    string FirstName,
    string MiddleName,
    string LastName,
    string ArabicName,
    string Nationality,
    long NationalId,
    string Gender,
    DateTime DateOfBirth,
    long ContactNumber,
    string Email,
    string UserType,
    string Role,
    string Token
);





