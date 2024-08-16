using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Services.Employement.Management.Commands;
using Portal.Application.Services.Employement.Management.Common;
using Portal.Conttracts.User.Management;
using ErrorOr;

namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdminController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("SetEmployeeAsManager")]
        public async Task<IActionResult> SetEmployeeAsManager(SetEmployeeAsManagerRequest request )
        {
            await Task.CompletedTask;
            var setEmployeeAsManagerCommand = _mapper.Map<SetEmployeeAsManagerCommand>( request );
            ErrorOr<SetEmployeeAsManagerResult> setEmployeeAsManagerResult = await _mediator.Send(setEmployeeAsManagerCommand);

            return setEmployeeAsManagerResult.Match(
                setEmployeeAsManagerResult => Ok(_mapper.Map<SetEmployeeAsManagerResponse>(setEmployeeAsManagerResult)),
                errors=>Problem(errors)
            );
        }
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment()
        {
            await Task.CompletedTask;
            return Ok();
        }
       
    }
}
