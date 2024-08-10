using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Services.Employement.EmpVacation.Commands;
using Portal.Application.Services.Employement.EmpVacation.Common;
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
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("applyVacation")]
        public async Task<IActionResult> ApplyVacation(VacationRequest vacationRequest)
        {
            await Task.CompletedTask;
            var vacationCommand = _mapper.Map<VacationCommand>(vacationRequest);
            
            ErrorOr<VacationResult> vacationResult = await _mediator.Send(vacationCommand);
          

           
            IActionResult result = vacationResult.Match(vacationResult => Ok(_mapper.Map<VacationResponse>(vacationResult)),
                errors => Problem(errors));

            return result
             ;
        }
    }
}