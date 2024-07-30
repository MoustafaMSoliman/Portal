using Portal.Domain.User;

namespace Portal.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail (string email);
    void AddUser(User user);
}
