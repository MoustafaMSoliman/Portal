using Portal.Domain.Common.Enums;
using Portal.Domain.Course;
using Portal.Domain.Course.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities;

public class Student:User
{
    private readonly List<CourseId> _coursesIds=new();
    public IReadOnlyList<CourseId> CoursesIds=> _coursesIds.AsReadOnly();
    public Advisor? Advisor { get; private set; }
    public StudentsStatus? Status { get; private set; }
    public string HighSchool { get; private set; } = null!;
    public short CheatWarnings {  get; private set; }
    public Term? Term { get; private set; }

}
