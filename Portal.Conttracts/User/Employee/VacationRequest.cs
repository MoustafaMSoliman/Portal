namespace Portal.Conttracts.User.Employee;

public record VacationRequest
(
    Guid EmployeeId,
    DateTime StartFrom,
    DateTime EndAt,
    string VacationType
);
