using Portal.Domain.User;

namespace Portal.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail (string email);
    User? GetUserById(Guid id);
    void AddUser(User user);
    List<User> GetAllUsers();
}
