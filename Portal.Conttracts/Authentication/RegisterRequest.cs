namespace Portal.Conttracts.Authentication;

public record RegisterRequest
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
    Address Address,
    string Role,
    string Email,
    string Password
    
);
public record Address
(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country

);
