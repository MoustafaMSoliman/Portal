using Portal.Application.Common.Interfaces.Authentication;

namespace Portal.Infrastructure.Authentication;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
