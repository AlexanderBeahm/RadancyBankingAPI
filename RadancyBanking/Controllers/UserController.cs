using Microsoft.AspNetCore.Mvc;
using RadancyBanking.DomainModels;
using RadancyBanking.Services;
using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.Controllers
{
    /// <summary>
    /// Endpoint to handle user creation and management.
    /// </summary>
    [Route("/api/[controller]")]
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

        /// <summary>
        /// Get user by user Id.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Found user</returns>
        [HttpGet("/api/[controller]/{userId}")]
        public ActionResult<User> GetUser([FromRoute][Required][Range(1, int.MaxValue)] int userId)
        {
            var user = userService.GetUser(userId);
            return user == null ? NotFound($@"User not found with id {userId}") : Ok(user);
        }

        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="createUser">User creation payload</param>
        /// <returns>Created user</returns>
        [HttpPost()]
        public ActionResult<User> CreateUser([FromBody][Required] CreateUser createUser)
        {
            var user = userService.CreateUser(createUser);
            return user == null ? BadRequest() : Created(@$"/{user.Id}", user);
        }
    }
}
