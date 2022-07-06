using RadancyBanking.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Implementation of Deposit Transaction for AccountTransaction object.
    /// </summary>
    public class DepositTransaction : AccountTransaction
    {
        /// <summary>
        /// Returns transaction type, deposit
        /// </summary>
        public override TransactionType GetTransactionType() => TransactionType.Deposit;

        /// <summary>
        /// Applies a deposit transaction to the user account.
        /// </summary>
        /// <param name="account">Account to modify</param>
        /// <returns>New balance amount</returns>
        public override decimal ApplyTransaction(UserAccount account) => account.Balance += Amount;
    }
}
