using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.User.ValueObjects;
using Portal.Domain.User;
using Microsoft.IdentityModel.Tokens;
using Portal.Conttracts.User;
using Microsoft.OpenApi.Extensions;
using MediatR;
using MapsterMapper;
using ErrorOr;
using Portal.Application.Services.Users.Queries;
using Portal.Application.Services.Users.Common;

namespace Portal.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        

    }
}
