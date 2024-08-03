using ErrorOr;

namespace Portal.Domain.Common.Errors;

public static partial class Errors
{
    public static class EmailErrors {
        public static Error InValidEmail => Error.Conflict(
             code:"Errors.Email",
             description:"Invalid email address"
            );
        public static Error EmailAddreesContainsWhiteSpace => Error.Conflict(
             code:"Error.EmailWithWhiteSpace",
             description:"Email should not contain white space"
            ); 
    }
}
