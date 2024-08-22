using Mapster;
using Microsoft.OpenApi.Extensions;
using Portal.Application.Services.Authentication.Commands;
using Portal.Application.Services.Authentication.Common;
using Portal.Application.Services.Authentication.Queries;
using Portal.Application.Services.Employement.EmpVacation.Commands;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Conttracts.Authentication;
using Portal.Conttracts.User.Employee;

namespace Portal.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthResult, AuthenticationResult>()
            .Map(dest=>dest.UserId, src=>src.User.Id.Value.ToString())
            .Map(dest=>dest.Code, src=>src.User.Code)
            .Map(dest=>dest.FirstName, src=>src.User.Profile.FirstName)
            .Map(dest => dest.MiddleName, src => src.User.Profile.MiddleName)
            .Map(dest=>dest.LastName, src=>src.User.Profile.LastName)
            .Map(dest => dest.ArabicName, src => src.User.Profile.ArabicName)
            .Map(dest => dest.Nationality, src => src.User.Profile.Nationality)
            .Map(dest => dest.NationalId, src => src.User.Profile.NationalId)
            .Map(dest => dest.Gender, src => src.User.Profile.Gender.ToString())
            .Map(dest => dest.DateOfBirth, src => src.User.Profile.DateOfBirth)
            .Map(dest => dest.ContactNumber, src => src.User.Profile.ContactNumber)
            .Map(dest=>dest.Email, src=>src.User.Email.Value)
            .Map(dest=>dest.UserType, src => src.User.UserType.Value.GetDisplayName())
            .Map(dest=>dest.Role, src=>src.User.UserRole.Value.GetDisplayName())
            .Map(dest=>dest.Token, src=>src.Token)
            ;

        config.NewConfig<RegisterRequest, RegisterCommand>()
            .Map(dest => dest.Code, src => src.Code)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.MiddleName, src => src.MiddleName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.ArabicName, src => src.ArabicName)
            .Map(dest => dest.Nationality, src => src.Nationality)
            .Map(dest => dest.NationalId, src => src.NationalId)
            .Map(dest => dest.Gender, src => src.Gender)
            .Map(dest => dest.DateOfBirth, src => src.DateOfBirth)
            .Map(dest => dest.ContactNumber, src => src.ContactNumber)
            .Map(dest => dest.Address, src => src.Address)
            .Map(dest => dest.UserType, src => src.UserType)
            .Map(dest => dest.Role, src => src.Role)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            ;

        config.NewConfig<LoginRequest, LoginQuery > ()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password);

        
    }
}
