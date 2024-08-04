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
namespace Portal.Application.Services.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IUserRepository _userRepository;
    //private readonly IEmployeeRepository _employeeRepository;
    private readonly IJWTGenerator _jwtGenerator;
    private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public RegisterCommandHandler(IUserRepository userRepository, IJWTGenerator jwtGenerator
        //,IEmployeeRepository employeeRepository
        )
    {
        _userRepository = userRepository;
        _jwtGenerator = jwtGenerator;
        //_employeeRepository = employeeRepository;
    }
    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand registerRequest, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        string? Token;
        if (!IsValidEmail(registerRequest.Email))
            return Errors.EmailErrors.InValidEmail;
        if (_userRepository.GetUserByEmail(registerRequest.Email) is not null)
        {
            return Errors.UserErrors.DuplicateEmail;
        }

        
        
        User user = User.Create(
            registerRequest.Email,
            registerRequest.Password,
            registerRequest.Role,
            Profile.Create(registerRequest.FirstName,
              registerRequest.MiddleName,
              registerRequest.LastName,
              registerRequest.ArabicName,
              registerRequest.Nationality,
              registerRequest.NationalId,
              registerRequest.Gender,
              registerRequest.DateOfBirth,
              registerRequest.ContactNumber,
              Address.Create(registerRequest.Address.Street,
                 registerRequest.Address.City,
                 registerRequest.Address.State,
                 registerRequest.Address.PostalCode,
                 registerRequest.Address.Country
              )
            ),registerRequest.Code
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
        _userRepository.AddUser(user);
         Token = _jwtGenerator.GenerateToken(user);
        return new AuthResult(user, Token);
    }

    private bool IsValidEmail(string email)
    {
        return EmailRegex.IsMatch(email);
        
    }
}
