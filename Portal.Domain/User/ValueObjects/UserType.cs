using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class UserType : ValueObject
{
    public int Id { get; private set; } 
    public TypeEnum Value { get; private set; }
    public User User { get; private set; }
#pragma warning disable CS8618
    private UserType() { }
#pragma warning restore CS8618
    private UserType(TypeEnum value) 
    {
        Value = value;
    }
    public static UserType Create(string input)
    {
        _ = Enum.TryParse<TypeEnum>(input, true, out TypeEnum value);

        return new(value);
        
    }
    public static UserType Create(TypeEnum type)
        => new(type);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
