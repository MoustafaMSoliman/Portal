using Portal.Domain.Common.Models;

namespace Portal.Domain.Exam.ValueObjects;

public class ExamId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

#pragma warning disable CS8618
    private ExamId() { }
#pragma warning restore CS8618
    private ExamId(Guid id)
    {
        Value = id;
    }
    public static ExamId CreateUnique()
        =>new(Guid.NewGuid());
    public static ExamId Create(Guid value)
        => new(value);  
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
