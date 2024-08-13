using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Application.Services.Employement.EmpVacation.Commands;
using Portal.Application.Services.Employement.EmpVacation.Common;
using Portal.Conttracts.User.Employee;
using Portal.Domain.User;
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
        private readonly IAggregateRootRepository<User,UserId,Guid> _usersRepository;
        private readonly IAggregateRootRepository<Manager, UserId, Guid> _managersRepository;


        public EmployeesController(IMediator mediator, IMapper mapper, 
            IAggregateRootRepository<User, UserId, Guid> usersRepository,
            IAggregateRootRepository<Manager, UserId, Guid> managersRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _usersRepository = usersRepository;
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
        [HttpPost("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            await Task.CompletedTask;

            return Ok(_usersRepository.GetAll())
                ;
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