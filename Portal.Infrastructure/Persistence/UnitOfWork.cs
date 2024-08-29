using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Administrator;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly PortalDbContext _dbContext;
    public IAggregateRootRepository<User, UserId, Guid> UsersRepository { get; private set; }

    public IAggregateRootRepository<Employee, UserId, Guid> EmployeesRepository { get; private set; }

    public IAggregateRootRepository<Manager, UserId, Guid> ManagersRepository { get; private set; }

    public IAggregateRootRepository<Administrator, UserId, Guid> AdministratorsRepository { get; private set; }

    public IRepository<Vacation, VacationId> VacationsRepository { get; private set; }

    public UnitOfWork(
        PortalDbContext dbContext
        , IAggregateRootRepository<User, UserId, Guid> usersRepository
        , IAggregateRootRepository<Employee, UserId, Guid> employeesRepository
        , IAggregateRootRepository<Manager, UserId, Guid> managersRepository
        , IAggregateRootRepository<Administrator, UserId, Guid> administratorsRepository
        , IRepository<Vacation, VacationId> vacationsRepository
        )
    {
        _dbContext = dbContext;
        UsersRepository = usersRepository;
        EmployeesRepository = employeesRepository;
        ManagersRepository = managersRepository;
        AdministratorsRepository = administratorsRepository;
        VacationsRepository = vacationsRepository;
    }
    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
