using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Portal.Application.Common.Interfaces.Authentication;
using Portal.Domain.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Portal.Infrastructure.Authentication;

public class JWTGenerator : IJWTGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JWTGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
             new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
             SecurityAlgorithms.HmacSha256
            );
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Profile.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.Profile.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            claims:claims,
            signingCredentials:signingCredentials,
            expires:_dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes)
            );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
