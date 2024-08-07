namespace Portal.Conttracts.User.Employee;

public record VacationResponse
(
    int Id,
    string EmployeeId,
    string EmployeeName,
    string VacationType,
    string VacationStatus,
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
