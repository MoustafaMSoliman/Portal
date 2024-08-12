using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Career;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;
namespace Portal.Domain.User.Entities.Employee.Entities;

public class Manager : Employee
{
    
    
    

#pragma warning disable CS8618
    private Manager() { }
#pragma warning restore CS8618
    private Manager(Employee employee)
        :base(
            User.Create(
                employee.Email, 
                employee.Password,
                Common.Enums.UserType.Employee,
                Common.Enums.RoleEnum.Manager,
                employee.Profile,
                employee.Code,
                UserId.Create(Guid.Empty),
                UserId.Create(Guid.Empty)

                ), 
            employee.DepartmentId,
            employee.HireDate,
            employee.CareerGroup
             )
    { 
       
    }
    public static Manager Create(
        Employee employee
        )
        => new(employee);
   

}
