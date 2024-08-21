using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class UserRole : ValueObject
{

    public RoleEnum Role { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Role;
    }
}
