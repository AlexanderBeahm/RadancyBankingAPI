using Microsoft.AspNetCore.Mvc;
using RadancyBanking.DomainModels;
using RadancyBanking.Services;
using System.ComponentModel.DataAnnotations;

namespace RadancyBanking.Controllers
{
    /// <summary>
    /// Endpoint to handle account visibility and transactions.
    /// </summary>
    [Route("/api/[controller]")]
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

        /// <summary>
        /// Create an account for given user with initial deposit >$100.
        /// </summary>
        /// <param name="createAccount">Object representing account parameters</param>
        /// <returns>Created user account</returns>
        [HttpPost()]
        public ActionResult<UserAccount> CreateAccount([FromBody][Required(ErrorMessage = "CreateAccount body required.")] CreateAccount createAccount)
        {
            var account = accountService.CreateAccount(createAccount);
            return account == null ? BadRequest() : Created(@$"/{account.Id}", account);
        }

        /// <summary>
        /// Delete an account for given account id.
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns></returns>
        [HttpDelete("/api/[controller]/{accountId}")]
        public ActionResult DeleteAccount([FromRoute][Required][Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0.")] int accountId)
        {
            accountService.DeleteAccount(accountId);
            return Ok();
        }

        /// <summary>
        /// Withdraw from account.
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <param name="transaction">Transaction object for withdrawal</param>
        /// <returns>Updated account</returns>
        [HttpPatch("/api/[controller]/{accountId}/Withdraw")]
        public ActionResult<UserAccount> Withdraw([FromRoute][Required][Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0.")] int accountId, [FromBody] WithdrawalTransaction transaction)
        {
            var account = accountService.ApplyTransaction(accountId, transaction);
            return account == null ? BadRequest() : Ok(account);
        }

        /// <summary>
        /// Deposit into account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <param name="transaction">Transaction object for deposit</param>
        /// <returns>Updated account</returns>
        [HttpPatch("/api/[controller]/{accountId}/Deposit")]
        public ActionResult<UserAccount> Deposit([FromRoute][Required][Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0.")] int accountId, [FromBody] WithdrawalTransaction transaction)
        {
            var account = accountService.ApplyTransaction(accountId, transaction);
            return account == null ? BadRequest() : Ok(account);
        }
    }
}
