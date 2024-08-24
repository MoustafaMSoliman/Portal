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
                .Map(dest=>dest.ManagerId.Value, src=>src.ManagerId);

            config.NewConfig<ManagerEmployeesResult, ManagerEmployeesResponse>()
                .Map(dest=>dest.ManagerId, src=>src.Manager.Id.Value.ToString())
                .Map(dest=>dest.ManagerFirstName, src=>src.Manager.Profile.FirstName)
                .Map(dest => dest.ManagerLastName, src => src.Manager.Profile.LastName)
                .Map(dest=>dest.Employees, src=>src.Employees);
                ;
            config.NewConfig<ManagerEmployee, ManagerEmployeeResponse>()
                .Map(dest=>dest.EmployeeId, src=>src.EmployeeId.ToString())
                .Map(dest=>dest.EmployeeFirstName, src=>src.EmployeeFirstName);

            config.NewConfig<CreateDepartmentRequest, CreateDepartmentCommand>()
                .Map(dest => dest.DepartmentName, src => src.DepartmentName)
                .Map(dest => dest.ManagerId.Value, src => Guid.Parse(src.ManagerId))
                .Map(dest=>dest.SecreteryId.Value,src=>Guid.Parse(src.SecreteryId));

            config.NewConfig<CreateDepartmentResult, CreateDepartmentResponse>()
                .Map(dest => dest.DepartmentId, src => src.DepartmentId.Value.ToString())
                .Map(dest => dest.DepartmentName, src => src.DepartmentName)
                .Map(dest => dest.ManagerId, src => src.ManagerId.Value.ToString())
                .Map(dest => dest.ManagerName, src => src.ManagerName)
                //.Map(dest => dest.SecreteryId, src => src.SecreteryId.Value.ToString())
                //.Map(dest => dest.SecreteryName, src => src.SecreteryName)
                .Map(dest=>dest.DepartmentEmployees,src=>src.DepartmentEmployees)
                ;
            config.NewConfig<Employee, DepartmentEmployees>()
                .Map(dest=>dest.EmployeeId, src=>src.Id.Value.ToString())
                .Map(dest=>dest.EmployeeName, src=>src.Profile.FirstName)
                .Map(dest=>dest.Role, src=>src.UserRole.Value.GetDisplayName());
        }
    }
}
