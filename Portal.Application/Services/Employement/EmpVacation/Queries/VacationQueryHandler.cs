using ErrorOr;
using MediatR;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.EmpVacation.Common;

namespace Portal.Application.Services.Employement.EmpVacation.Queries;

public class VacationQueryHandler : IRequestHandler<VacationQuery, ErrorOr<VacationResult>>
{
    
    public Task<ErrorOr<VacationResult>> Handle(VacationQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
