using Portal.Domain.User;

namespace Portal.Application.Services.Users.Common;

public record RetrieveAllUsersResult
(
    List<UserResult> Users
);
public record UserResult
(
   int code,
   string FirstName,
   string LastName

);