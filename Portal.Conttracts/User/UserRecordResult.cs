using Portal.Conttracts.Authentication;
using System.Reflection;

namespace Portal.Conttracts.User;

public record UserRecordResult
(
    string UserId,
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
    int Code,
    string Email,
    string Password,
    string Role,
    string Status,
    List<Vacation> Vacations
    );

public record Vacation
    (
      int Id,
      string VacationType,
      string VacationStatus,
      DateTime StartFrom,
      DateTime EndAt
    );
public record AddressRecordResult
    (
     string Street,
    string City,
    string State,
    string PostalCode,
    string Country
    );