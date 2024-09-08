using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Errors;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Administrator;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Application.Services.Employement.Management.Commands;

public class SetEmployeeAsManagerCommandHandler : IRequestHandler<SetEmployeeAsManagerCommand, ErrorOr<SetEmployeeAsManagerResult>>
{
    private readonly IUnitOfWork _unitOfWork;



    public SetEmployeeAsManagerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<SetEmployeeAsManagerResult>> Handle(SetEmployeeAsManagerCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_unitOfWork.AdministratorsRepository.GetById(command.AdminId) is null)
            return Errors.AdminsErrors.NotAdmin;
        if (_unitOfWork.UsersRepository.Find(e=>e.Id==command.EmployeeId) is null)
            return Errors.AuthenticationErrors.InvalidUser;
        if (_unitOfWork.EmployeesRepository.Find(e => e.Id == command.EmployeeId) is null)
            return Errors.EmploymentErrors.NotEmployee;
        if (_unitOfWork.ManagersRepository.GetById(command.EmployeeId) is not null)
            return Errors.ManagementErrors.AlreadyManager;
        

        //If we use the var employee, no update will done for the repo.
        var user = _unitOfWork.UsersRepository.FindWithInclue(x=>x.Id==command.EmployeeId,x=>x.Profile);
        _unitOfWork.UsersRepository.Find(x => x.Id == command.EmployeeId).SetUserRole(RoleEnum.Manager);
        var employee = _unitOfWork.EmployeesRepository.GetById(command.EmployeeId);
        Manager manager = Manager.Create(employee, $"office");
        _unitOfWork.ManagersRepository.AddNew(manager);
        return new SetEmployeeAsManagerResult(command.AdminId,
            manager);
    }
}
