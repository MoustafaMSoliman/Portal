using Portal.Application.Common.Interfaces.Persistence;

namespace Portal.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    
    public IUserRepository UserRepository => throw new NotImplementedException();

    public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
