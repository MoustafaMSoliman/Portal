using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Authentication;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Authentication.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    private readonly IAggregateRootRepository<User, UserId, Guid> _userRepository;
    private readonly IJWTGenerator _jwtGenerator;

    public LoginQueryHandler(IAggregateRootRepository<User, UserId, Guid> userRepository, IJWTGenerator jWTGenerator)
    {
        _userRepository = userRepository;
        _jwtGenerator = jWTGenerator;
    }
    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery loginQuery, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.Find(x => x.Email.Value == loginQuery.Email) is not User user)
        {
            return Errors.AuthenticationErrors.InvalidCredentials;
        }
        if (loginQuery.Password != user.Password)
        {
            return Errors.AuthenticationErrors.InvalidCredentials;
        }
        var Token = _jwtGenerator.GenerateToken(user);


        return new AuthResult(user, Token);
    }
}
