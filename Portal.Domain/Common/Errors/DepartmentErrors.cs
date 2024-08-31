using ErrorOr;

namespace Portal.Domain.Common.Errors;

public static partial class Errors
{
    public static class DepartmentErrors
    {
        public static Error DuplicateDepartment => Error.Conflict(
             code:"Errors.DepartmentErrors.DuplicateDepartment",
             description:"This department is already exists"
            );
    }
}

