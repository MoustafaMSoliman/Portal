using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.Common.Errors;
using Portal.Domain.Common.Models;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;
using System.Runtime.CompilerServices;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Vacation :Entity<VacationId>
{
    public VacationType VacationType { get; private set; }
    public VacationStatus? VacationStatus { get; private set; }
    public UserId EmployeeId { get; private set; } = null!;
    public DateTime StartFrom { get; private set; }
    public DateTime EndAt { get; private set; }
    public int TotalVacationDays { get; private set; }
    public UserId? AcceptedBy { get; private set; }
    public DateTime? AcceptedOn { get; private set; }
    public UserId? ApprovedBy { get; private set; }
    public DateTime? ApprovedOn { get; private set; }
    public UserId? RejectedBy { get; private set; }
    public DateTime? RejectedOn { get;  private set; }

#pragma warning disable CS8618
    private Vacation() { }
#pragma warning restore CS8618

    private Vacation(VacationId id, VacationType vacationType,  UserId employeeId,
        DateTime startFrom, DateTime endAt)
        : base(id)
    {
        VacationType = vacationType;
        VacationStatus = Common.Enums.User.Employee.VacationStatus.Pending;
        EmployeeId = employeeId;
        StartFrom = startFrom;
        EndAt = endAt;
        TotalVacationDays = GetTotalVacationDays();
    }
    private Vacation(VacationId id, VacationType vacationType, VacationStatus? vacationStatus, UserId employeeId,
        DateTime startFrom, DateTime endAt)
        :base(id)
    {
        VacationType = vacationType;
        VacationStatus = vacationStatus ?? Common.Enums.User.Employee.VacationStatus.Pending;
        EmployeeId = employeeId;
        StartFrom = startFrom;
        EndAt = endAt;
        TotalVacationDays = GetTotalVacationDays();
    }
    private Vacation(VacationId id, VacationType vacationType, VacationStatus? vacationStatus, UserId employeeId,
        DateTime startFrom, DateTime endAt, 
        UserId? acceptedBy, DateTime? acceptedOn, UserId? approvedBy, DateTime? approvedOn,
        UserId? rejectedBy, DateTime? rejectedOn)
        : base(id)

    {
        VacationType = vacationType;
        VacationStatus= vacationStatus ?? Common.Enums.User.Employee.VacationStatus.Pending;
        EmployeeId = employeeId;
        StartFrom = startFrom;
        EndAt = endAt;
        AcceptedBy = acceptedBy;
        AcceptedOn = acceptedOn;
        ApprovedBy = approvedBy;
        ApprovedOn = approvedOn;
        RejectedBy = rejectedBy;
        RejectedOn = rejectedOn;
    }
    public static Vacation Create(VacationType vacationType,  UserId employeeId,
        DateTime startFrom, DateTime endAt
       )
        => new(VacationId.CreateUnique(), vacationType,  employeeId,
         startFrom, endAt);
    public static Vacation Create( VacationType vacationType, VacationStatus? vacationStatus, UserId employeeId,
        DateTime startFrom, DateTime endAt
       )
        => new(VacationId.CreateUnique(), vacationType,vacationStatus,  employeeId,
         startFrom,  endAt);
    public  void EditVacationDate(DateTime startFrom, DateTime endAt)
    {
        StartFrom = startFrom;
        EndAt = endAt;
    }
    public void EditVacationStatus(VacationStatus status)
    {
        this.VacationStatus = status;
        
    }
    public  int GetTotalVacationDays() => (int)(EndAt - StartFrom).TotalDays+1;

    
}
