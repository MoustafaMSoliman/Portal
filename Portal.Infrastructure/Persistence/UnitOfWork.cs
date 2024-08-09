using Portal.Application.Common.Interfaces.Persistence;

namespace Portal.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
