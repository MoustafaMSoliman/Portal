namespace Portal.Conttracts.User.Management;

public record ManagerEmployeesResponse
(
    string ManagerId,
    string ManagerFirstName,
    string ManagerLastName,
    List<ManagerEmployeeResponse> Employees
);
public record ManagerEmployeeResponse
    (
      string EmployeeId,
      string EmployeeFirstName
    );
