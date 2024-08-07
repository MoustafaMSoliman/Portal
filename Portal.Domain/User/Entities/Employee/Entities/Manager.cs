using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Manager : User
{
    private readonly List<UserId> _employeesIds = new();
    public IReadOnlyList<UserId> EmployeesIds => _employeesIds.AsReadOnly();
    public DepartmentId DepartmentId { get; set; } = null!;

#pragma warning disable CS8618
    private Manager() { }
#pragma warning restore CS8618
    private Manager(DepartmentId departmentId, List<UserId> employeesIds)
    { 
        DepartmentId = departmentId;
        _employeesIds = employeesIds;
    }
    
}
