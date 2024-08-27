using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class UserRole : ValueObject
{

    public int Id { get; set; }
    public string RoleName { get; set; }
    public RoleEnum Value { get; set; }
    public User User { get; set; }

#pragma warning disable CS8618
    private UserRole() { }
#pragma warning restore CS8618
    private UserRole(RoleEnum value) 
    {
        Value = value;
        RoleName = Value.ToString();
        
    }
    public static UserRole Create(string role)
    {
        _=Enum.TryParse(role, true, out RoleEnum roleEnum);
        return new(roleEnum);
    }

    public static UserRole Create(RoleEnum role)
        =>new(role);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
