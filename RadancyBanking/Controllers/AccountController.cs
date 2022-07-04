using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadancyBanking.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public ActionResult Ping()
        {
            _logger.LogDebug("Pinged AccountController");
            return Ok();
        }

        [HttpPost()]
        public ActionResult<UserAccount> CreateAccount([FromBody][Required] CreateAccount createUser)
        {
            return new UserAccount
            {
                Id = 1,
                Balance = 100,
                Name = "",
                UserId = 1
            };
        }

        [HttpDelete("/{accountId}")]
        public ActionResult DeleteAccount([FromRoute][Required][Range(1, int.MaxValue)] int accountId)
        {
            return Ok();
        }

        [HttpPatch("/{accountId}")]
        public ActionResult<UserAccount> Withdraw([FromRoute][Required][Range(1, int.MaxValue)] int accountId, [FromBody] WithdrawalTransaction transaction)
        {
            return new UserAccount
            {
                Id = 1,
                Balance = 100,
                Name = "",
                UserId = 1
            };
        }

        [HttpPatch("/{accountId}")]
        public ActionResult<UserAccount>Deposit([FromRoute] [Required] [Range(1, int.MaxValue)] int accountId, [FromBody] WithdrawalTransaction transaction)
        {
            return new UserAccount
            {
                Id = 1,
                Balance = 100,
                Name = "",
                UserId = 1
            };
        }
    }
}
