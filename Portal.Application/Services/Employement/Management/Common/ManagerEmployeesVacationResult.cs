using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Domain.User.Entities.Employee.Entities;

namespace Portal.Application.Services.Employement.Management.Common;

public record ManagerEmployeesVacationResult
(
    Manager Manager,
    List<ManagerEmployeeWithVacation> Employees
);
public record ManagerEmployeeWithVacation
 (
      Guid EmployeeId,
      string EmployeeFirstName,
      List<VacationResult>? Vacations
);


