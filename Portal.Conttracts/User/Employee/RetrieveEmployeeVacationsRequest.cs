namespace Portal.Conttracts.User.Employee;

public record RetrieveEmployeeVacationsRequest
(
    Guid EmployeeId,
    DateTime? StartFrom,
    DateTime? EndAt
);