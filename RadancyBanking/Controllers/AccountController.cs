using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadancyBanking.DomainModels;
using RadancyBanking.Services;
using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            this.accountService = accountService;
        }

        [HttpGet()]
        public ActionResult Ping()
        {
            _logger.LogDebug("Pinged AccountController");
            return Ok();
        }

        [HttpPost()]
        public ActionResult<UserAccount> CreateAccount([FromBody][Required] CreateAccount createAccount)
        {
            return accountService.CreateAccount(createAccount);
        }

        [HttpDelete("/{accountId}")]
        public ActionResult DeleteAccount([FromRoute][Required][Range(1, int.MaxValue)] int accountId)
        {
            accountService.DeleteAccount(accountId);
            return Ok();
        }

        [HttpPatch("/{accountId}/Withdraw")]
        public ActionResult<UserAccount> Withdraw([FromRoute][Required][Range(1, int.MaxValue)] int accountId, [FromBody] WithdrawalTransaction transaction)
        {
            return accountService.ApplyTransaction(accountId, transaction);
        }

        [HttpPatch("/{accountId}/Deposit")]
        public ActionResult<UserAccount>Deposit([FromRoute] [Required] [Range(1, int.MaxValue)] int accountId, [FromBody] WithdrawalTransaction transaction)
        {
           return accountService.ApplyTransaction(accountId, transaction);
        }
    }
}
