namespace Portal.Conttracts.Authentication;

public record AuthenticationResult
(
    string FirstName,
    string MiddleName,
    string LastName,
    string ArabicName,
    string Nationality,
    long NationalId,
    string Gender,
    DateTime DateOfBirth,
    string ContactNumber,
    //AddressResult Address,
    string Role,
    string Email,
    string Token
);





