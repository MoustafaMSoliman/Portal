using Portal.Conttracts.User.Employee;

namespace Portal.Conttracts.User.Management;

public record ManagerEmployeesVacationsResponse
(
    string ManagerId,
    string ManagerFirstName,
    string ManagerLastName,
    List<ManagerEmployeeVacationsResponse> Employees
);
public record ManagerEmployeeVacationsResponse
(
      string EmployeeId,
      string EmployeeFirstName,
      List<VacationResponse>? Vacations
);
