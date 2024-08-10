using Mapster;
using Portal.Application.Services.Employement.EmpVacation.Commands;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Conttracts.User.Employee;

namespace Portal.Api.Common.Mapping;

public class VacationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<VacationRequest, VacationCommand>()
            .Map(dest => dest.EmployeeId.Value, src => src.EmployeeId)
            .Map(dest => dest.StartFrom, src => src.StartFrom)
            .Map(dest => dest.EndAt, src => src.EndAt)
            .Map(dest => dest.VacationType, src => src.VacationType.ToString())
            .Map(dest => dest.VacationStatus, src => src.VacationStatus.ToString());

        config.NewConfig<VacationResult, VacationResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.EmployeeId, src => src.EmployeeId.Value.ToString())
            //.Map(dest => dest.EmployeeName, src => src.Vacation.EmployeeId.Value.ToString())
            .Map(dest => dest.VacationType, src => src.VacationType.ToString())
            .Map(dest => dest.VacationStatus, src => src.VacationStatus.ToString())
            .Map(dest => dest.StartFrom, src => src.StartFrom)
            .Map(dest => dest.EndAt, src => src.EndAt)
            .Map(dest => dest.TotalVacationDays, src => src.TotalVacationDays)
            //.Map(dest => dest.AcceptedBy, src => src.AcceptedBy.Value.ToString())
            //.Map(dest => dest.AcceptedOn, src => src.AcceptedOn)
            //.Map(dest => dest.ApprovedBy, src => src.ApprovedBy.Value.ToString())
            //.Map(dest => dest.ApprovedOn, src => src.ApprovedOn)
            //.Map(dest => dest.RejectedBy, src => src.RejectedBy.Value.ToString())
            //.Map(dest => dest.RejectedOn, src => src.RejectedOn)
            ;

    }
}
