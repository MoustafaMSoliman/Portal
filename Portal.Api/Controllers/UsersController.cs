using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Common.Interfaces.Persistence;

namespace Portal.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            await Task.CompletedTask;
            var users = _userRepository.GetAllUsers();
            return Ok(users);

        }
        
    }
}
