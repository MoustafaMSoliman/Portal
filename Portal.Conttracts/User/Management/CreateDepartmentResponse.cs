namespace Portal.Conttracts.User.Management;

public record CreateDepartmentResponse
(
    string DepartmentId,
    string DepartmentName,
    string ManagerId,
    string ManagerName,
    string SecreteryId,
    string SecreteryName,
    List<DepartmentEmployees> DepartmentEmployees
);

public record DepartmentEmployees
    (
     string EmployeeId,
     string EmployeeName,
     string Role
);