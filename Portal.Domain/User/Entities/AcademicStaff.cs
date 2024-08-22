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
        User user,
        string title,
        string officeLocation,
        AcademicStaffDepartments department
        )
        :base((UserId)user.Id, user.Email, user.Password,UserType.Create(TypeEnum.AcademicStaff),UserRole.Create(RoleEnum.NormalUser) , user.Profile, user.Code, user.CreatedBy, user.UpdatedBy)
    {
        Title = title;
        OfficeLocation = officeLocation;
        Department = department;
    }
    public static AcademicStaff Create(
       User user,
        string title,
        string officeLocation,
        AcademicStaffDepartments department)
        => new(user,title, officeLocation, department);
}
