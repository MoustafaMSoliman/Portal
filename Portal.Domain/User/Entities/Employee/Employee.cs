
using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;


namespace Portal.Domain.User.Entities.Employee;

public class Employee : User
{
    public DateTime HireDate { get; private set; }

    private  readonly List<int> _vacationsids = new();
    public List<int> VacationsIds => _vacationsids;
    public List<Vacation> Vacations { get; private set; }

    private readonly List<int> attendanceIds = new();
    public IReadOnlyList<int> AttendanceIds => attendanceIds.AsReadOnly();
    public List<Attendance> Attendances { get; private set; }
    public DepartmentId DepartmentId { get; private set; } = null!;
    public Department.Department Department { get; private set; } = null!;
    //public ICareerGroup CareerGroup { get; private set; }


#pragma warning disable CS8618
    protected internal Employee() { }
#pragma warning restore CS8618
   
    protected internal Employee(
        UserId userId, Email email, string password, UserType userType, UserRole role, Profile profile, int ? code, UserId? createdBy, UserId? updatedBy,
        DepartmentId departmentId,
        DateTime hireDate
        //, ICareerGroup careerGroup
        ) : base(userId, email, password, userType, role, profile, code, createdBy, updatedBy)
    {
        DepartmentId = departmentId;
        HireDate = hireDate;
        //CareerGroup = careerGroup;
    }
    public static Employee Create(
        User user,
        DepartmentId departmentId,
        DateTime hireDate
        //, ICareerGroup careerGroup
        )
        => new(
            (UserId)user.Id,user.Email,user.Password,user.UserType,user.UserRole,user.Profile,user.Code,user.CreatedBy,user.UpdatedBy,
            departmentId,
            hireDate
            //,careerGroup
            );

    public int GetTotalYearsAtWork()
        => (int)(DateTime.Now.Year - HireDate.Year);
    
    public void MonthlyResetting()
    {
        
    }
    public void ChangeDepartment(DepartmentId departmentId)
    {
        DepartmentId = departmentId;
    }
   
}
