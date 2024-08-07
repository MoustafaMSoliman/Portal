using Mapster;
using Portal.Application.Services.Employement.Commands;
using Portal.Application.Services.Employement.Common;
using Portal.Conttracts.User.Employee;

namespace Portal.Api.Common.Mapping;

public class VacationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<VacationCommand, VacationRequest>()
            .Map(dest=>dest.EmployeeId, src=>src.EmployeeId.Value)
            .Map(dest=>dest.StartFrom, src=>src.StartFrom)
            .Map(dest=>dest.EndAt, src=>src.EndAt)
            .Map(dest=>dest.VacationType, src=>src.VacationType.ToString())
            .Map(dest=>dest.VacationStatus, src=>src.VacationStatus.ToString());

        config.NewConfig<VacationResult, VacationResponse>()
            .Map(dest => dest.Id, src => src.Vacation.Id)
            .Map(dest => dest.EmployeeId, src => src.Vacation.EmployeeId.Value.ToString())
            .Map(dest => dest.EmployeeName, src => src.Vacation.EmployeeId.Value.ToString())
            .Map(dest => dest.VacationType, src => src.Vacation.VacationType.ToString())
            .Map(dest => dest.VacationStatus, src => src.Vacation.VacationStatus.ToString())
            .Map(dest => dest.StartFrom, src => src.Vacation.StartFrom)
            .Map(dest => dest.EndAt, src => src.Vacation.EndAt)
            .Map(dest => dest.TotalVacationDays, src => src.Vacation.GetTotalVacationDays())
            .Map(dest => dest.AcceptedBy, src => src.Vacation.AcceptedBy.Value.ToString())
            .Map(dest => dest.AcceptedOn, src => src.Vacation.AcceptedOn)
            .Map(dest => dest.ApprovedBy, src => src.Vacation.ApprovedBy.Value.ToString())
            .Map(dest => dest.ApprovedOn, src => src.Vacation.ApprovedOn)
            .Map(dest => dest.RejectedBy, src => src.Vacation.RejectedBy.Value.ToString())
            .Map(dest => dest.RejectedOn, src => src.Vacation.RejectedOn)
            ;
       
    }
}
