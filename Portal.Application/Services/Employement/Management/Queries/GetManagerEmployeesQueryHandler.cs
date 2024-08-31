﻿using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Queries;

public class GetManagerEmployeesQueryHandler : IRequestHandler<GetManagerEmployeesQuery, ErrorOr<ManagerEmployeesResult>>
{
    private readonly IAggregateRootRepository<Employee, UserId, Guid> _employeesRepository;


    public GetManagerEmployeesQueryHandler(
        IAggregateRootRepository<Employee, UserId, Guid> employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }
    public async Task<ErrorOr<ManagerEmployeesResult>> Handle(GetManagerEmployeesQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_employeesRepository.GetById(query.ManagerId).UserRole != Domain.Common.Enums.RoleEnum.Manager)
        {
            return Errors.ManagementErrors.NotManager;
        }
        var manager = _employeesRepository.GetById(query.ManagerId);
        var employees = _employeesRepository.FindAll(e=>e.DepartmentId == manager.DepartmentId).ToList();  
        var emps = new List<ManagerEmployee>();
        foreach (var employee in employees) 
        {
            if(employee.UserRole != Domain.Common.Enums.RoleEnum.Manager)
              emps.Add(new ManagerEmployee( employee.Id.Value, employee.Profile.FirstName ));
            
        }
        
        return new ManagerEmployeesResult(
            manager,
            emps
            );
        
    }
}
