using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.User.ValueObjects;
using Portal.Domain.User;

namespace Portal.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ApiController
    {
        private IAggregateRootRepository<User, UserId,Guid> _userRepository;

        public UsersController(IAggregateRootRepository<User, UserId, Guid> userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public  IActionResult GetAllUsers()
        {
            return Ok(_userRepository.GetAll());
        }
        
    }
}
