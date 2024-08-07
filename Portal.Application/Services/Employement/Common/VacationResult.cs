using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Common;

public record VacationResult
(
    Vacation Vacation
);
