using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee;

namespace Portal.Application.Common.Interfaces.Persistence;

public interface IEmployeeRepository
{
    Employee? GetEmployeeByEmail(string email);
    void AddEmployee(Employee user);
}
