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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJWTGenerator _jwtGenerator;

    public LoginQueryHandler(IJWTGenerator jWTGenerator, IUnitOfWork unitOfWork)
    {
        _jwtGenerator = jWTGenerator;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery loginQuery, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
       
        if (_unitOfWork.UsersRepository.FindWithInclue(x => x.Email == loginQuery.Email, u => u.Profile, u=>u.UserType, u => u.UserRole, u => u.UserStatus) is not User user)
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
