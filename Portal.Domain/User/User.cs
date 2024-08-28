using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Common.Models;
using Portal.Domain.User.ValueObjects;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;



namespace Portal.Domain.User;

public class User:AggregateRoot<UserId, Guid>
{
    public int Code { get; private set; }
    public int ProfileId { get; private set; }
    public Profile Profile { get; private set; }
    public string Email { get; private set; } = null!;
   
    public string Password { get; private set; } = null!;

    public int UserTypeId { get; private set; }
    public UserType UserType { get; private set; }
    public int UserRoleId { get; private set; }
    public UserRole UserRole { get; private set; }
    public int UserStatusId { get; private set; }
    public UserStatus UserStatus { get; private set; }

    public UserId? CreatedBy { get;  set; }
    public UserId? UpdatedBy { get; set; }

#pragma warning disable CS8618
    protected internal User() { }
#pragma warning restore CS8618
    protected internal User(UserId id,string email, string password,UserType userType, UserRole role, UserStatus userStatus, Profile profile,int? code, UserId? createdBy, UserId? updatedBy)
    {
        Id = id;
        Code = code ?? 1;
        Email = email; 
        Password = password;
        UserType = userType;
        UserRole = role ;
        UserStatus = userStatus;
        Profile = profile;
        CreatedBy = createdBy ?? id;
        UpdatedBy = updatedBy ?? id;
    }
    public static User Create(string email, string password,UserType userType, UserRole? role, UserStatus userStatus, Profile profile, int? code, UserId? createdBy, UserId? updatedBy)
    {
        return new(
            UserId.CreateUnique(), 
            email, password,
            userType,
            role ?? UserRole.Create("NormalUser"),
            UserStatus.Create(StatusEnum.Active),
            profile,
            code,
            createdBy,
            updatedBy
            );
    }
    public static User Create(UserId userd, string email, string password, UserType userType, UserRole role, Profile profile, int? code, UserId? createdBy, UserId? updatedBy)
    {
        return new(userd, email, password, userType, role , UserStatus.Create(StatusEnum.Active), profile, code, createdBy, updatedBy);
    }
    public void SetUserRole(UserRole role)
    {
        UserRole = role;
    }
    public void SetUserType(UserType type)
    {
        UserType = type;
    }

}
