using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace Portal.Application.Services.Employement.Commands;

public class VacationCommandHandler : IRequestHandler<VacationCommand, ErrorOr<VacationResult>>
{
    private readonly IAggregateRootRepository<User, UserId,Guid> _userRepository;
    //private readonly IRepository<Vacation,int> _vacationRepository;
    //private readonly INotification _notification;

    public VacationCommandHandler(IAggregateRootRepository<User, UserId, Guid> userRepository
        //, IRepository<Vacation, int> vacationRepository
        //, INotification notification
        )
    {
        _userRepository = userRepository;
        //_vacationRepository = vacationRepository;
        //_notification = notification;
    }
    public async Task<ErrorOr<VacationResult>> Handle(VacationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetById(request.EmployeeId) is null)
        {
            return Errors.AuthenticationErrors.InvalidUser;
        }

        //if (_vacationRepository.Find(v=>v.EmployeeId == request.EmployeeId
        //        && v.StartFrom==request.StartFrom && v.EndAt == request.EndAt) is not null
        //    )
        //{
        //    return Errors.VacationDate.InvalidStartVacationDate;
        //}

        var vacation = Vacation.Create(
             request.VacationType,
             request.EmployeeId,
             request.StartFrom,
             request.EndAt
         );
        //_vacationRepository.AddNew( vacation );
        
        return new VacationResult(vacation);
    }
}
