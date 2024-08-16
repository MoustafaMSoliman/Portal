using ErrorOr;
using MediatR;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Commands;

public record CreateDepartmentCommand
(
    string DepartmentName,
    UserId? ManagerId,
    UserId? SecreteryId
):IRequest<ErrorOr<CreateDepartmentResult>>;
