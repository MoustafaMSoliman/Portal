using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User.Entities.Employee.ValueObjects;
using Portal.Domain.User.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Portal.Application.Services.Employement.Management.Queries;

public class GetManagerEmployeesVacationsQueryHandler : IRequestHandler<GetManagerEmployeesVacationsQuery, ErrorOr<ManagerEmployeesVacationResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetManagerEmployeesVacationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<ManagerEmployeesVacationResult>> Handle(GetManagerEmployeesVacationsQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_unitOfWork.UsersRepository.GetById(query.ManagerId) is null)
        {
            return Errors.ManagementErrors.NotManager;
        }
        var manager = _unitOfWork.ManagersRepository.GetById(query.ManagerId);

        var department = _unitOfWork.DepartmentsRepository.FindWithInclue(d => d.Id == manager.DepartmentId, d => d.Employees);
        var employees = _unitOfWork.EmployeesRepository.FindAllWithInclude(x => x.DepartmentId == department.Id, e=>e.Vacations).ToList();

        var emps = new List<ManagerEmployeeWithVacation>();
        var vacationResults = new List<VacationResult>();
        foreach (var employee in employees)
        {
            if (_unitOfWork.UsersRepository.GetById((UserId)employee.Id).UserRole != Domain.Common.Enums.RoleEnum.Manager)
            {
                foreach (var vac in employee.Vacations)
                {
                    vacationResults.Add(new VacationResult(vac.Id,vac.VacationType,vac.VacationStatus,vac.StartFrom,vac.EndAt,vac.TotalVacationDays,vac.AcceptedBy
                        ,vac.AcceptedOn,vac.AcceptedBy,vac.ApprovedOn,vac.RejectedBy,vac.RejectedOn));
                }
                emps.Add(
                    new ManagerEmployeeWithVacation(
                        employee.Id.Value,
                        $"{_unitOfWork.UsersRepository.GetByIdWithInclude((UserId)employee.Id, x => x.Profile).Profile.FirstName} {_unitOfWork.UsersRepository.GetByIdWithInclude((UserId)employee.Id, x => x.Profile).Profile.LastName}"
                        , vacationResults
                    ));
            }

        }

        return new ManagerEmployeesVacationResult(
            manager,
            emps
            );
    }
}
