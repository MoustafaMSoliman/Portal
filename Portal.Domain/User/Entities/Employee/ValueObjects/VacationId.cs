using Portal.Domain.Common.Models;

namespace Portal.Domain.User.Entities.Employee.ValueObjects;

public class VacationId : ValueObject
{
    public Guid Value { get; private set; }
#pragma warning disable CS8618
    private VacationId() { }
#pragma warning restore CS8618
    private VacationId(Guid value)
    {
        Value = value;
    }
    public static VacationId CreateUnique()
        => new(Guid.NewGuid());
    public static VacationId Create(Guid id)
        => new(id);
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
