using Portal.Domain.Department;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Administrator;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Common.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    IAggregateRootRepository<User, UserId, Guid> UsersRepository { get; }
    IAggregateRootRepository<Employee, UserId, Guid> EmployeesRepository { get; }
    IAggregateRootRepository<Manager, UserId, Guid> ManagersRepository { get; }

    IAggregateRootRepository<Administrator, UserId, Guid> AdministratorsRepository { get; }
    IAggregateRootRepository<Department, DepartmentId, Guid> DepartmentsRepository { get; }

    IRepository<Vacation,VacationId> VacationsRepository { get; }


    Task<int> CompleteAsync();

}
