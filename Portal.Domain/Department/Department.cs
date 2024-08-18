using Portal.Domain.Common.Models;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.Department;

public class Department : AggregateRoot<DepartmentId, Guid>
{
    public string DepartmentName { get; private set; } = null!;
    public UserId? ManagerId { get; private set; } = null!;
    public Manager? Manager { get; private set; } = null!;

    private readonly List<Employee> _employees = new();
    public IReadOnlyList<Employee> Employees => _employees.AsReadOnly();

    public UserId? SecreteryId { get; private set; } = null!;
    public Employee? Secretery { get; private set; } = null!;

#pragma warning disable CS8618
    private Department() { }
#pragma warning restore CS8618
    private Department(DepartmentId id,string departmentName, UserId? managerId,UserId? secreteryId)
    {
        Id = id;
        DepartmentName = departmentName;
        ManagerId = managerId;
        SecreteryId = secreteryId;
    }
    public static Department Create(string departmentName, UserId? managerId, UserId? secreteryId)
        => new(DepartmentId.CreateUnique(),departmentName, managerId, secreteryId);
    public static void AddEmployee(DepartmentId id, Employee employee)
    {
        
    }
}
