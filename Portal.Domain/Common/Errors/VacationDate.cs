using ErrorOr;

namespace Portal.Domain.Common.Errors;

public static partial class Errors
{
    public static class VacationDate
    {
        public static Error InvalidVacationDate
            => Error.Conflict(code: "InvalidVacationDate.InvalidVacationDate",
                description:"Vacation end date should be after it's start date"
                );

        public static Error InvalidStartVacationDate
            => Error.Conflict(code: "InvalidVacationDate.InvalidStartVacationDate",
                description: "Vacation with this start date is already exists"
                );
    }
}
