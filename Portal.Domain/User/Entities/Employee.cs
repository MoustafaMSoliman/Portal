using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User;
using Portal.Domain.User.ValueObjects;


namespace Portal.Domain.User.Entities;

public class Employee : User
{
    public DateTime HireDate { get; set; }
    public DepartmentId DepartmentId { get; set; }
    public ICareerGroup CareerGroup { get;  private set; }


#pragma warning disable CS8618
    protected internal Employee() { }
#pragma warning restore CS8618
    protected internal Employee(
        User user,
        DepartmentId departmentId,
        DateTime hireDate,
        ICareerGroup careerGroup
        ) : base((UserId)user.Id, user.Email,user.Password, user.Role, user.Profile,user.Code)
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


}
