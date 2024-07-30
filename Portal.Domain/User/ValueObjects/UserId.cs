using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class UserId : AggregateRootId<Guid>
{
    public override Guid Value { get ; protected set; }

#pragma warning disable CS8618
    private UserId()
    {}
#pragma warning restore CS8618
    public UserId(Guid id)
    {
        Value = id;
    }

    public static UserId CreateUnique() 
        =>new(Guid.NewGuid());
    public static UserId Create(Guid id)
        =>new(id);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
