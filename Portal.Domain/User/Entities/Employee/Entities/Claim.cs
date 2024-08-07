using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Claim
{
    public int Id { get; private set; }
    public ClaimType Type { get; private set; }
    public int AttendanceId { get; private set; }
    public UserId RequestedBy { get; private set; } = null!;
    public UserId? ApprovedBy {  get; private set; }

}
