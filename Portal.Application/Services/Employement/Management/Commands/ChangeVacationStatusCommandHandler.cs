using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Commands;

public class ChangeVacationStatusCommandHandler
    : IRequestHandler<ChangeVacationStatusCommand, ErrorOr<VacationResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ChangeVacationStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<VacationResult>> Handle(ChangeVacationStatusCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var vacation = _unitOfWork.VacationsRepository.GetById(command.VacationId);

        if ( vacation is null)
            return Errors.VacationsErrors.NotVacation;
        var manager = _unitOfWork.ManagersRepository.GetByIdWithInclude(command.ManagerId, x=>x.Profile);
        if (manager is null)
            return Errors.ManagementErrors.NotManager;
        if (vacation.VacationStatus == command.VacationStatus)
            return Errors.VacationsErrors.AlreadyHasThisStatus;
        _unitOfWork.VacationsRepository.GetById(command.VacationId).EditVacationStatus(command.VacationStatus,(UserId) manager.Id);
        //_unitOfWork.VacationsRepository.Update(vacation);
        await _unitOfWork.CompleteAsync();
        return new VacationResult(vacation.Id,vacation.VacationType, vacation.VacationStatus,
            vacation.StartFrom, vacation.EndAt, vacation.TotalVacationDays,vacation.AcceptedBy,
            vacation.AcceptedOn,vacation.ApprovedBy,vacation.ApprovedOn,vacation.RejectedBy,vacation.RejectedOn);
    }
}
