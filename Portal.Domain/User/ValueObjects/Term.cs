using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class Term : ValueObject
{
    public TermName TermName { get; private set; }
    public short TermYear { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return TermName;
        yield return TermYear;
    }
}
