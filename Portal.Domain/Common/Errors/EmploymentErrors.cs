using ErrorOr;

namespace Portal.Domain.Common.Errors;

public static partial class Errors
{
    public static class EmploymentErrors
    {
        public static Error NotEmployee => Error.Conflict(
            code:"EmploymentErrors.NotEmployee",
            description:"This id isn't an employee id"
            );
    }
}