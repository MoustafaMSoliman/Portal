using Portal.Domain.User.Entities.Employee.Entities;

namespace Portal.Application.Common.Interfaces;

public interface INotification
{
    void NotifyManagerOfNewRequest(Vacation vacationRequest);
    void NotifyEmployeeOfDecision(Vacation vacationRequest);
}
