using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.Department;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Commands;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, ErrorOr<CreateDepartmentResult>>
{
    private readonly IAggregateRootRepository<Department,DepartmentId,Guid> _departmentsRepository;
    private readonly IAggregateRootRepository<Employee, UserId, Guid> _empsRepository;


    public CreateDepartmentCommandHandler(IAggregateRootRepository<Department, DepartmentId, Guid> departmentsRepository,
        IAggregateRootRepository<Employee, UserId, Guid> empsRepository)
    {
        _departmentsRepository = departmentsRepository;
        _empsRepository = empsRepository;
    }
    public async Task<ErrorOr<CreateDepartmentResult>> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_departmentsRepository.Find(d => d.Name == command.DepartmentName) is not null)
            return Errors.ManagementErrors.DuplicateDepartment;

        if (command.ManagerId is not null && _empsRepository.GetById(command.ManagerId) is null)
            return Errors.ManagementErrors.NotManager;

        var department = Department.Create(command.DepartmentName,command.ManagerId
            //,command.SecreteryId
            );
        _departmentsRepository.AddNew(department);

        return new CreateDepartmentResult((DepartmentId)department.Id,department.Name,department.ManagId
            , _empsRepository.GetById((UserId)department.ManagId).Profile.FirstName
            //,department.SecreteryId,department.Secretery.Profile.FirstName
            ,new List<Employee>());
    }
}
