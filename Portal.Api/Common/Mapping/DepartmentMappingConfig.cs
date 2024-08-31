using Mapster;
using Portal.Application.Services.Departments.Commands;
using Portal.Application.Services.Departments.Common;
using Portal.Conttracts.Department;
using Portal.Conttracts.User.Management;

namespace Portal.Api.Common.Mapping;

public class DepartmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateDepartmentRequest, CreateDepartmentCommand>()
            .Map(dest=>dest.AdminId.Value, src=>src.AdminId)
            .Map(dest=>dest.DepartmentName, src=>src.DepartmentName)
            .Map(dest=>dest.ManagerId.Value,src=>src.ManagerId)
            ;
        config.NewConfig<CreateDepartmentResult, CreateDepartmentResponse>()
            .Map(dest=>dest.DepartmentId, src=>src.Department.Id.Value.ToString())
            .Map(dest=>dest.DepartmentName, src=>src.Department.Name)
            .Map(dest=>dest.ManagerId, src=>src.Department.ManagerId.Value.ToString())
            ;
    }
}
