using Portal.Application.Common.Interfaces.Employment;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Infrastructure.Employment;

public class VacationRepository : IVacationRepository
{
    private readonly List<Vacation> _vacations= new();
    

    public void Add(Vacation vacation)
    {
        _vacations.Add(vacation);
    }

    public Vacation GetByEndAt(UserId userId, DateTime endAt)
    {
        return _vacations.SingleOrDefault(v => v.EmployeeId == userId && v.EndAt == endAt);
    }

    public Vacation GetById(int id)
    {
        return _vacations.SingleOrDefault(v=> v.Id == id); 
    }

    public Vacation GetByStartFrom(UserId userId, DateTime startFrom)
    {
        return _vacations.SingleOrDefault(v => v.EmployeeId == userId && v.StartFrom == startFrom);

    }

    public List<Vacation> GetByUserId(UserId userId)
    {
        return _vacations.Where(v=>v.EmployeeId == userId).ToList();
    }

    public int GetCount()
    {
        return _vacations.Count;
    }

    public int GetEmployeeVacationsCount(UserId userId)
    {
        return _vacations.Where(v=>v.EmployeeId==userId).Count();
    }

    public void Update(Vacation vacation)
    {
       
    }
}
