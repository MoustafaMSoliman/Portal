using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Common.Models;
using Portal.Domain.User.ValueObjects;
using System.Runtime.CompilerServices;



namespace Portal.Domain.User;

public class User:AggregateRoot<UserId, Guid>
{
    public int Code { get; private set; }
    public int ProfileId { get; private set; }
    public Profile Profile { get; private set; }
    public Email Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public UserType UserType { get; private set; }
    public UserRole UserRole { get; private set; }
    public UserStatus UserStatus { get; private set; }
    public UserId? CreatedBy { get;  set; }
    public UserId? UpdatedBy { get; set; }

#pragma warning disable CS8618
    protected internal User() { }
#pragma warning restore CS8618
    protected internal User(UserId id,Email email, string password,UserType userType, UserRole role, Profile profile,int? code, UserId? createdBy, UserId? updatedBy)
    {
        Id = id;
        Code = code ?? 1;
        Email = email; 
        Password = password;
        UserType = userType;
        UserRole = role ;
        Profile = profile;
        CreatedBy = createdBy ?? id;
        UpdatedBy = updatedBy ?? id;
    }
    public static User Create(Email email, string password,UserType userType, UserRole? role, Profile profile, int? code, UserId? createdBy, UserId? updatedBy)
    {
        return new(
            UserId.CreateUnique(), 
            email, password,
            userType,
            role ?? UserRole.Create("NormalUser"),
            profile,
            code,
            createdBy,
            updatedBy
            );
    }
    public static User Create(UserId userd, Email email, string password, UserType userType, UserRole role, Profile profile, int? code, UserId? createdBy, UserId? updatedBy)
    {
        return new(userd, email, password, userType, role , profile, code, createdBy, updatedBy);
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
