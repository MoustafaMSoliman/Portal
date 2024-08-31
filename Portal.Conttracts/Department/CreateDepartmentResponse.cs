namespace Portal.Conttracts.Department;
public record CreateDepartmentResponse
(
    string DepartmentId,
    string DepartmentName,
    string ManagerId
);
