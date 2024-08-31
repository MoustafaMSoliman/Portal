using Portal.Domain.Common.AccessContorl;
using Portal.Domain.Department;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Administrator;

public class Administrator : User
{
    private readonly List<AdministratorDepartment> _administratorDepartments = new();
    public List<AdministratorDepartment> AdministratorDepartments => _administratorDepartments;

#pragma warning disable CS8618
    private Administrator(){}
#pragma warning restore CS8618
    private Administrator(Employee.Employee employee) 
        :base((UserId)employee.Id, 
            employee.Email, 
            employee.Password, 
            employee.UserType,
            employee.UserRole,
            employee.UserStatus,
            employee.Profile,
            employee.Code,
            employee.CreatedBy, employee.UpdatedBy)
    {
    }

    
    public static Administrator Create(Employee.Employee employee)
        => new(employee);
}
