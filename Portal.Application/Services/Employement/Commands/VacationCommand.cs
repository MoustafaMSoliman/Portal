using ErrorOr;
using MediatR;
using Portal.Application.Services.Employement.Common;
using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Commands;

public record VacationCommand
(
    UserId EmployeeId,
    DateTime StartFrom,
    DateTime EndAt,
    VacationType VacationType,
    VacationStatus VacationStatus
):IRequest<ErrorOr<VacationResult>>;