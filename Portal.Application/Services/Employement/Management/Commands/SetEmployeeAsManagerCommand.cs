using ErrorOr;
using MediatR;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Commands;

public record SetEmployeeAsManagerCommand
(
    UserId AdminId,
    UserId EmployeeId
):IRequest<ErrorOr<SetEmployeeAsManagerResult>>;
