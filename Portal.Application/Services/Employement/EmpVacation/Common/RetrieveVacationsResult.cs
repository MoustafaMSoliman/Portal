using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.EmpVacation.Common;

public record RetrieveVacationsResult
(
   UserId EmployeeId,
   string EmployeeName,
   List<VacationResult>? Vacations 
);
