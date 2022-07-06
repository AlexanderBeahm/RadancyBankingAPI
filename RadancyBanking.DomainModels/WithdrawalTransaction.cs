using RadancyBanking.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Implementation of Withdrawal transaction for AccountTransaction
    /// </summary>
    public class WithdrawalTransaction : AccountTransaction
    {
        /// <summary>
        /// Transaction Type of Withdrawal
        /// </summary>
        public override TransactionType GetTransactionType() => TransactionType.Withdrawal;

        /// <summary>
        /// Applies withdrawal transaction to user account.
        /// </summary>
        /// <param name="account">User account to modify</param>
        /// <returns></returns>
        public override decimal ApplyTransaction(UserAccount account) => account.Balance -= Amount;
    }
}
