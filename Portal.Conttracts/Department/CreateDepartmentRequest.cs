namespace Portal.Conttracts.Department;
public record CreateDepartmentRequest
(
    Guid AdminId,
    string DepartmentName,
    Guid? ManagerId 
);
