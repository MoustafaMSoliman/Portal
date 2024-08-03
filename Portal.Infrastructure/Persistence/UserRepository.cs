using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.User;

namespace Portal.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users= new();

    public UserRepository()
    {
        
    }
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);  
    }
}
