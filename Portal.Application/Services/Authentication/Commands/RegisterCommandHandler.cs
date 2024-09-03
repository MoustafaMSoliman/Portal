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
using Portal.Domain.User.Entities.Administrator;
using Portal.Domain.Department;
using Portal.Domain.User.Entities.Employee.Entities;
namespace Portal.Application.Services.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly PortalDbContext _dbContext;

    private readonly IJWTGenerator _jwtGenerator;
    private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public RegisterCommandHandler(IJWTGenerator jwtGenerator,IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _jwtGenerator = jwtGenerator;
        
        
    }
    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand registerCommand, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        string? Token;
        Employee employee;
        if (!IsValidEmail(registerCommand.Email))
            return Errors.EmailErrors.InValidEmail;
        if (_unitOfWork.UsersRepository.Find(x=>x.Email == registerCommand.Email) is not null)
        {
            return Errors.UserErrors.DuplicateEmail;
        }

        
        
        User user = User.Create(
            registerCommand.Email,
            registerCommand.Password,
            registerCommand.UserType,
           registerCommand.Role,
            StatusEnum.Active,
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
        //if (registerCommand.Role == RoleEnum.Manager)
        //{
        //    _unitOfWork.ManagersRepository.AddNew(Manager.Create());
        //}


        if (registerCommand.UserType == TypeEnum.Employee)
        {
            var department = _unitOfWork.DepartmentsRepository.Find(x => x.Name == "StudentsAffairs");
            employee = Employee.Create(user, (DepartmentId)department.Id, DateTime.Now);
            if (employee.UserRole == RoleEnum.Administrator)
            {
                _unitOfWork.AdministratorsRepository.AddNew(Administrator.Create(employee));
                await _unitOfWork.CompleteAsync();
                Token = _jwtGenerator.GenerateToken(user);

                return new AuthResult(user, Token);
            }
            else if (employee.UserRole == RoleEnum.Manager)
            {
                _unitOfWork.ManagersRepository.AddNew(Manager.Create(employee, $"{employee.Profile.FirstName}'s office"));
                await _unitOfWork.CompleteAsync();
                Token = _jwtGenerator.GenerateToken(user);

                return new AuthResult(user, Token);
            }
            _unitOfWork.EmployeesRepository.AddNew(employee);
            await _unitOfWork.CompleteAsync();
            
          
            Token = _jwtGenerator.GenerateToken(user);

            return new AuthResult(user, Token);
        }
        
        
        


            _unitOfWork.UsersRepository.AddNew(user);
        await _unitOfWork.CompleteAsync();

        //if (registerCommand.Role == RoleEnum.Administrator)
        //{


        //    _unitOfWork.AdministratorsRepository.AddNew(Administrator.Create(user));
        //    await _unitOfWork.CompleteAsync();

        //}

        Token = _jwtGenerator.GenerateToken(user);

            return new AuthResult(user, Token);
        
    }

    private bool IsValidEmail(string email)
    {
        return EmailRegex.IsMatch(email);
        
    }
   
}
