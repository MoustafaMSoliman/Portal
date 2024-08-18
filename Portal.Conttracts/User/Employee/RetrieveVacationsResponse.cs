namespace Portal.Conttracts.User.Employee;

public record RetrieveVacationsResponse
(
    string EmployeeId,
    string EmployeeName,
    List<VacationResponse> Vacations
);

