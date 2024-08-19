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
    private readonly IAggregateRootRepository<User, UserId, Guid> _usersRepo;
    private readonly IAggregateRootRepository<Employee, UserId, Guid> _employeesRepo;
    private readonly IRepository<Vacation, VacationId> _vacationRepository;

    public GetEmployeeVacationsQueryHandler(IAggregateRootRepository<Employee, UserId, Guid> employeesRepo
        , IAggregateRootRepository<User, UserId, Guid> usersRepo
        , IRepository<Vacation, VacationId> vacationRepository)
    {
        _usersRepo = usersRepo;
        _employeesRepo = employeesRepo;
        _vacationRepository = vacationRepository;
    }
    public async Task<ErrorOr<RetrieveVacationsResult>> Handle(GetEmployeeVacationsQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_usersRepo.GetById(query.EmployeeId) is null)
            return Errors.UserErrors.NotUser;
        if (_employeesRepo.GetById(query.EmployeeId) is null)
            return Errors.EmploymentErrors.NotEmployee;
        //var vacations = _employeesRepo.GetById(query.EmployeeId).Vacations.ToList();
        var vacations = _vacationRepository.GetAll().Where(v => v.EmployeeId == query.EmployeeId).ToList();
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
            $"{_employeesRepo.GetById(query.EmployeeId).Profile.FirstName} {_employeesRepo.GetById(query.EmployeeId).Profile.LastName}",
            vacationsResult);
    }
}
