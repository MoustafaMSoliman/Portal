using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.Common.Models;
using Portal.Domain.User.ValueObjects;



namespace Portal.Domain.User;

public class User:AggregateRoot<UserId, Guid>,IUser
{
    public string UserName { get; private set; } = null!;
    public int Code { get; private set; }
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public RoleEnum Role { get; private set; }
    public Profile Profile { get; private set; }
    public UserStatus Status { get; private set; }

#pragma warning disable CS8618
    protected internal User() { }
#pragma warning restore CS8618
    protected internal User(UserId id, string email, string password, RoleEnum role, Profile profile,int? code)
    {
        Id = id;
        Email = email; 
        Password = password;
        Role = role;
        Profile = profile;
        Code = code ?? 1;
    }
    public static User Create(string email, string password, RoleEnum role, Profile profile, int? code)
    {
        return new(UserId.CreateUnique(), email, password, role, profile,code);
    }

    
}
