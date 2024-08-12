using ErrorOr;

namespace Portal.Domain.Common.Errors;
public static partial class Errors
{
    public static class AdminsErrors
    {
        public static Error NotAdmin => Error.Conflict(
            code:"AdminsError.NotAdmin",
            description:"You don't have a permission to do this, only admins can do it"
            );
    }
}

