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
    public AggregateRootId<Guid>? ManagerId { get; private set; } = null!;
    public Manager? Manager { get; private set; } = null!;

    private readonly List<AggregateRootId<Guid>> _employeesIds = new();
    public IReadOnlyList<AggregateRootId<Guid>> EmployeesIds => _employeesIds.AsReadOnly();
    private  List<Employee> _employees = new();
    public List<Employee> Employees => _employees;

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
        DepartmentName = departmentName;
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
}
