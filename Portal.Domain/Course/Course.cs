using Portal.Domain.Common.Models;
using Portal.Domain.Course.ValueObjects;
using Portal.Domain.Department;
using Portal.Domain.Department.ValueObjects;

namespace Portal.Domain.Course;

public class Course: AggregateRoot<CourseId,Guid>
{
    string Code { get; init; } = null!;
    string Name { get; init; } = null!;
    DepartmentId DepartmentId { get; init; } = null!;
    Department.Department Department { get; init; } = null!;

}
