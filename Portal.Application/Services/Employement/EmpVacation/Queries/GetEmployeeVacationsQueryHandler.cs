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

namespace Portal.Application.Services.Employement.EmpVacation.Queries;

public class GetEmployeeVacationsQueryHandler
    : IRequestHandler<GetEmployeeVacationsQuery, ErrorOr<RetrieveVacationsResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeeVacationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<RetrieveVacationsResult>> Handle(GetEmployeeVacationsQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_unitOfWork.UsersRepository.GetById(query.EmployeeId) is null)
            return Errors.UserErrors.NotUser;
        if (_unitOfWork.EmployeesRepository.GetById(query.EmployeeId) is null)
            return Errors.EmploymentErrors.NotEmployee;
        

        var vacations = _unitOfWork.VacationsRepository.GetAll().Where(v => v.EmployeeId == query.EmployeeId).ToList();
        var vacationsResult = new List<VacationResult>();
        foreach (var vacation in vacations)
        {
            vacationsResult.Add(new VacationResult(vacation.Id, vacation.VacationType,
                vacation.VacationStatus, vacation.StartFrom, vacation.EndAt,
                vacation.TotalVacationDays,
                vacation.AcceptedBy ?? UserId.Create(Guid.Empty), 
                vacation.AcceptedOn ,
                vacation.ApprovedBy ?? UserId.Create(Guid.Empty),
                vacation.ApprovedOn,
                vacation.RejectedBy ?? UserId.Create(Guid.Empty),
                vacation.RejectedOn));
        }
        return new RetrieveVacationsResult(
            query.EmployeeId,
            $"{_unitOfWork.UsersRepository.GetByIdWithInclude(query.EmployeeId,x=>x.Profile).Profile.FirstName} {_unitOfWork.UsersRepository.GetByIdWithInclude(query.EmployeeId, x => x.Profile).Profile.LastName}",
            vacationsResult);
    }
}
