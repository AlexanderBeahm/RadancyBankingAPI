using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Post Withdrawal transaction object.
    /// </summary>
    public class PostWithdraw
    {
        /// <summary>
        /// Withdrawal transaction
        /// </summary>
        public WithdrawalTransaction? Transaction {get; set;}
    }
}
