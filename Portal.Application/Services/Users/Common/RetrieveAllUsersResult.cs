using Portal.Domain.User;

namespace Portal.Application.Services.Users.Common;

public record RetrieveAllUsersResult
(
    List<User> Users
);
