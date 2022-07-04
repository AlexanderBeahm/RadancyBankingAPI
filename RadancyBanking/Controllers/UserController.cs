using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadancyBanking.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public ActionResult Ping()
        {
            _logger.LogDebug("Pinged UserController");
            return Ok();
        }

        [HttpGet("/{userId}")]
        public ActionResult<User> GetUser([FromRoute][Required][Range(1, int.MaxValue)] int userId)
        {
            return new User
            {
                Accounts = new List<UserAccount>(),
                FamilyName = "Beahm",
                GivenName = "Alex",
                Id = userId
            };
        }

        [HttpPost()]
        public ActionResult<User> CreateUser([FromBody][Required]CreateUser createUser)
        {
            return new User
            {
                Accounts = new List<UserAccount>(),
                FamilyName = "Beahm",
                GivenName = "Alex",
                Id = 1
            };
        }

        [HttpDelete("/{userId}")]
        public ActionResult DeleteUser([FromRoute][Required][Range(1, int.MaxValue)] int userId)
        {
            return Ok();
        }
    }
}
