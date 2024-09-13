using Mapster;
using Microsoft.OpenApi.Extensions;
using Portal.Application.Services.Employement.Management.Commands;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Application.Services.Users.Common;
using Portal.Application.Services.Users.Queries;
using Portal.Conttracts.User;
using Portal.Conttracts.User.Management;
using Portal.Domain.User;

namespace Portal.Api.Common.Mapping;

public class AdminMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SetEmployeeAsManagerRequest, SetEmployeeAsManagerCommand>()
            .Map(dest=>dest.AdminId.Value, src=>src.AdminId)
            .Map(dest=>dest.EmployeeId.Value, src=>src.EmployeeId)
            ;
        config.NewConfig<SetEmployeeAsManagerResult, SetEmployeeAsManagerResponse>()
            .Map(dest=>dest.AdminId, src=>src.AdminId.Value.ToString())
            .Map(dest=>dest.ManagerId, src=>src.Manager.Id.Value.ToString())
            .Map(dest=>dest.ManagerFirstName, src=>src.Manager.Profile.FirstName)
            .Map(dest => dest.ManagerLastName, src => src.Manager.Profile.LastName)
            .Map(dest=>dest.Role, src=>src.Manager.UserRole.GetDisplayName())
            ;

        config.NewConfig<RetrieveAllUsersRequest, RetrieveAllUsersQuery>()
            .Map(dest => dest.AdminId.Value, src => src.AdminId);
        config.NewConfig<User, UserRecordResult>()
            .Map(dest => dest.UserId, src => src.Id.Value.ToString())
            .Map(dest => dest.Code, src => src.Code)
            .Map(dest => dest.FirstName, src => src.Profile.FirstName)
            .Map(dest => dest.MiddleName, src => src.Profile.MiddleName)
            .Map(dest => dest.LastName, src => src.Profile.LastName)
            .Map(dest => dest.ArabicName, src => src.Profile.ArabicName)
            .Map(dest => dest.Nationality, src => src.Profile.Nationality)
            .Map(dest => dest.NationalId, src => src.Profile.NationalId)
            .Map(dest => dest.Gender, src => src.Profile.Gender.ToString())
            .Map(dest => dest.DateOfBirth, src => src.Profile.DateOfBirth)
            .Map(dest => dest.ContactNumber, src => src.Profile.ContactNumber)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Type, src => src.UserType.GetDisplayName())
            .Map(dest => dest.Role, src => src.UserRole.GetDisplayName())
            ;
        config.NewConfig<RetrieveAllUsersResult, RetrieveAllUsersResponse>()
            .Map(dest => dest.Users, src => src.Users);
        
    }
}
