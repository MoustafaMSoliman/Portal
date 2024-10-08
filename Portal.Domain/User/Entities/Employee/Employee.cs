﻿
using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Common.Models;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;


namespace Portal.Domain.User.Entities.Employee;

public class Employee : User
{
    public DateTime HireDate { get; private set; }
    public List<Vacation> Vacations { get; private set; }

    public List<Attendance> Attendances { get; private set; }
    public AggregateRootId<Guid> DepartmentId { get; private set; } = null!;
    public Department.Department Department { get; private set; } = null!;
    //public ICareerGroup CareerGroup { get; private set; }
    
    

#pragma warning disable CS8618
    protected internal Employee() { }
#pragma warning restore CS8618
    protected internal Employee(UserId id, DepartmentId departmentId,
        DateTime hireDate)
    {
        Id = id;
        DepartmentId = departmentId;
        HireDate = hireDate;
    }
    protected internal Employee(
        User user,
        DepartmentId departmentId,
        DateTime hireDate
        //, ICareerGroup careerGroup
        ) : base((UserId)user.Id, user.Email, user.Password, user.UserType, user.UserRole, user.UserStatus,user.Profile, user.Code, user.CreatedBy, user.UpdatedBy)
    {
        DepartmentId = departmentId;
        HireDate = hireDate;
        //CareerGroup = careerGroup;
        
    }
    public static Employee Create(
        User user,
        DepartmentId departmentId,
        DateTime hireDate
        //, ICareerGroup careerGroup
        )
        => new(
            user,
            departmentId,
            hireDate
            //,careerGroup
            );
    public static Employee Create(
        UserId userId,
        DepartmentId departmentId,
        DateTime hireDate
        //, ICareerGroup careerGroup
        )
        => new(
            userId,
            departmentId,
            hireDate
            //,careerGroup
            );

    public int GetTotalYearsAtWork()
        => (int)(DateTime.Now.Year - HireDate.Year);
    
    public void MonthlyResetting()
    {
        
    }
    public void ChangeDepartment(DepartmentId departmentId)
    {
        DepartmentId = departmentId;
    }
   
}
