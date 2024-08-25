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
    private readonly IAggregateRootRepository<Administrator, UserId, Guid> _adminsRepository;
    private readonly IAggregateRootRepository<Employee, UserId, Guid> _employeessRepository;
    private readonly IAggregateRootRepository<User, UserId, Guid> _usersRepository;



    public SetEmployeeAsManagerCommandHandler(IAggregateRootRepository<Administrator, UserId, Guid> adminsRepository,
        IAggregateRootRepository<Employee, UserId, Guid> employeessRepository,
        IAggregateRootRepository<User, UserId, Guid> usersRepository
        )
    {
        _adminsRepository = adminsRepository;
        _employeessRepository = employeessRepository;
        _usersRepository = usersRepository;
    }
    public async Task<ErrorOr<SetEmployeeAsManagerResult>> Handle(SetEmployeeAsManagerCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var adminUser = User.Create(UserId.Create(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
                Email.Create("admin1@portal.com"), "P2ssw0rd", 
               UserType.Create(TypeEnum.Employee),
                                                 UserRole.Create(RoleEnum.Administrator), Profile.Create(
                                                      "Moustafa",
                                                      "Mahmood",
                                                      "Soliman",
                                                      "مصطفي محمود سليمان",
                                                      Nationality.Create("egyptian"),
                                                      12344567889899,
                                                      Gender.Male,
                                                      DateTime.Now,
                                                      "010002",
                                                      Address.Create(
                                                           "anasary",
                                                           "cairo",
                                                           "cairo",
                                                           "1234",
                                                           "egypt"
                                                      )
                                                    ), 1, UserId.Create(Guid.Empty), UserId.Create(Guid.Empty)
                );
        _adminsRepository.AddNew(Administrator.Create(
            adminUser
            ));

        //if (_adminsRepository.GetById(command.AdminId) is null)
        //    return Errors.AdminsErrors.NotAdmin;
        if (_employeessRepository.Find(e=>e.Id==command.EmployeeId) is null)
            return Errors.AuthenticationErrors.InvalidUser;
        if (_employeessRepository.Find(m=>m.Id==command.EmployeeId).UserRole.Value == RoleEnum.Manager)
            return Errors.ManagementErrors.AlreadyManager;
      
       
        //If we use the var employee, no update will done for the repo.
        _employeessRepository.GetById(command.EmployeeId).SetUserRole(UserRole.Create( RoleEnum.Manager) );
        _usersRepository.GetById(command.EmployeeId).SetUserRole(UserRole.Create(RoleEnum.Manager));

       
       
        return new SetEmployeeAsManagerResult(command.AdminId,
            _employeessRepository.GetById(command.EmployeeId));
    }
}
