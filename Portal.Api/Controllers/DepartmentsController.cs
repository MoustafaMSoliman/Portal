using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Services.Departments.Commands;
using Portal.Application.Services.Departments.Common;
using Portal.Conttracts.Department;

namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DepartmentsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateDepartmentRequest request)
        {
            await Task.CompletedTask;
            var command = _mapper.Map<CreateDepartmentCommand>(request);
            ErrorOr<CreateDepartmentResult> result = await _mediator.Send(command);
            return result.Match(
                 result=>Ok(_mapper.Map<CreateDepartmentResponse>(result)),
                 errors=>Problem(errors)
                );
        }
    }
}
