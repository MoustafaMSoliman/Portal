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
    private readonly IUnitOfWork _unitOfWork;
    //private readonly INotification _notification;

    public VacationCommandHandler(IUnitOfWork unitOfWork
        //, INotification notification
        )
    {
        _unitOfWork = unitOfWork;
        //_notification = notification;
    }
    public async Task<ErrorOr<VacationResult>> Handle(VacationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
         
        if (_unitOfWork.EmployeesRepository.GetById(request.EmployeeId) is null)
        {
            return Errors.AuthenticationErrors.InvalidUser;
        }
        var vacEmp = _unitOfWork.VacationsRepository.FindAll(v => v.EmployeeId == request.EmployeeId).ToList();
        foreach (var vac in vacEmp)
        
        {
            if(vac.StartFrom == request.StartFrom || vac.EndAt==request.EndAt || request.StartFrom > request.EndAt) 
                return Errors.VacationDate.InvalidStartVacationDate;
        }

        var vacation = Vacation.Create(
             request.VacationType,
             request.EmployeeId,
             request.StartFrom,
             request.EndAt
         );
        if (_unitOfWork.UsersRepository.GetById(request.EmployeeId).UserRole == Domain.Common.Enums.RoleEnum.Manager)
        {
            vacation.EditVacationStatus(Domain.Common.Enums.User.Employee.VacationStatus.Accepted);
        }
        _unitOfWork.VacationsRepository.AddNew( vacation );
        _unitOfWork.EmployeesRepository.GetById(request.EmployeeId).Vacations.Add( vacation );  
        await _unitOfWork.CompleteAsync();  
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
