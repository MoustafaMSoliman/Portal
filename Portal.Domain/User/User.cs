using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;
using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User;

public class User:AggregateRoot<UserId, Guid>
{
    public string UserName { get; private set; } = null!;
    public int Code { get; private set; }
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public Role Role { get; private set; } 
    public Profile Profile { get; private set; }
    public UserStatus Status { get; private set; }

#pragma warning disable CS8618
    protected internal User() { }
#pragma warning restore CS8618
    protected internal User(UserId id, string userName, string email, string password, Role role, Profile profile)
    {
        Id = id;
        UserName = userName; 
        Email = email; 
        Password = password;
        Role = role;
        Profile = profile;
    }
    public static User Create(string userName, string email, string password, Role role, Profile profile)
    {
        return new(UserId.CreateUnique(), userName, email, password, role, profile);
    }

    
}
