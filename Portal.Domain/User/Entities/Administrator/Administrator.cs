using Portal.Domain.User.ValueObjects;

namespace Portal.Domain.User.Entities.Administrator;

public class Administrator : User
{

#pragma warning disable CS8618
    private Administrator(){}
#pragma warning restore CS8618
    private Administrator(User user) 
        :base((UserId)user.Id,user.Email,user.Password,user.UserType,user.UserRole,user.Profile,user.Code,user.CreatedBy, user.UpdatedBy)
    {
    }

    public static Administrator Create(User user)
        => new(user);
}
