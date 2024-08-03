using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.User;
using Portal.Domain.User.Entities;

namespace Portal.Infrastructure.Persistence;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new();
    public EmployeeRepository()
    {
        
    }
    public void AddEmployee(Employee emp)
    {
        _employees.Add(emp);
    }

    public Employee? GetEmployeeByEmail(string email)
    {
       return _employees.SingleOrDefault(emp => emp.Email == email);    
    }
}
