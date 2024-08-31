using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;


namespace Portal.Application.Services.Employement.EmpVacation.Commands;

public class VacationCommandHandler : IRequestHandler<VacationCommand, ErrorOr<VacationResult>>
{
    private readonly IAggregateRootRepository<Employee, UserId, Guid> _employeeRepository;
    private readonly IRepository<Vacation,VacationId> _vacationRepository;
    //private readonly INotification _notification;

    public VacationCommandHandler(IAggregateRootRepository<Employee, UserId, Guid> employeeRepository
        , IRepository<Vacation, VacationId> vacationRepository
        //, INotification notification
        )
    {
        _employeeRepository = employeeRepository;
        _vacationRepository = vacationRepository;
        //_notification = notification;
    }
    public async Task<ErrorOr<VacationResult>> Handle(VacationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
         
        if (_employeeRepository.GetById(request.EmployeeId) is null)
        {
            return Errors.AuthenticationErrors.InvalidUser;
        }

        if (_vacationRepository.Find(v => v.EmployeeId == request.EmployeeId
                && (v.StartFrom == request.StartFrom || v.EndAt == request.EndAt)) is not null
            )
        {
            return Errors.VacationDate.InvalidStartVacationDate;
        }

        var vacation = Vacation.Create(
             request.VacationType,
                                 
             request.EmployeeId,
             request.StartFrom,
             request.EndAt
         );
        if (_employeeRepository.GetById(request.EmployeeId).UserRole == Domain.Common.Enums.RoleEnum.Manager)
        {
            vacation.EditVacationStatus(Domain.Common.Enums.User.Employee.VacationStatus.Accepted);
        }
       _vacationRepository.AddNew( vacation );
        _employeeRepository.GetById(request.EmployeeId).Vacations.Add( vacation );  
        return new VacationResult(
            vacation.Id,
            vacation.VacationType,
            vacation.VacationStatus,
            vacation.StartFrom,
            vacation.EndAt,
            vacation.TotalVacationDays,
            vacation.AcceptedBy ?? UserId.Create(Guid.Empty),
            vacation.AcceptedOn,
            vacation.ApprovedBy ?? UserId.Create(Guid.Empty),
            vacation.ApprovedOn,
            vacation.RejectedBy ?? UserId.Create(Guid.Empty),
            vacation.RejectedOn
            );
    }
}
