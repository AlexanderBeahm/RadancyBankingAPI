using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadancyBanking.DomainModels;
using RadancyBanking.Services;
using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpGet("/{userId}")]
        public ActionResult<User> GetUser([FromRoute][Required][Range(1, int.MaxValue)] int userId)
        {
            return userService.GetUser(userId);
        }

        [HttpPost()]
        public ActionResult<User> CreateUser([FromBody][Required]CreateUser createUser)
        {
            return userService.CreateUser(createUser);
        }
    }
}
