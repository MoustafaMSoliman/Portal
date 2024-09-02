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
    private readonly IUnitOfWork _unitOfWork;


    public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<CreateDepartmentResult>> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_unitOfWork.DepartmentsRepository.Find(d => d.Name == command.DepartmentName) is not null)
            return Errors.ManagementErrors.DuplicateDepartment;

        //if (command.ManagerId is not null && _empsRepository.GetById(command.ManagerId) is null)
        //    return Errors.ManagementErrors.NotManager;

        var department = Department.Create(command.DepartmentName,command.ManagerId
            //,command.SecreteryId
            );
        _unitOfWork.DepartmentsRepository.AddNew(department);
        await _unitOfWork.CompleteAsync();
        return new CreateDepartmentResult(_unitOfWork.DepartmentsRepository.Find(d => d.Name == command.DepartmentName));
    }
}
