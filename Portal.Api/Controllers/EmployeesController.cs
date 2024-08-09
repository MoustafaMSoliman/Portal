using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Services.Employement.Commands;
using Portal.Application.Services.Employement.Common;
using Portal.Conttracts.User.Employee;
using Portal.Domain.User.Entities.Employee.Entities;

namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("applyVacation")]
        public async Task<IActionResult> ApplyVacation(VacationRequest vacationRequest)
        {
            await Task.CompletedTask;
            var vacationCommand = _mapper.Map<VacationCommand>(vacationRequest);
            ErrorOr<VacationResult> vacationResult = await _mediator.Send(vacationCommand);
            return vacationResult.Match(
                vacationResult=>Ok(_mapper.Map<VacationResponse>(vacationResult)),
                errors=>Problem(errors)
             );

        }
    }
}
