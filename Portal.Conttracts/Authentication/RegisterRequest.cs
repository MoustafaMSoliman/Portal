namespace Portal.Conttracts.Authentication;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string UserName,
    DateTime DateOfBirth,
    string ContactNumber,
    string Email,
    string Password,
    Address Address
);
public record Address
(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country

);
