using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Attendance 
{
    public int Id { get; private set; }
    public DateTime? ArrivedAt { get; private set; }
    public DateTime? LeaveAt { get; private set; }
    public TimeOnly MustSignInBefore { get; private set; }
    public TimeOnly CanSignOutAfter { get; private set; }
    public AttendaceStatus AttendaceStatus { get; private set; }
    public int? OvertimeHours { get; private set; }
    public int? LateHours { get; private set; }
    public UserId EmployeeId { get; private set; } = null!;
    public Claim? Claim { get; private set; }

#pragma warning disable CS8618
    private Attendance() { }
#pragma warning restore CS8618
    private Attendance(DateTime? arrivedAt, DateTime? leaveAt) 
    {
        ArrivedAt = arrivedAt;
        LeaveAt = leaveAt;
    }

    public void SetAttendanceStatus()
    {
        if (ArrivedAt is null || LeaveAt is null)
        {
            AttendaceStatus = AttendaceStatus.Absent;
        }

       
        
    }

}
