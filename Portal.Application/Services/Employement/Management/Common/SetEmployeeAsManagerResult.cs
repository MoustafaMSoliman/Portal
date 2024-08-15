using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Common;

public record SetEmployeeAsManagerResult
(
    UserId AdminId,
    User Manager
);
