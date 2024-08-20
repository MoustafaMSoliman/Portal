using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Career;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;
namespace Portal.Domain.User.Entities.Employee.Entities;

public class Manager : Employee
{
    
    
    

#pragma warning disable CS8618
    protected Manager() { }
#pragma warning restore CS8618

    protected Manager(Employee employee, DepartmentId departmentId)
        : base((UserId)employee.Id,employee.Email,employee.Password,employee.UserType,RoleEnum.Manager,employee.Profile,
            employee.Code,employee.CreatedBy,employee.UpdatedBy,departmentId,employee.HireDate,employee.CareerGroup)
    {
        employee.ChangeDepartment(departmentId);

    }
    
    public static Manager Create(
        Employee employee,
        DepartmentId departmentId
        )
        => new(employee, departmentId);
   

}
