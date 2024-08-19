using ErrorOr;
using MediatR;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.EmpVacation.Queries;

public record GetEmployeeVacationsQuery
(
    UserId EmployeeId
    ,
    DateTime? StartFrom,
    DateTime? EndAt

) :IRequest<ErrorOr<RetrieveVacationsResult>>;