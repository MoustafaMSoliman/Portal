using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Manager : Employee
{
    public string Office { get; set; }
    public bool StillManager { get; private set; }

#pragma warning disable CS8618
    private Manager() { }
#pragma warning restore CS8618
    private Manager(Employee employee, string office, bool stillManager)
        : base(employee, (DepartmentId)employee.DepartmentId,
         DateTime.Now)
    {
        Office = office;
        StillManager = stillManager;
    }
    private Manager(User user ,Employee employee, string office, bool stillManager)
      : base(
         user, 
         (DepartmentId)employee.DepartmentId,
         DateTime.Now)
    {
        Office = office;
        StillManager = stillManager;
    }
    public static Manager Create(Employee employee, string office)
         => new(employee, office,true);
    public static Manager Create(User user,Employee employee, string office)
        => new(user,employee,office,true);
    public void SetStillManager(bool stillManager)
    {
        StillManager = stillManager;
    }
}
