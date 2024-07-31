using Portal.Domain.Common.Models;
using Portal.Domain.Course.ValueObjects;

namespace Portal.Domain.Course;

public class Course: AggregateRoot<CourseId,Guid>
{
}
