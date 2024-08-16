﻿using Portal.Domain.Common.Enums;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Common;

public record CreateDepartmentResult
(
    DepartmentId DepartmentId,
    string DepartmentName,
    UserId ManagerId,
    string ManagerName,
    UserId SecreteryId,
    string SecreteryName,
    List<Employee> DepartmentEmployees
);

