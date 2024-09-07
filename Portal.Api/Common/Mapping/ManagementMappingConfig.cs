using Mapster;
using Microsoft.OpenApi.Extensions;
using Portal.Application.Services.Employement.Management.Commands;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Application.Services.Employement.Management.Queries;
using Portal.Conttracts.User.Management;
using Portal.Domain.User.Entities.Employee;

namespace Portal.Api.Common.Mapping
{
    public class ManagementMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetManagerEmployeesRequest, GetManagerEmployeesQuery>()
                .Map(dest => dest.ManagerId.Value, src => src.ManagerId);

            config.NewConfig<ManagerEmployeesResult, ManagerEmployeesResponse>()
                .Map(dest => dest.ManagerId, src => src.Manager.Id.Value.ToString())
                .Map(dest => dest.ManagerFirstName, src => src.Manager.Profile.FirstName)
                .Map(dest => dest.ManagerLastName, src => src.Manager.Profile.LastName)
                .Map(dest => dest.Employees, src => src.Employees);
            ;
            config.NewConfig<ManagerEmployee, ManagerEmployeeResponse>()
                .Map(dest => dest.EmployeeId, src => src.EmployeeId.ToString())
                .Map(dest => dest.EmployeeFirstName, src => src.EmployeeFirstName);

            config.NewConfig<GetManagerEmployeesVacationsRequest, GetManagerEmployeesVacationsQuery>()
                .Map(dest=>dest.ManagerId, src=>src.ManagerId);
            config.NewConfig<ManagerEmployeeWithVacation, ManagerEmployeeVacationsResponse>()
                .Map(dest=>dest.EmployeeId, src=>src.EmployeeId.ToString())
                .Map(dest=>dest.EmployeeFirstName, src=>src.EmployeeFirstName)
                .Map(dest=>dest.Vacations, src=>src.Vacations)
                ;
            config.NewConfig<ManagerEmployeesVacationResult, ManagerEmployeesVacationsResponse>()
                .Map(dest=>dest.ManagerId, src=>src.Manager.Id.Value.ToString())
                .Map(dest=>dest.ManagerFirstName, src=>src.Manager.Profile.FirstName)
                .Map(dest=>dest.ManagerLastName, src=>src.Manager.Profile.LastName)
                .Map(dest=>dest.Employees, src=>src.Employees);
        }  
           
    }
}
