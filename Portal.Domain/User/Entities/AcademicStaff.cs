using Portal.Domain.Common.Enums;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities;

public class AcademicStaff : User
{
    string Title { get; set; } = null!;
    string OfficeLocation { get; set; } = null!;
    AcademicStaffDepartments Department { get; set; }
#pragma warning disable CS8681
    protected internal AcademicStaff() { }
#pragma warning restore CS8681

    protected internal AcademicStaff(
        UserId userId,
        string username,
        string email,
        string password,
        Role role,
        Profile profile,
        string title,
        string officeLocation,
        AcademicStaffDepartments department
        )
        :base(userId, username, email, password, role, profile)
    {
        Title = title;
        OfficeLocation = officeLocation;
        Department = department;
    }
    public static AcademicStaff Create(
        UserId userId,
        string username,
        string email,
        string password,
        Role role,
        Profile profile,
        string title,
        string officeLocation,
        AcademicStaffDepartments department)
        => new(userId, username, email, password, role, profile,
            title, officeLocation, department);
}
