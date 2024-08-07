namespace Portal.Domain.User.Entities;

public class Advisor:AcademicStaff
{
    private readonly List<Student> _students = new();
    public IReadOnlyList<Student> Students => _students;


}
