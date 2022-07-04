using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
