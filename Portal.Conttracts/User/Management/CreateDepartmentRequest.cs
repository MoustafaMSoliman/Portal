namespace Portal.Conttracts.User.Management;

public record CreateDepartmentRequest
(
  string DepartmentName,
  string? ManagerId,
  string? SecreteryId
);

