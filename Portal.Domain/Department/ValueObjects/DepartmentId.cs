using Portal.Domain.Common.Models;

namespace Portal.Domain.Department.ValueObjects;

public class DepartmentId : AggregateRootId<Guid>
{
    
    public override Guid Value { get; protected set; }
#pragma warning disable CS8618
    private DepartmentId() { }

#pragma warning restore CS8618

    private DepartmentId(Guid value) { Value = value; }
    public static DepartmentId CreateUnique() => new(Guid.NewGuid());
    public static DepartmentId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
