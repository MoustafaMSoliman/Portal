using ErrorOr;

namespace Portal.Domain.Common.Errors;

public static partial class Errors
{
    public static class VacationsErrors
    {
        public static Error NotVacation => Error.Conflict(
             code:"Errors.VacationsErrors.NotVacation",
             description:"This vacation isn't exist"
            );
        public static Error AlreadyHasThisStatus => Error.Conflict(
             code:"Errors.VacationsErrors.AlreadyHasThisStatus",
             description:"This vacation already has this status"
            );
    }

}
