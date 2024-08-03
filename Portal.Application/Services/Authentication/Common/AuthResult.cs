using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.User;

namespace Portal.Application.Services.Authentication.Common;

public record AuthResult
(
    User User,
    string Token
    );
