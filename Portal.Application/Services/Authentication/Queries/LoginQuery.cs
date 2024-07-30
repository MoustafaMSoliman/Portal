using MediatR;
using ErrorOr;
using Portal.Application.Services.Authentication.Common;

namespace Portal.Application.Services.Authentication.Queries;

public record LoginQuery
(
    string Email,
    string Password
):IRequest<ErrorOr<AuthResult>>;
