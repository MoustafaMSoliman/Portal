namespace Portal.Conttracts.User.Employee;

public record VacationResponse
(
    string Id,
    string VacationType,
    string? VacationStatus,
    DateTime StartFrom,
    DateTime EndAt,
    int TotalVacationDays,
    string? AcceptedBy,
    DateTime? AcceptedOn,
    string? ApprovedBy,
    DateTime? ApprovedOn,
    string? RejectedBy,
    DateTime? RejectedOn
);
