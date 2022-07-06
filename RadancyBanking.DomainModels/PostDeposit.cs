using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    /// <summary>
    /// Deposit post transaction object
    /// </summary>
    public class PostDeposit
    {
        /// <summary>
        /// DepositTransaction
        /// </summary>
        public DepositTransaction? Transaction { get; set; }
    }
}
