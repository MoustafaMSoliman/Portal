using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Departments.Common;
using Portal.Domain.Common.Errors;
using Portal.Domain.Department;

namespace Portal.Application.Services.Departments.Commands;

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
        if (_unitOfWork.AdministratorsRepository.GetById(command.AdminId) is null)
            return Errors.AdminsErrors.NotAdmin;
        if (_unitOfWork.DepartmentsRepository.Find(x => x.Name == command.DepartmentName) is not null)
            return Errors.DepartmentErrors.DuplicateDepartment;
        var department = Department.Create(command.DepartmentName,command.ManagerId);
        _unitOfWork.DepartmentsRepository.AddNew(department);
        await _unitOfWork.CompleteAsync();
        return new CreateDepartmentResult(department);
        
    }
}
