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
        
        config.NewConfig<RetrieveAllUsersResult, RetrieveAllUsersResponse>()
            .Map(dest=>dest.Users, src=>src.Users);

        config.NewConfig<UserResult, UserResponse>()
            .Map(dest => dest.code, src => src.code)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            ;


    }
}
