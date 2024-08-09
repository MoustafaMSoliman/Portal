﻿using Portal.Domain.Common.Enums.User.Employee;
using Portal.Domain.Common.Errors;
using Portal.Domain.User.ValueObjects;
using System.Runtime.CompilerServices;

namespace Portal.Domain.User.Entities.Employee.Entities;

public class Vacation 
{
    public int Id { get; private set; }
    public VacationType VacationType { get; private set; }
    public VacationStatus VacationStatus { get; private set; }
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

    private Vacation(int id, VacationType vacationType, UserId employeeId,
        DateTime startFrom, DateTime endAt)
    {
        Id = id;
        VacationType = vacationType;
        VacationStatus = VacationStatus.Pending;
        EmployeeId = employeeId;
        StartFrom = startFrom;
        EndAt = endAt;
    }
    private Vacation(int id, VacationType vacationType, UserId employeeId,
        DateTime startFrom, DateTime endAt, 
        UserId? acceptedBy, DateTime? acceptedOn, UserId? approvedBy, DateTime? approvedOn,
        UserId? rejectedBy, DateTime? rejectedOn)
    {
        Id = id;
        VacationType = vacationType;
        VacationStatus=VacationStatus.Pending;
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
    public static Vacation Create( VacationType vacationType, UserId employeeId,
        DateTime startFrom, DateTime endAt
       )
        => new(1, vacationType,  employeeId,
         startFrom,  endAt);
    public  void EditVacationDate(DateTime startFrom, DateTime endAt)
    {
        StartFrom = startFrom;
        EndAt = endAt;
    }
    public void EditVacationStatus(VacationStatus status)
    {
        VacationStatus = status;
        
    }
    public  int GetTotalVacationDays() => (int)(EndAt - StartFrom).TotalDays;

    
}
