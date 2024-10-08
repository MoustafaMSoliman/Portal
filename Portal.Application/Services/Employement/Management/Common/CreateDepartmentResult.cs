﻿using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;
using Portal.Domain.Department;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Common;

public record CreateDepartmentResult
(
    Department Department
);

