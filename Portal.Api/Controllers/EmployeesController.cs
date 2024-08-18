using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.EmpVacation.Commands;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Application.Services.Employement.EmpVacation.Queries;
using Portal.Conttracts.User.Employee;
using Portal.Domain.User;
using Portal.Domain.User.Entities.Employee;
using Portal.Domain.User.Entities.Employee.Entities;
using Portal.Domain.User.ValueObjects;

namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IAggregateRootRepository<Employee,UserId,Guid> _employeesRepository;
        private readonly IAggregateRootRepository<Manager, UserId, Guid> _managersRepository;


        public EmployeesController(IMediator mediator, IMapper mapper, 
            IAggregateRootRepository<Employee, UserId, Guid> usersRepository,
            IAggregateRootRepository<Manager, UserId, Guid> managersRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _employeesRepository = usersRepository;
            _managersRepository = managersRepository;
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
        [HttpGet("GetVacations")]
        public async Task<IActionResult> GetVacations(RetrieveEmployeeVacationsRequest retrieveEmployeeVacationsRequest)
        {
            await Task.CompletedTask;
            var getVacationsQuery = _mapper.Map<GetEmployeeVacationsQuery>(retrieveEmployeeVacationsRequest);
            ErrorOr<RetrieveVacationsResult> vacations = await _mediator.Send(getVacationsQuery);

            return vacations.Match(
                vacations=>Ok(_mapper.Map<RetrieveVacationsResponse>(vacations)),
                errors=>Problem(errors)
                );
        }
        
        [HttpPost("getAllManagers")]
        public async Task<IActionResult> GetAllManagers()
        {
            await Task.CompletedTask;

            return Ok(_managersRepository.GetAll())
                ;
        }
    }
}