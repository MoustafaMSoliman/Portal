using Portal.Conttracts.Authentication;
using System.Reflection;

namespace Portal.Conttracts.User;

public record UserRecordResult
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
    AddressRecordResult Address,
    string UserName,
    int Code,
    string Email,
    string Password,
    string Role,
    string Status
    );
public record AddressRecordResult
    (
     string Street,
    string City,
    string State,
    string PostalCode,
    string Country
    );