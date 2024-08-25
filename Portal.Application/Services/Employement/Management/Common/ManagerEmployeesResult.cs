using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Common;

public record ManagerEmployeesResult
(
    Employee Manager,
    List<ManagerEmployee> Employees
);
public record ManagerEmployee
    (
      Guid EmployeeId,
      string EmployeeFirstName
    );
