using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Portal.Application.Common.Interfaces.Authentication;
using Portal.Application.Services.Authentication.Commands;
using Portal.Application.Services.Authentication.Common;
using Portal.Application.Services.Authentication.Queries;
using Portal.Conttracts.Authentication;
using Portal.Domain.User;


namespace Portal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
           await Task.CompletedTask;
           var registerCommand = _mapper.Map<RegisterCommand>(registerRequest);
           ErrorOr<AuthResult> authResult = await _mediator.Send(registerCommand);

            return authResult.Match(
                 authResult=>Ok(_mapper.Map<AuthenticationResult>(authResult)),
                 errors=> Problem(errors)

                );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            await Task.CompletedTask;
            var loginQuery = _mapper.Map<LoginQuery>(loginRequest);
            ErrorOr<AuthResult> authResult = await _mediator.Send(loginQuery);  
            return authResult.Match(
                authResult=>Ok(_mapper.Map<AuthenticationResult>(authResult)),
                errors=>Problem(errors)
                );
        }
        
    }
}
