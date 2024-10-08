﻿using Portal.Domain.Common.AccessContorl;
using Portal.Domain.Common.Models;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.Department;

public class Department : AggregateRoot<DepartmentId, Guid>
{
    public string Name { get; private set; } = null!;
    public AggregateRootId<Guid>? ManagerId { get; private set; } = null!;
    public Manager? Manager { get; private set; } = null!;

    private  List<Employee> _employees = new();
    public List<Employee> Employees => _employees;
    private readonly List<AdministratorDepartment> _administratorDepartments = new();
    public List<AdministratorDepartment> AdministratorDepartments => _administratorDepartments;

    //public UserId? SecreteryId { get; private set; } = null!;
    //public Secretery? Secretery { get; private set; } = null!;

#pragma warning disable CS8618
    private Department() { }
#pragma warning restore CS8618
    private Department(DepartmentId id,string departmentName, UserId? managerId
        //,UserId? secreteryId
        )
    {
        Id = id;
        Name = departmentName;
        ManagerId = managerId;
        //SecreteryId = secreteryId;
    }
    public static Department Create(string departmentName, UserId? managerId
        //, UserId? secreteryId
        )
        => new(DepartmentId.CreateUnique(),departmentName, managerId
            //, secreteryId
            );
    public static void AddEmployee(DepartmentId id, Employee employee)
    {
        
    }
    public  void SetDepartmentManager(Manager? manager)
    {
        ManagerId = manager.Id;
        Manager = manager;
        
    }
}
