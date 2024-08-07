using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Common.Interfaces.Employment;

public interface IVacationRepository
{
   
    void Add (Vacation vacation);
    void Update (Vacation vacation);
    Vacation GetById (int id);
    List<Vacation> GetByUserId (UserId userId);
    Vacation GetByStartFrom (UserId userId, DateTime startFrom);
    Vacation GetByEndAt(UserId userId, DateTime endAt);
    int GetEmployeeVacationsCount (UserId userId);
    int GetCount();
}
