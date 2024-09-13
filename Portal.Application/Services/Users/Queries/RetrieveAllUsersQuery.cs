using ErrorOr;
using MediatR;
using Portal.Application.Services.Users.Common;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Users.Queries;

public record RetrieveAllUsersQuery
(
    UserId AdminId
):IRequest<ErrorOr<RetrieveAllUsersResult>>;
