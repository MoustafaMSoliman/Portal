
using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;


namespace Portal.Domain.User.Entities.Employee;

public class Employee : User
{
    public DateTime HireDate { get; private set; }
    public int TotalVacationDays { get; private set; }
    public int TotalVacationDaysNormally { get; private set; }
    public int TotalVacationDaysEmergncy { get; private set; }

    private readonly List<Vacation> _vacations = new();
    public IReadOnlyList<Vacation> VacationsIds => _vacations.AsReadOnly();
    public TimeOnly MustSignInBefore { get; private set; }
    public TimeOnly CanSignOutAfter { get; private set; }
    public int? OvertimeHours {  get; private set; } 
    public int? LateHours { get; private set; }

    private readonly List<int> attendanceIds = new();
    public IReadOnlyList<int> AttendanceIds => attendanceIds.AsReadOnly();
    
    public DepartmentId DepartmentId { get; set; }
    public ICareerGroup CareerGroup { get; private set; }


#pragma warning disable CS8618
    protected internal Employee() { }
#pragma warning restore CS8618
    protected internal Employee(
        User user,
        DepartmentId departmentId,
        DateTime hireDate,
        ICareerGroup careerGroup
        ) : base((UserId)user.Id, user.Email, user.Password, UserType.Employee, RoleEnum.NormalUser, user.Profile, user.Code, user.CreatedBy, user.UpdatedBy)
    {
        DepartmentId = departmentId;
        HireDate = hireDate;
        CareerGroup = careerGroup;
    }

    public static Employee Create(
        User user,
        DepartmentId departmentId,
        DateTime hireDate,
        ICareerGroup careerGroup)
        => new(
            user,
            departmentId,
            hireDate,
            careerGroup
            );

    public int GetTotalYearsAtWork()
        => (int)(DateTime.Now.Year - HireDate.Year);
    public void SetTotalVacationDays()
    {
        if (GetTotalYearsAtWork() > 25) { TotalVacationDaysNormally = 45; TotalVacationDaysEmergncy = 7; }
        else if (GetTotalYearsAtWork() > 10) { TotalVacationDaysNormally = 21; TotalVacationDaysEmergncy = 7; }
        else { TotalVacationDaysNormally = 15; TotalVacationDaysEmergncy = 6; }
        TotalVacationDays = TotalVacationDaysNormally + TotalVacationDaysEmergncy;
    }
    public void MonthlyResetting()
    {
        
    }
}
