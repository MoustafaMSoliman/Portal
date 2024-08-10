using ErrorOr;
using MediatR;
using Portal.Application.Services.Employement.EmpVacation.Common;

namespace Portal.Application.Services.Employement.EmpVacation.Queries;

public record VacationQuery
(
    string EmployeeId,
    string VacationId
):IRequest<ErrorOr<VacationResult>>;
