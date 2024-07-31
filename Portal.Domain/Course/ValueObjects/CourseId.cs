using Portal.Domain.Common.Models;

namespace Portal.Domain.Course.ValueObjects;

public class CourseId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

#pragma warning disable CS8618
    private CourseId() { }
#pragma warning restore CS8618
    private CourseId(Guid value) { Value = value; }
    public static CourseId CreateUnique()=>new(Guid.NewGuid()); 
    public static CourseId Create(Guid id)=>new(id);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
