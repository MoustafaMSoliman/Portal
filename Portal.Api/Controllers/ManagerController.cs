using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Application.Services.Employement.Management.Queries;
using Portal.Conttracts.User.Management;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManagerController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ManagerController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees(GetManagerEmployeesRequest getManagerEmployeesRequest)
        {
            await Task.CompletedTask;
            var getManagerEmployeesQuery = _mapper.Map<GetManagerEmployeesQuery>(getManagerEmployeesRequest);
            ErrorOr<ManagerEmployeesResult> managerEmployeesResult = await _mediator.Send(getManagerEmployeesQuery);
            return managerEmployeesResult.Match(
                managerEmployeesResult => Ok(_mapper.Map<ManagerEmployeesResponse>(managerEmployeesResult)),
                errors => Problem(errors)
                );

        }
        [HttpGet("GetEmployeesVacations")]
        public async Task<IActionResult> GetEmployeesVacations(GetManagerEmployeesVacationsRequest getManagerEmployeesVacationsRequest)
        {
            await Task.CompletedTask;
            var getManagerEmployeesVacationQuery = _mapper.Map<GetManagerEmployeesVacationsQuery>(getManagerEmployeesVacationsRequest);
            ErrorOr<ManagerEmployeesVacationResult> managerEmployeesVacationResult = await _mediator.Send(getManagerEmployeesVacationQuery);
            return managerEmployeesVacationResult.Match(
                managerEmployeesVacationResult=>Ok(_mapper.Map<ManagerEmployeesVacationsResponse>(managerEmployeesVacationResult)),
                errors => Problem(errors)
                );

        }
    }
}
