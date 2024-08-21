using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class UserStatus : ValueObject
{
    public int Id { get; set; }
    public StatusEnum Value { get; set; }
#pragma warning disable CS8618
    private UserStatus() { }
#pragma warning restore CS8618
    private UserStatus(StatusEnum value)
    {
        Value = value;
    }
    public static UserStatus Create(string input)
    {
        _ = Enum.TryParse<StatusEnum>(input, true, out StatusEnum value);

        return new(value);

    }
    public static UserStatus Create(StatusEnum status)
        => new(status);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
