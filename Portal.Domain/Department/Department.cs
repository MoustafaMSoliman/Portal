using Portal.Domain.Common.Models;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.Department;

public class Department : AggregateRoot<DepartmentId, Guid>
{
    public string DepartmentName { get; private set; } = null!;
    public UserId ManagerId { get; private set; } = null!;

    private readonly List<AcademicStaff> _academicStaffMembers = new();
    public IReadOnlyList<AcademicStaff> AcademicStaffMembers => _academicStaffMembers.AsReadOnly();

    private readonly List<Student> _students = new();
    public IReadOnlyList<Student> Students => _students.AsReadOnly();


}
