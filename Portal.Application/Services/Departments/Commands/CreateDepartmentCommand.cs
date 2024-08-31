using ErrorOr;
using MediatR;
using Portal.Application.Services.Departments.Common;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Departments.Commands;

public record CreateDepartmentCommand
(
    UserId AdminId,
    string DepartmentName,
    UserId? ManagerId
):IRequest<ErrorOr<CreateDepartmentResult>>;
