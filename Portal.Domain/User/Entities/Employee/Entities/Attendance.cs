using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Attendance 
{
    public int Id { get; private set; }
    public DateTime? ArrivedAt { get; private set; }
    public DateTime? LeaveAt { get; private set; }
    public AttendaceStatus AttendaceStatus { get; private set; }
    public UserId EmployeeId { get; private set; } = null!;
    public Employee Employee { get; private set; }
    public Claim? Claim { get; private set; }

#pragma warning disable CS8618
    private Attendance() { }
#pragma warning restore CS8618

    public void SetAttendanceStatus()
    {
        if (ArrivedAt is null || LeaveAt is null)
        {
            AttendaceStatus = AttendaceStatus.Absent;
        }

        if (ArrivedAt.Hour <= Employee.MustSignInBefore.Hour && ArrivedAt.Minute <= Employee.MustSignInBefore.Minute)
        {
            AttendaceStatus = AttendaceStatus.Attend;
        }
        
    }

}
