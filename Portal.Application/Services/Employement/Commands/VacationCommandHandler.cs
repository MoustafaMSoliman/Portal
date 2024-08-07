using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Employment;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User.Entities.Employee.Entities;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace Portal.Application.Services.Employement.Commands;

public class VacationCommandHandler : IRequestHandler<VacationCommand, ErrorOr<VacationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IVacationRepository _vacationRepository;
    //private readonly INotification _notification;

    public VacationCommandHandler(IUserRepository userRepository,
        IVacationRepository vacationRepository
        //, INotification notification
        )
    {
        _userRepository = userRepository;
        _vacationRepository = vacationRepository;
        //_notification = notification;
    }
    public async Task<ErrorOr<VacationResult>> Handle(VacationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserById(request.EmployeeId.Value) is null)
        {
            return Errors.AuthenticationErrors.InvalidUser;
        }

        if (_vacationRepository.GetByStartFrom(request.EmployeeId, request.StartFrom) is not null
            && _vacationRepository.GetByEndAt(request.EmployeeId, request.EndAt) is not null)
        {
            return Errors.VacationDate.InvalidStartVacationDate;
        }

        var vacation = Vacation.Create(
             _vacationRepository.GetCount(),
             request.VacationType,
             request.EmployeeId,
             request.StartFrom,
             request.EndAt
         );
        _vacationRepository.Add( vacation );
        
        return new VacationResult(vacation
            );
    }
}
