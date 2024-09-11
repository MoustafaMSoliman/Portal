using ErrorOr;
using MediatR;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Commands;

public record ChangeVacationStatusCommand
(
    VacationId VacationId,
    UserId ManagerId,
    VacationStatus VacationStatus
):IRequest<ErrorOr<VacationResult>>;
