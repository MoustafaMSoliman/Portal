using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Queries;

public class GetManagerEmployeesQueryHandler : IRequestHandler<GetManagerEmployeesQuery, ErrorOr<ManagerEmployeesResult>>
{
    private readonly IUnitOfWork _unitOfWork;


    public GetManagerEmployeesQueryHandler(IUnitOfWork unitOdWork)
    {
        _unitOfWork = unitOdWork;
    }
    public async Task<ErrorOr<ManagerEmployeesResult>> Handle(GetManagerEmployeesQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_unitOfWork.UsersRepository.GetById(query.ManagerId).UserRole != Domain.Common.Enums.RoleEnum.Manager)
        {
            return Errors.ManagementErrors.NotManager;
        }
        var manager = _unitOfWork.ManagersRepository.GetById(query.ManagerId);
        var department = _unitOfWork.DepartmentsRepository.FindWithInclue(d => d.Id == manager.DepartmentId, d => d.Employees);
        var employees = _unitOfWork.EmployeesRepository.FindAll(x=>x.DepartmentId == department.Id).ToList();  

        var emps = new List<ManagerEmployee>();
        foreach (var employee in employees) 
        {
            if(_unitOfWork.UsersRepository.GetById((UserId)employee.Id).UserRole != Domain.Common.Enums.RoleEnum.Manager)
              emps.Add(
                  new ManagerEmployee( 
                      employee.Id.Value,
                      $"{_unitOfWork.UsersRepository.GetByIdWithInclude((UserId) employee.Id, x=>x.Profile).Profile.FirstName} {_unitOfWork.UsersRepository.GetByIdWithInclude((UserId)employee.Id, x => x.Profile).Profile.LastName}"
                  
                  ));
            
        }
        
        return new ManagerEmployeesResult(
            manager,
            emps
            );
        
    }
}
