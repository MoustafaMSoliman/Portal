using Portal.Domain.Common.Enums;
using Portal.Domain.User;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities;

public class Employee : User
{
    EmployeesDepartments EmployeesDepartments { get; set; }
    DateTime HireDate { get; set; }
#pragma warning disable CS8618
    protected internal Employee() { }
#pragma warning restore CS8618
    protected internal Employee(
        UserId userId,
        string username,
        string email,
        string password,
        Role role,
        Profile profile,
        EmployeesDepartments employeesDepartments,
        DateTime hireDate
        ) : base(userId, username, email, password, role, profile)
    {
        EmployeesDepartments = employeesDepartments;
        HireDate = hireDate;
    }

    public static Employee Create(
        UserId userId,
        string username,
        string email,
        string password,
        Role role,
        Profile profile,
        EmployeesDepartments employeesDepartments,
        DateTime hireDate)
        => new(
            userId,
            username,
            email,
            password,
            role,
            profile,
            employeesDepartments,
            hireDate
            );


}
