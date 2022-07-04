using RadancyBanking.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadancyBanking.DomainModels
{
    public class DepositTransaction : AccountTransaction
    {
        public override TransactionType TransactionType => TransactionType.Deposit;
    }
}
