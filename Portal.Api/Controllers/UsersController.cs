using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.User.ValueObjects;
using Portal.Domain.User;
using Microsoft.IdentityModel.Tokens;
using Portal.Conttracts.User;
using Microsoft.OpenApi.Extensions;

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
        [HttpGet("getAllUsers")]
        public  IActionResult GetAllUsers()
        {
            List<UserRecordResult> users = new();
            foreach (var user in _userRepository.GetAll())
            {
                users.Add(new UserRecordResult(
                    user.Id.Value.ToString(),
                    user.Profile.FirstName,
                    user.Profile.MiddleName,
                    user.Profile.LastName,
                    user.Profile.ArabicName,
                    user.Profile.Nationality.Name,
                    user.Profile.NationalId,
                    user.Profile.Gender.GetDisplayName(),
                    user.Profile.DateOfBirth,
                    user.Profile.ContactNumber,
                    new AddressRecordResult(user.Profile.Address.Street, user.Profile.Address.City, user.Profile.Address.State,user.Profile.Address.PostalCode,user.Profile.Address.Country),
                    user.Code,
                    user.Email,
                    user.UserRole.GetDisplayName(),
                    user.UserStatus.GetDisplayName()
                    ));
            }
            return Ok(users);
        }
        
    }
}
