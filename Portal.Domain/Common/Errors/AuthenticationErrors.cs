using ErrorOr;

namespace Portal.Domain.Common.Errors;
public static partial class Errors
{
    public static class AuthenticationErrors
    {
        public static Error InvalidCredentials => Error.Conflict(
             code:"AuthenticationErrors.InvalidCredentials",
             description:"This email or password is incorrect"
            );
    }

}
