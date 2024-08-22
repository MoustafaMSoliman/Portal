using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Authentication;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Authentication.Common;
using Portal.Domain.User.ValueObjects;
using Portal.Domain.Common.Errors;
using Portal.Domain.User;
using Address = Portal.Domain.User.ValueObjects.Address;
using System.Text.RegularExpressions;
using Portal.Domain.Common.Enums;
using Portal.Domain.User.Entities;
using Portal.Domain.Common.Interfaces.User;
using Portal.Domain.User.Career;
using Portal.Domain.Department.ValueObjects;
using Portal.Domain.User.Entities.Employee;
namespace Portal.Application.Services.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IAggregateRootRepository<User, UserId, Guid> _userRepository;
    private readonly IAggregateRootRepository<Employee, UserId, Guid> _employeeRepository;
    //private readonly PortalDbContext _dbContext;

    private readonly IJWTGenerator _jwtGenerator;
    private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public RegisterCommandHandler(IAggregateRootRepository<User, UserId, Guid> userRepository, IJWTGenerator jwtGenerator
        ,IAggregateRootRepository<Employee, UserId, Guid> employeeRepository
        )
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
        _employeeRepository = employeeRepository;
        
    }
    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand registerCommand, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        string? Token;
        if (!IsValidEmail(registerCommand.Email))
            return Errors.EmailErrors.InValidEmail;
        if (_userRepository.Find(x=>x.Email.Value == registerCommand.Email) is not null)
        {
            return Errors.UserErrors.DuplicateEmail;
        }

        
        
        User user = User.Create(
            Email.Create(registerCommand.Email),
            registerCommand.Password,
            UserType.Create(registerCommand.UserType),
            UserRole.Create(registerCommand.Role),
            Profile.Create(registerCommand.FirstName,
              registerCommand.MiddleName,
              registerCommand.LastName,
              registerCommand.ArabicName,
                Nationality.Create(registerCommand.Nationality),
              registerCommand.NationalId,
              registerCommand.Gender,
              registerCommand.DateOfBirth,
              registerCommand.ContactNumber,
              Address.Create(registerCommand.Address.Street,
                 registerCommand.Address.City,
                 registerCommand.Address.State,
                 registerCommand.Address.PostalCode,
                 registerCommand.Address.Country
              )
            ), registerCommand.Code,
            registerCommand.CreatedBy,
            registerCommand.UpdatedBy
         );
        //if (registerRequest.Role == RoleEnum.Employee)
        //{
        //    ICareerTitle title1 = CareerTitle.Create("Software Engineer");
        //    ICareerTitle title2 = CareerTitle.Create("Civil Engineer");

        //    ICareerSpecialization specialization = 
        //        CareerSpecialization.Create("Contracts", new List<ICareerTitle>() { title1, title2 });
        //    ICareerGroup careerGroup = CareerGroup.Create("Contracts", new List<ICareerSpecialization>() { specialization });
        //    var emp = Employee.Create(user, DepartmentId.CreateUnique(), DateTime.Now, careerGroup);
        //    _employeeRepository.AddEmployee(emp);
        //    Token = _jwtGenerator.GenerateToken(emp);
        //    return new AuthResult(emp, Token);
        //}
        _userRepository.AddNew(user);
        if (registerCommand.UserType == TypeEnum.Employee)
        {
            var careerTitles = CareerTitle.Create("مهندس شبكات");
            var carrerSpecialization = CareerSpecialization.Create("يومية",new List<ICareerTitle>{ careerTitles});
            var carrerGroup = CareerGroup.Create("عقود", new List<ICareerSpecialization>{ carrerSpecialization } );

            _employeeRepository.AddNew(Employee.Create(user, DepartmentId.CreateUnique(), DateTime.Now
                //,carrerGroup
                ));
        }
            
         Token = _jwtGenerator.GenerateToken(user);
        
        return new AuthResult(user, Token);
    }

    private bool IsValidEmail(string email)
    {
        return EmailRegex.IsMatch(email);
        
    }
}
