using ErrorOr;

namespace Portal.Domain.Common.Errors;

public static partial class Errors
{
    public static class ManagementErrors
    {
        public static Error NotManager => Error.Conflict(
            code: "ManagementErrors.NotManager",
            description: "This User Id isn't a manager"
            );
        public static Error AlreadyManager => Error.Conflict(
       code: "ManagementErrors.AlreadyManager",
       description: "This User Id is already a manager"
       );
    }

}
