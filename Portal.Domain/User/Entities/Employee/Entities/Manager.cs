using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Manager : Employee
{
    public string Office { get; set; }

#pragma warning disable CS8618
    private Manager() { }
#pragma warning restore CS8618
    private Manager(Employee employee, string office) 
      :base((UserId)employee.Id,(DepartmentId)employee.DepartmentId,employee.HireDate)
    {
        Office = office;
    }

    public static Manager Create(Employee employee, string office)
        => new(employee,office);
}
