using ErrorOr;

namespace Portal.Domain.Common.Errors;

public static partial class Errors
{
    public static class UserErrors
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "UserErrors.DuplicateEmail",
            description:"This email already in use"
            );
        public static Error NotUser => Error.Conflict(
            code: "UserErrors.NotUser",
            description: "This user is not exist"
            );
    }
}
