using ErrorOr;
using MediatR;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Queries;

public record GetManagerEmployeesQuery
(
    UserId ManagerId

):IRequest<ErrorOr<ManagerEmployeesResult>>;
