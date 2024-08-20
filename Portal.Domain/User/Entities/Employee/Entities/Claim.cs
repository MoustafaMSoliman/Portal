using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Claim
{
    public int Id { get; private set; }
    public ClaimType Type { get; private set; }
    public int AttendanceId { get; private set; }
    public UserId RequestedBy { get; private set; } = null!;
    public UserId? ApprovedBy { get; private set; }
    public UserId? RejectedBy { get; private set; }

#pragma warning disable CS8618
    private Claim() { }
#pragma warning restore Cs8618
    private Claim(int attendanceId, UserId requestedBy)
    {
        AttendanceId = attendanceId;    
        RequestedBy = requestedBy;
    }

    public static Claim Create(int attendanceId, UserId requestedBy)
        =>new(attendanceId, requestedBy);
}
