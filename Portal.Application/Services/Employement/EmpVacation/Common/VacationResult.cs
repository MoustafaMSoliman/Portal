using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.EmpVacation.Common;

public record VacationResult
(
    //Vacation Vacation
    VacationId Id,
    //UserId EmployeeId,
    //string EmployeeName,
    VacationType VacationType,
    VacationStatus? VacationStatus,
    DateTime StartFrom,
    DateTime EndAt,
    int TotalVacationDays,
    UserId? AcceptedBy,
    DateTime? AcceptedOn,
    UserId? ApprovedBy,
    DateTime? ApprovedOn,
    UserId? RejectedBy,
    DateTime? RejectedOn
);
