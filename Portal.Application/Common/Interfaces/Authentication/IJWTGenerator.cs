using System.Reflection.Metadata;
using Portal.Domain.User;
namespace Portal.Application.Common.Interfaces.Authentication;

public interface IJWTGenerator
{
    string GenerateToken(User user);
}
