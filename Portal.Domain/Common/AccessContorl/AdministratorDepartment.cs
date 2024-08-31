using Portal.Domain.Common.Models;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Administrator;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.Common.AccessContorl;

public class AdministratorDepartment
{
    public AggregateRootId<Guid> AdminId { get; private set; }
    public Administrator Administrator { get; private set; }
    public AggregateRootId<Guid> DepartmentId { get; private set; }
    public Department.Department Department { get; private set; }

#pragma warning disable Cs8618
    private AdministratorDepartment() { }
#pragma warning restore CS8618
    private AdministratorDepartment(UserId adminId, Administrator administrator, DepartmentId departmentId, Department.Department department) 
    {
        AdminId = adminId;
        Administrator = administrator;
        DepartmentId = departmentId;
        Department = department;
    }

}
