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
        public static Error InvalidUser => Error.Conflict(
            code: "AuthenticationErrors.InvalidUser",
             description: "This user is not exist"
            );
    }

}
